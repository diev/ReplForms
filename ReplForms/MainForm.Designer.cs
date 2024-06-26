namespace ReplForms;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        MenuStrip = new MenuStrip();
        FileMenu = new ToolStripMenuItem();
        FileOpenMenuItem = new ToolStripMenuItem();
        FileSaveMenuItem = new ToolStripMenuItem();
        FileMenuSeparator = new ToolStripSeparator();
        FileExitMenuItem = new ToolStripMenuItem();
        OptionsMenu = new ToolStripMenuItem();
        OptionsReplaceAllMenuItem = new ToolStripMenuItem();
        HelpMenu = new ToolStripMenuItem();
        TemplatesHelpItem = new ToolStripMenuItem();
        ArgsHelpItem = new ToolStripMenuItem();
        toolStripMenuItem1 = new ToolStripSeparator();
        AboutItem = new ToolStripMenuItem();
        StatusStrip = new StatusStrip();
        StatusLabel = new ToolStripStatusLabel();
        StatusLabel2 = new ToolStripStatusLabel();
        Grid = new DataGridView();
        OpenFileDialog = new OpenFileDialog();
        SaveFileDialog = new SaveFileDialog();
        RowContextMenu = new ContextMenuStrip(components);
        MenuStrip.SuspendLayout();
        StatusStrip.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)Grid).BeginInit();
        SuspendLayout();
        // 
        // MenuStrip
        // 
        MenuStrip.Items.AddRange(new ToolStripItem[] { FileMenu, OptionsMenu, HelpMenu });
        MenuStrip.Location = new Point(0, 0);
        MenuStrip.Name = "MenuStrip";
        MenuStrip.Size = new Size(800, 24);
        MenuStrip.TabIndex = 0;
        MenuStrip.Text = "menuStrip1";
        // 
        // FileMenu
        // 
        FileMenu.DropDownItems.AddRange(new ToolStripItem[] { FileOpenMenuItem, FileSaveMenuItem, FileMenuSeparator, FileExitMenuItem });
        FileMenu.Name = "FileMenu";
        FileMenu.Size = new Size(48, 20);
        FileMenu.Text = "Файл";
        // 
        // FileOpenMenuItem
        // 
        FileOpenMenuItem.Name = "FileOpenMenuItem";
        FileOpenMenuItem.ShortcutKeys = Keys.F3;
        FileOpenMenuItem.Size = new Size(197, 22);
        FileOpenMenuItem.Text = "Открыть шаблон...";
        FileOpenMenuItem.Click += FileOpenMenuItem_Click;
        // 
        // FileSaveMenuItem
        // 
        FileSaveMenuItem.Name = "FileSaveMenuItem";
        FileSaveMenuItem.ShortcutKeys = Keys.F4;
        FileSaveMenuItem.Size = new Size(197, 22);
        FileSaveMenuItem.Text = "Сохранить как...";
        FileSaveMenuItem.Click += FileSaveMenuItem_Click;
        // 
        // FileMenuSeparator
        // 
        FileMenuSeparator.Name = "FileMenuSeparator";
        FileMenuSeparator.Size = new Size(194, 6);
        // 
        // FileExitMenuItem
        // 
        FileExitMenuItem.Name = "FileExitMenuItem";
        FileExitMenuItem.Size = new Size(197, 22);
        FileExitMenuItem.Text = "Выход";
        FileExitMenuItem.Click += FileExitMenuItem_Click;
        // 
        // OptionsMenu
        // 
        OptionsMenu.DropDownItems.AddRange(new ToolStripItem[] { OptionsReplaceAllMenuItem });
        OptionsMenu.Name = "OptionsMenu";
        OptionsMenu.Size = new Size(56, 20);
        OptionsMenu.Text = "Опции";
        // 
        // OptionsReplaceAllMenuItem
        // 
        OptionsReplaceAllMenuItem.Checked = true;
        OptionsReplaceAllMenuItem.CheckOnClick = true;
        OptionsReplaceAllMenuItem.CheckState = CheckState.Checked;
        OptionsReplaceAllMenuItem.Name = "OptionsReplaceAllMenuItem";
        OptionsReplaceAllMenuItem.Size = new Size(180, 22);
        OptionsReplaceAllMenuItem.Text = "Заменять все ";
        // 
        // HelpMenu
        // 
        HelpMenu.DropDownItems.AddRange(new ToolStripItem[] { TemplatesHelpItem, ArgsHelpItem, toolStripMenuItem1, AboutItem });
        HelpMenu.Name = "HelpMenu";
        HelpMenu.Size = new Size(68, 20);
        HelpMenu.Text = "Помощь";
        // 
        // TemplatesHelpItem
        // 
        TemplatesHelpItem.Name = "TemplatesHelpItem";
        TemplatesHelpItem.Size = new Size(192, 22);
        TemplatesHelpItem.Text = "О Шаблонах...";
        TemplatesHelpItem.Click += TemplatesHelpItem_Click;
        // 
        // ArgsHelpItem
        // 
        ArgsHelpItem.Name = "ArgsHelpItem";
        ArgsHelpItem.Size = new Size(192, 22);
        ArgsHelpItem.Text = "Параметры запуска...";
        ArgsHelpItem.Click += UsageHelpItem_Click;
        // 
        // toolStripMenuItem1
        // 
        toolStripMenuItem1.Name = "toolStripMenuItem1";
        toolStripMenuItem1.Size = new Size(189, 6);
        // 
        // AboutItem
        // 
        AboutItem.Name = "AboutItem";
        AboutItem.Size = new Size(192, 22);
        AboutItem.Text = "О программе...";
        AboutItem.Click += AboutItem_Click;
        // 
        // StatusStrip
        // 
        StatusStrip.Items.AddRange(new ToolStripItem[] { StatusLabel, StatusLabel2 });
        StatusStrip.Location = new Point(0, 428);
        StatusStrip.Name = "StatusStrip";
        StatusStrip.Size = new Size(800, 22);
        StatusStrip.TabIndex = 1;
        StatusStrip.Text = "statusStrip1";
        // 
        // StatusLabel
        // 
        StatusLabel.Name = "StatusLabel";
        StatusLabel.Size = new Size(703, 17);
        StatusLabel.Spring = true;
        StatusLabel.Text = "Откройте шаблон";
        StatusLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // StatusLabel2
        // 
        StatusLabel2.Name = "StatusLabel2";
        StatusLabel2.Padding = new Padding(0, 0, 5, 0);
        StatusLabel2.Size = new Size(82, 17);
        StatusLabel2.Text = "Не сохранен";
        StatusLabel2.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // Grid
        // 
        Grid.AllowUserToAddRows = false;
        Grid.AllowUserToDeleteRows = false;
        Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        Grid.Dock = DockStyle.Fill;
        Grid.Location = new Point(0, 24);
        Grid.MultiSelect = false;
        Grid.Name = "Grid";
        Grid.SelectionMode = DataGridViewSelectionMode.CellSelect;
        Grid.Size = new Size(800, 404);
        Grid.TabIndex = 2;
        Grid.CellEndEdit += Grid_CellEndEdit;
        Grid.CellValidating += Grid_CellValidating;
        Grid.RowContextMenuStripNeeded += Grid_RowContextMenuStripNeeded;
        // 
        // OpenFileDialog
        // 
        OpenFileDialog.DefaultExt = "xml";
        OpenFileDialog.Filter = "Шаблоны XML|_*.xml|Шаблоны TXT|_*.txt|Все файлы|*.*";
        OpenFileDialog.InitialDirectory = ".";
        OpenFileDialog.ShowPinnedPlaces = false;
        OpenFileDialog.Title = "Открыть шаблон";
        // 
        // SaveFileDialog
        // 
        SaveFileDialog.DefaultExt = "xml";
        SaveFileDialog.FileName = "output.xml";
        SaveFileDialog.Filter = "Результаты XML|*.xml|Результаты TXT|*.txt|Все файлы|*.*";
        SaveFileDialog.InitialDirectory = ".";
        SaveFileDialog.ShowPinnedPlaces = false;
        SaveFileDialog.Title = "Сохранить файл";
        // 
        // RowContextMenu
        // 
        RowContextMenu.Name = "RowContextMenu";
        RowContextMenu.Size = new Size(61, 4);
        RowContextMenu.ItemClicked += RowContextMenu_ItemClicked;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(Grid);
        Controls.Add(MenuStrip);
        Controls.Add(StatusStrip);
        MainMenuStrip = MenuStrip;
        Name = "MainForm";
        Text = "ReplForms";
        FormClosing += MainForm_FormClosing;
        Load += MainForm_Load;
        MenuStrip.ResumeLayout(false);
        MenuStrip.PerformLayout();
        StatusStrip.ResumeLayout(false);
        StatusStrip.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)Grid).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private MenuStrip MenuStrip;
    private StatusStrip StatusStrip;
    private DataGridView Grid;
    private ToolStripMenuItem FileMenu;
    private ToolStripMenuItem FileOpenMenuItem;
    private ToolStripMenuItem FileSaveMenuItem;
    private ToolStripSeparator FileMenuSeparator;
    private ToolStripMenuItem FileExitMenuItem;
    private OpenFileDialog OpenFileDialog;
    private SaveFileDialog SaveFileDialog;
    private ToolStripStatusLabel StatusLabel;
    private ToolStripMenuItem OptionsMenu;
    private ToolStripMenuItem OptionsReplaceAllMenuItem;
    private ToolStripStatusLabel StatusLabel2;
    private ContextMenuStrip RowContextMenu;
    private ToolStripMenuItem HelpMenu;
    private ToolStripMenuItem TemplatesHelpItem;
    private ToolStripSeparator toolStripMenuItem1;
    private ToolStripMenuItem AboutItem;
    private ToolStripMenuItem ArgsHelpItem;
}
