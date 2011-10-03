namespace PinnedDownCardListEditor.View
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sep1ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.sep2ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutPinnedDownCardListEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.toolStripButtonNewCard = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOpenCardList = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSaveCardList = new System.Windows.Forms.ToolStripButton();
            this.newCardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCardListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCardListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortAndRebuildIndicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSortAndRebuildIndices = new System.Windows.Forms.ToolStripButton();
            this.menuStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(784, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCardToolStripMenuItem,
            this.sep1ToolStripMenuItem,
            this.openCardListToolStripMenuItem,
            this.saveCardListToolStripMenuItem,
            this.sep2ToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // sep1ToolStripMenuItem
            // 
            this.sep1ToolStripMenuItem.Name = "sep1ToolStripMenuItem";
            this.sep1ToolStripMenuItem.Size = new System.Drawing.Size(201, 6);
            // 
            // sep2ToolStripMenuItem
            // 
            this.sep2ToolStripMenuItem.Name = "sep2ToolStripMenuItem";
            this.sep2ToolStripMenuItem.Size = new System.Drawing.Size(201, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortAndRebuildIndicesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutPinnedDownCardListEditorToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutPinnedDownCardListEditorToolStripMenuItem
            // 
            this.aboutPinnedDownCardListEditorToolStripMenuItem.Name = "aboutPinnedDownCardListEditorToolStripMenuItem";
            this.aboutPinnedDownCardListEditorToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.aboutPinnedDownCardListEditorToolStripMenuItem.Text = "About Pinned Down Card List Editor...";
            this.aboutPinnedDownCardListEditorToolStripMenuItem.Click += new System.EventHandler(this.aboutPinnedDownCardListEditorToolStripMenuItem_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "cardlist.pdcl";
            this.saveFileDialog.Filter = "Pinned Down Card List|*.pdcl";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "cardlist.pdcl";
            this.openFileDialog.Filter = "Pinned Down Card List|*.pdcl";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNewCard,
            this.toolStripButtonOpenCardList,
            this.toolStripButtonSaveCardList,
            this.toolStripSeparator1,
            this.toolStripButtonSortAndRebuildIndices});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(784, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 49);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(784, 513);
            this.dataGridView.TabIndex = 4;
            this.dataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentDoubleClick);
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            // 
            // toolStripButtonNewCard
            // 
            this.toolStripButtonNewCard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNewCard.Image = global::PinnedDownCardListEditor.Properties.Resources.NewDocumentHS;
            this.toolStripButtonNewCard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNewCard.Name = "toolStripButtonNewCard";
            this.toolStripButtonNewCard.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonNewCard.Text = "Add New Card (Ctrl+N)";
            this.toolStripButtonNewCard.Click += new System.EventHandler(this.toolStripButtonNewCard_Click);
            // 
            // toolStripButtonOpenCardList
            // 
            this.toolStripButtonOpenCardList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpenCardList.Image = global::PinnedDownCardListEditor.Properties.Resources.openHS;
            this.toolStripButtonOpenCardList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpenCardList.Name = "toolStripButtonOpenCardList";
            this.toolStripButtonOpenCardList.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOpenCardList.Text = "Open Card List (Ctrl+O)";
            this.toolStripButtonOpenCardList.Click += new System.EventHandler(this.toolStripButtonOpenCardList_Click);
            // 
            // toolStripButtonSaveCardList
            // 
            this.toolStripButtonSaveCardList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSaveCardList.Image = global::PinnedDownCardListEditor.Properties.Resources.saveHS;
            this.toolStripButtonSaveCardList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveCardList.Name = "toolStripButtonSaveCardList";
            this.toolStripButtonSaveCardList.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSaveCardList.Text = "Save Card List (Ctrl+S)";
            this.toolStripButtonSaveCardList.Click += new System.EventHandler(this.toolStripButtonSaveCardList_Click);
            // 
            // newCardToolStripMenuItem
            // 
            this.newCardToolStripMenuItem.Image = global::PinnedDownCardListEditor.Properties.Resources.NewDocumentHS;
            this.newCardToolStripMenuItem.Name = "newCardToolStripMenuItem";
            this.newCardToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newCardToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.newCardToolStripMenuItem.Text = "Add New Card...";
            this.newCardToolStripMenuItem.Click += new System.EventHandler(this.newCardToolStripMenuItem_Click);
            // 
            // openCardListToolStripMenuItem
            // 
            this.openCardListToolStripMenuItem.Image = global::PinnedDownCardListEditor.Properties.Resources.openHS;
            this.openCardListToolStripMenuItem.Name = "openCardListToolStripMenuItem";
            this.openCardListToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openCardListToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.openCardListToolStripMenuItem.Text = "Open Card List...";
            this.openCardListToolStripMenuItem.Click += new System.EventHandler(this.openCardListToolStripMenuItem_Click);
            // 
            // saveCardListToolStripMenuItem
            // 
            this.saveCardListToolStripMenuItem.Image = global::PinnedDownCardListEditor.Properties.Resources.saveHS;
            this.saveCardListToolStripMenuItem.Name = "saveCardListToolStripMenuItem";
            this.saveCardListToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveCardListToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.saveCardListToolStripMenuItem.Text = "Save Card List...";
            this.saveCardListToolStripMenuItem.Click += new System.EventHandler(this.saveCardListToolStripMenuItem_Click);
            // 
            // sortAndRebuildIndicesToolStripMenuItem
            // 
            this.sortAndRebuildIndicesToolStripMenuItem.Image = global::PinnedDownCardListEditor.Properties.Resources.SortHS;
            this.sortAndRebuildIndicesToolStripMenuItem.Name = "sortAndRebuildIndicesToolStripMenuItem";
            this.sortAndRebuildIndicesToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.sortAndRebuildIndicesToolStripMenuItem.Text = "Sort and Rebuild Indices";
            this.sortAndRebuildIndicesToolStripMenuItem.Click += new System.EventHandler(this.sortAndRebuildIndicesToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonSortAndRebuildIndices
            // 
            this.toolStripButtonSortAndRebuildIndices.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSortAndRebuildIndices.Image = global::PinnedDownCardListEditor.Properties.Resources.SortHS;
            this.toolStripButtonSortAndRebuildIndices.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSortAndRebuildIndices.Name = "toolStripButtonSortAndRebuildIndices";
            this.toolStripButtonSortAndRebuildIndices.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSortAndRebuildIndices.Text = "Sort and Rebuild Indices";
            this.toolStripButtonSortAndRebuildIndices.Click += new System.EventHandler(this.toolStripButtonSortAndRebuildIndices_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Pinned Down Card List Editor";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newCardToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator sep1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCardListToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator sep2ToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem openCardListToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonNewCard;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpenCardList;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveCardList;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutPinnedDownCardListEditorToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortAndRebuildIndicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSortAndRebuildIndices;
    }
}