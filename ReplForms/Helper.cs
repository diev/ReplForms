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

namespace ReplForms;

internal class Helper
{
    public static void Usage()
    {
        MessageBox.Show(@"Шаблон - это XML (или другой) файл,
где есть такие варианты специальных полей шаблона:
`Параметр'
`Параметр;Примечание'
`Параметр;Значение;'
`Параметр;Значение;Примечание'
`Параметр;Значение;Примечание;RegExp'

Поле ""Значение по умолчанию"" может делать автозамену:
GUID
YYYY-MM-DD

Опция ""Заменять все"" - сделает одинаковую замену.

Параметры запуска: Шаблон Результат
В имени файла можно делать автозамену:
{GUID}
{YYYY-MM-DD}

-all - опция ""Заменять все"",
-1251 - кодировка windows-1251 в текстовых шаблонах.",

"Помощь", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public static void XmlUnescape(ref string value)
    {
        if (value.Length > 0 && value.Contains('&', StringComparison.Ordinal))
        {
            value = value
                .Replace("&lt;", "<")
                .Replace("&gt;", ">")
                .Replace("&apos;", "'")
                .Replace("&quot;", @"""")
                .Replace("&", "&amp;");
        }
    }

    public static void XmlEscape(ref string value)
    {
        if (value.Length > 0)
        {
            value = value
                .Replace("&", "&amp;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;")
                .Replace("'", "&apos;")
                .Replace(@"""", "&quot;");
        }
    }

    public static void AutoSubstValue(ref string value)
    {
        const string GUID = "GUID";
        const string DATE = "YYYY-MM-DD";

        if (value.Equals(GUID, StringComparison.OrdinalIgnoreCase))
        {
            value = value.Replace(GUID, Guid.NewGuid().ToString(),
                StringComparison.OrdinalIgnoreCase);
            return;
        }

        if (value.Equals(DATE, StringComparison.OrdinalIgnoreCase))
        {
            value = value.Replace(DATE, DateTime.Now.ToString("yyyy-MM-dd"),
                StringComparison.OrdinalIgnoreCase);
            return;
        }
    }

    public static void AutoSubstFileName(ref string filename)
    {
        const string GUID = "{GUID}";
        const string DATE = "{YYYY-MM-DD}";

        if (filename.Contains(GUID, StringComparison.OrdinalIgnoreCase))
        {
            filename = filename.Replace(GUID, Guid.NewGuid().ToString(),
                StringComparison.OrdinalIgnoreCase);
        }

        if (filename.Contains(DATE, StringComparison.OrdinalIgnoreCase))
        {
            filename = filename.Replace(DATE, DateTime.Now.ToString("yyyy-MM-dd"),
                StringComparison.OrdinalIgnoreCase);
        }
    }

    public static (string? Dir, string? File) ParseFilename(string filename)
    {
        Helper.AutoSubstFileName(ref filename);

        if (filename.Equals(".") || filename.Equals(".."))
        {
            filename += Path.DirectorySeparatorChar;
        }

        var dir = Path.GetDirectoryName(Path.GetFullPath(filename));
        var file = Path.GetFileName(filename);

        if (file.Equals(string.Empty))
        {
            return (dir, null);
        }

        if (file.StartsWith('_'))
        {
            file = file[1..];
        }

        return (dir, file);
    }
}
