#region License
/*
Copyright 2024 Dmitrii Evdokimov
Open source software

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/
#endregion

using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Text;
using System.Xml;

namespace ReplForms;

internal class Table
{
    private const char _pattern1 = '`'; // start
    private const char _pattern0 = '\''; // end
    private static readonly string _pattern = _pattern1 + "(.*?)" + _pattern0;

    private string TemplateText { get; set; } = string.Empty;

    public Encoding Encode { get; set; } = Encoding.UTF8;
    public char Separator { get; set; } = ';';
    public bool ReplaceAll { get; set; }

    public BindingList<TableRow> Rows = [];

    public bool KeyExists(string key)
    {
        foreach (var row in Rows)
        {
            if (row.Key.Equals(key, StringComparison.Ordinal))
            {
                return true;
            }
        }

        return false;
    }

    public bool TryGetValueByKey(string key, out string value)
    {
        foreach (var row in Rows)
        {
            if (row.Key.Equals(key, StringComparison.Ordinal))
            {
                value = row.Value;
                return true;
            }
        }

        value = string.Empty;
        return false;
    }

    public void LoadTemplate(string filename)
    {
        string template;
        bool xml = Path.GetExtension(filename).Equals(".xml",
            StringComparison.OrdinalIgnoreCase);

        if (xml)
        {
            XmlDocument xmlDocument = new();
            xmlDocument.Load(filename);
            template = xmlDocument.OuterXml;

            var enc = (xmlDocument.FirstChild as XmlDeclaration)?.Encoding;
            Encode = string.IsNullOrEmpty(enc)
                ? Encoding.UTF8
                : Encoding.GetEncoding(enc);
        }
        else
        {
            template = File.ReadAllText(filename, Encode);
        }

        Rows.Clear();

        foreach (Match match in Regex.Matches(template, _pattern))
        {
            if (match.Success && match.Groups.Count > 0)
            {
                var key = match.Groups[1].Value;
                var pair = key.Split(Separator);

                if (ReplaceAll && KeyExists(pair.Length == 1 ? key : pair[0]))
                {
                    continue;
                }

                var row = new TableRow();

                switch (pair.Length)
                {
                    case 1:
                        row.Key = key;
                        break;
                    case 2:
                        row.Key = pair[0];
                        row.Remark = pair[1];
                        break;
                    case 3:
                        row.Key = pair[0];
                        row.Value = pair[1];
                        row.Remark = pair[2];
                        break;
                    case 4:
                        row.Key = pair[0];
                        row.Value = pair[1];
                        row.Remark = pair[2];
                        row.Validator = pair[3];
                        break;
                }

                string value = row.Value;

                if (value.Length > 0)
                {
                    Helper.AutoSubstValue(ref value);

                    if (xml)
                    {
                        Helper.XmlUnescape(ref value);
                    }
                }

                row.Value = value;
                Rows.Add(row);
            }
        }

        TemplateText = template;
    }

    public void ProcessTemplate(string filename)
    {
        string template = TemplateText; // File.ReadAllText(templatename, Encode);
        bool xml = Path.GetExtension(filename).Equals(".xml",
            StringComparison.OrdinalIgnoreCase);

        foreach (var row in Rows)
        {
            var key = row.Key;
            var value = row.Value;
            string pattern = _pattern1 + key + "(|" + Separator + ".*?)" + _pattern0;

            if (xml)
            {
                Helper.XmlEscape(ref value);
            }

            if (ReplaceAll)
            {
                template = Regex.Replace(template, pattern, value);
            }
            else
            {
                var expr = new Regex(pattern);
                template = expr.Replace(template, value, 1);
            }
        }

        if (xml)
        {
            XmlDocument xmlDocument = new();
            xmlDocument.LoadXml(template);
            xmlDocument.Save(filename);
        }
        else
        {
            File.WriteAllText(filename, template, Encode);
        }
    }
}
