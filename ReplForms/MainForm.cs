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

using System.Text;
using System.Text.RegularExpressions;

namespace ReplForms;

public partial class MainForm : Form
{
    private bool _closing = false;

    public string? TemplateFileName { get; set; }
    public string? ResultPath { get; set; }
    public string? ResultFileName { get; set; }
    private Table Table { get; set; } = new();

    public MainForm()
    {
        InitializeComponent();
        ParseArgs();
        Grid.DataSource = Table.Rows;
        FileSaveMenuItem.Enabled = false;
    }

    private void ParseArgs()
    {
        var args = Environment.GetCommandLineArgs();
        int index = 0; // Number of a filename in args

        foreach (var arg in args)
        {
            // Options

            if (arg.Equals("-1", StringComparison.Ordinal))
            {
                OptionsReplaceAllMenuItem.Checked = false;
                continue;
            }

            if (arg.Equals("-1251", StringComparison.Ordinal))
            {
                Table.Encode = Encoding.GetEncoding(1251);
                continue;
            }

            // Filenames

            if (index == 0)
            {
                // Skip App
                index++;
                continue;
            }

            if (index == 1 && File.Exists(arg)) // templatename to open
            {
                TemplateFileName = Path.GetFullPath(arg);
                index++;
                continue;
            }

            if (index == 2) // filename to save
            {
                (ResultPath, ResultFileName) = Helper.ParseFilename(arg);
                index++;
                continue;
            }
        }

        // End of arguments

        if (TemplateFileName != null)
        {
            var path = Helper.ParseFilename(TemplateFileName);
            ResultPath ??= path.Dir;
            ResultFileName ??= path.File;
        }
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        if (TemplateFileName != null && File.Exists(TemplateFileName))
        {
            LoadTemplate();
            return;
        }

        ShowOpenFileDialog();
    }

    private void FileOpenMenuItem_Click(object sender, EventArgs e)
    {
        ShowOpenFileDialog();
    }

    private void FileSaveMenuItem_Click(object sender, EventArgs e)
    {
        ShowSaveFileDialog();
    }

    private void FileExitMenuItem_Click(object sender, EventArgs e)
    {
        Grid.CancelEdit();
        Close();
    }

    private void ShowOpenFileDialog()
    {
        if (TemplateFileName != null)
        {
            OpenFileDialog.InitialDirectory = Path.GetDirectoryName(TemplateFileName);
            OpenFileDialog.FileName = Path.GetFileName(TemplateFileName);
        }
        else
        {
            OpenFileDialog.InitialDirectory = Path.GetDirectoryName(Environment.ProcessPath);
        }

        if (OpenFileDialog.ShowDialog() != DialogResult.OK) return;

        TemplateFileName = OpenFileDialog.FileName;
        LoadTemplate();
    }

    private void LoadTemplate()
    {
        StatusLabel.Text = "Шаблон: " + TemplateFileName;

        Table.ReplaceAll = OptionsReplaceAllMenuItem.Checked;
        Table.LoadTemplate(TemplateFileName!);
        DecorateGrid();

        var path = Helper.ParseFilename(TemplateFileName!);
        ResultPath ??= path.Dir;
        ResultFileName ??= path.File;

        FileSaveMenuItem.Enabled = true;
    }

    private void ShowSaveFileDialog()
    {
        Grid.EndEdit();

        SaveFileDialog.InitialDirectory = ResultPath ?? Path.GetDirectoryName(Environment.ProcessPath);
        SaveFileDialog.FileName = ResultFileName;

        if (SaveFileDialog.ShowDialog() != DialogResult.OK) return;

        string path = SaveFileDialog.FileName;

        if (path.Length == 0)
        {
            MessageBox.Show("Файл для сохранения не указан",
                SaveFileDialog.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }

        ResultPath = Path.GetDirectoryName(path);
        ResultFileName = Path.GetFileName(path);

        if (ResultFileName.StartsWith('_'))
        {
            MessageBox.Show("Попытка затереть шаблон " + path,
                SaveFileDialog.Title, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return;
        }

        Table.ReplaceAll = OptionsReplaceAllMenuItem.Checked;
        Table.ProcessTemplate(path);

        StatusLabel2.Text = "Сохранен в " + ResultFileName;

        MessageBox.Show("Файл сохранен в " + path,
            SaveFileDialog.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void DecorateGrid()
    {
        string[] headers = ["Параметр", "Значение", "Примечание", "Проверка"];

        var column = Grid.Columns[0];
        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        int width = column.Width;
        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

        for (int i = 0; i < Grid.Columns.Count; i++)
        {
            column = Grid.Columns[i];
            column.HeaderText = headers[i];

            column.Width = width;
            column.ReadOnly = true;
        }

        column = Grid.Columns[1];
        column.Width = Grid.ClientSize.Width - Grid.RowHeadersWidth - width * 3 -
            SystemInformation.VerticalScrollBarWidth - 2;

        DataGridViewRow header = Grid.Rows[0];
        header.ReadOnly = true;
    }

    private void Grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        Grid.Rows[e.RowIndex].ErrorText = string.Empty;
    }

    private void Grid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        if (_closing) return;
        if (e.ColumnIndex != 1) return;

        //var pattern = Grid.Rows[e.RowIndex].Cells[3].Value.ToString();
        string pattern = Table.Rows[e.RowIndex].Validator;
        if (pattern.Length == 0) return;

        var value = e.FormattedValue!.ToString();

        if (Regex.IsMatch(value!, '^' + pattern + '$')) return;

        Grid.Rows[e.RowIndex].ErrorText = "Требуется " + pattern;
        e.Cancel = true;
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        _closing = true;
    }

    private void Grid_RowContextMenuStripNeeded(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
    {
        var row = Grid.Rows[e.RowIndex];
        var cell = row.Cells[2].Value.ToString() ?? string.Empty;

        if (cell.Contains('|'))
        {
            RowContextMenu.Items.Clear();
            RowContextMenu.Tag = row.Cells[1];
            var values = cell.Split('|');

            foreach (var value in values)
            {
                RowContextMenu.Items.Add(value);
            }

            e.ContextMenuStrip = RowContextMenu;
        }
    }

    private void RowContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
        string separator = " - ";
        var value = e.ClickedItem?.Text;

        if (value == null) return;

        if (value.Contains(separator, StringComparison.Ordinal))
        {
            value = value[..value.IndexOf(separator)];
        }

        (RowContextMenu.Tag as DataGridViewCell)!.Value = value;
    }

    private void TemplatesHelpItem_Click(object sender, EventArgs e)
    {
        Helper.TemplatesHelp();
    }

    private void UsageHelpItem_Click(object sender, EventArgs e)
    {
        Helper.UsageHelp();
    }

    private void AboutItem_Click(object sender, EventArgs e)
    {
        Helper.About();
    }
}
