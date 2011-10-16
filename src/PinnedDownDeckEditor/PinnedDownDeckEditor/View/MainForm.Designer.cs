namespace PinnedDownDeckEditor.View
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
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation1 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation2 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDeckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openDeckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDeckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutPinnedDownDeckEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxDeckInfo = new System.Windows.Forms.GroupBox();
            this.linkLabelFlagship = new System.Windows.Forms.LinkLabel();
            this.labelFlagship = new System.Windows.Forms.Label();
            this.labelCardCount = new System.Windows.Forms.Label();
            this.labelCardCountValue = new System.Windows.Forms.Label();
            this.comboBoxAffiliation = new System.Windows.Forms.ComboBox();
            this.textBoxDeckName = new System.Windows.Forms.TextBox();
            this.textBoxDeckAuthor = new System.Windows.Forms.TextBox();
            this.labelAffiliation = new System.Windows.Forms.Label();
            this.labelDeckAuthor = new System.Windows.Forms.Label();
            this.labelDeckName = new System.Windows.Forms.Label();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labelCharacters = new System.Windows.Forms.Label();
            this.labelEffects = new System.Windows.Forms.Label();
            this.labelEquipments = new System.Windows.Forms.Label();
            this.labelStarships = new System.Windows.Forms.Label();
            this.groupBoxDeckList = new System.Windows.Forms.GroupBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNewDeck = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOpenDeck = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSaveDeck = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBoxDeckOperations = new System.Windows.Forms.GroupBox();
            this.buttonAddStarship = new System.Windows.Forms.Button();
            this.buttonAddEquipment = new System.Windows.Forms.Button();
            this.buttonAddEffect = new System.Windows.Forms.Button();
            this.buttonAddCharacter = new System.Windows.Forms.Button();
            this.groupBoxDeckInformation = new System.Windows.Forms.GroupBox();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelAvgCardCostValue = new System.Windows.Forms.Label();
            this.labelAvgCardCost = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.groupBoxDeckInfo.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.groupBoxDeckList.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.groupBoxDeckOperations.SuspendLayout();
            this.groupBoxDeckInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDeckToolStripMenuItem,
            this.toolStripSeparator1,
            this.openDeckToolStripMenuItem,
            this.saveDeckToolStripMenuItem,
            this.toolStripSeparator2,
            this.aboutPinnedDownDeckEditorToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newDeckToolStripMenuItem
            // 
            this.newDeckToolStripMenuItem.Image = global::PinnedDownDeckEditor.Properties.Resources.NewDocumentHS;
            this.newDeckToolStripMenuItem.Name = "newDeckToolStripMenuItem";
            this.newDeckToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newDeckToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.newDeckToolStripMenuItem.Text = "New Deck";
            this.newDeckToolStripMenuItem.Click += new System.EventHandler(this.newDeckToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(250, 6);
            // 
            // openDeckToolStripMenuItem
            // 
            this.openDeckToolStripMenuItem.Image = global::PinnedDownDeckEditor.Properties.Resources.openHS;
            this.openDeckToolStripMenuItem.Name = "openDeckToolStripMenuItem";
            this.openDeckToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openDeckToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.openDeckToolStripMenuItem.Text = "Open Deck...";
            this.openDeckToolStripMenuItem.Click += new System.EventHandler(this.openDeckToolStripMenuItem_Click);
            // 
            // saveDeckToolStripMenuItem
            // 
            this.saveDeckToolStripMenuItem.Image = global::PinnedDownDeckEditor.Properties.Resources.saveHS;
            this.saveDeckToolStripMenuItem.Name = "saveDeckToolStripMenuItem";
            this.saveDeckToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveDeckToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.saveDeckToolStripMenuItem.Text = "Save Deck...";
            this.saveDeckToolStripMenuItem.Click += new System.EventHandler(this.saveDeckToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(250, 6);
            // 
            // aboutPinnedDownDeckEditorToolStripMenuItem
            // 
            this.aboutPinnedDownDeckEditorToolStripMenuItem.Name = "aboutPinnedDownDeckEditorToolStripMenuItem";
            this.aboutPinnedDownDeckEditorToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.aboutPinnedDownDeckEditorToolStripMenuItem.Text = "About Pinned Down Deck Editor...";
            this.aboutPinnedDownDeckEditorToolStripMenuItem.Click += new System.EventHandler(this.aboutPinnedDownDeckEditorToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(250, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // groupBoxDeckInfo
            // 
            this.groupBoxDeckInfo.Controls.Add(this.linkLabelFlagship);
            this.groupBoxDeckInfo.Controls.Add(this.labelFlagship);
            this.groupBoxDeckInfo.Controls.Add(this.labelCardCount);
            this.groupBoxDeckInfo.Controls.Add(this.labelCardCountValue);
            this.groupBoxDeckInfo.Controls.Add(this.comboBoxAffiliation);
            this.groupBoxDeckInfo.Controls.Add(this.textBoxDeckName);
            this.groupBoxDeckInfo.Controls.Add(this.textBoxDeckAuthor);
            this.groupBoxDeckInfo.Controls.Add(this.labelAffiliation);
            this.groupBoxDeckInfo.Controls.Add(this.labelDeckAuthor);
            this.groupBoxDeckInfo.Controls.Add(this.labelDeckName);
            this.groupBoxDeckInfo.Location = new System.Drawing.Point(12, 52);
            this.groupBoxDeckInfo.Name = "groupBoxDeckInfo";
            this.groupBoxDeckInfo.Size = new System.Drawing.Size(288, 154);
            this.groupBoxDeckInfo.TabIndex = 1;
            this.groupBoxDeckInfo.TabStop = false;
            this.groupBoxDeckInfo.Text = "Deck Information";
            // 
            // linkLabelFlagship
            // 
            this.linkLabelFlagship.AutoSize = true;
            this.linkLabelFlagship.Location = new System.Drawing.Point(79, 130);
            this.linkLabelFlagship.Name = "linkLabelFlagship";
            this.linkLabelFlagship.Size = new System.Drawing.Size(37, 13);
            this.linkLabelFlagship.TabIndex = 6;
            this.linkLabelFlagship.TabStop = true;
            this.linkLabelFlagship.Text = "(none)";
            this.linkLabelFlagship.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelFlagship_LinkClicked);
            // 
            // labelFlagship
            // 
            this.labelFlagship.AutoSize = true;
            this.labelFlagship.Location = new System.Drawing.Point(6, 130);
            this.labelFlagship.Name = "labelFlagship";
            this.labelFlagship.Size = new System.Drawing.Size(49, 13);
            this.labelFlagship.TabIndex = 5;
            this.labelFlagship.Text = "Flagship:";
            // 
            // labelCardCount
            // 
            this.labelCardCount.AutoSize = true;
            this.labelCardCount.Location = new System.Drawing.Point(6, 104);
            this.labelCardCount.Name = "labelCardCount";
            this.labelCardCount.Size = new System.Drawing.Size(37, 13);
            this.labelCardCount.TabIndex = 4;
            this.labelCardCount.Text = "Cards:";
            // 
            // labelCardCountValue
            // 
            this.labelCardCountValue.AutoSize = true;
            this.labelCardCountValue.Location = new System.Drawing.Point(79, 104);
            this.labelCardCountValue.Name = "labelCardCountValue";
            this.labelCardCountValue.Size = new System.Drawing.Size(13, 13);
            this.labelCardCountValue.TabIndex = 3;
            this.labelCardCountValue.Text = "0";
            // 
            // comboBoxAffiliation
            // 
            this.comboBoxAffiliation.FormattingEnabled = true;
            this.comboBoxAffiliation.Location = new System.Drawing.Point(82, 78);
            this.comboBoxAffiliation.Name = "comboBoxAffiliation";
            this.comboBoxAffiliation.Size = new System.Drawing.Size(200, 21);
            this.comboBoxAffiliation.TabIndex = 2;
            // 
            // textBoxDeckName
            // 
            this.textBoxDeckName.Location = new System.Drawing.Point(82, 23);
            this.textBoxDeckName.Name = "textBoxDeckName";
            this.textBoxDeckName.Size = new System.Drawing.Size(200, 20);
            this.textBoxDeckName.TabIndex = 2;
            // 
            // textBoxDeckAuthor
            // 
            this.textBoxDeckAuthor.Location = new System.Drawing.Point(82, 49);
            this.textBoxDeckAuthor.Name = "textBoxDeckAuthor";
            this.textBoxDeckAuthor.Size = new System.Drawing.Size(200, 20);
            this.textBoxDeckAuthor.TabIndex = 2;
            // 
            // labelAffiliation
            // 
            this.labelAffiliation.AutoSize = true;
            this.labelAffiliation.Location = new System.Drawing.Point(6, 78);
            this.labelAffiliation.Name = "labelAffiliation";
            this.labelAffiliation.Size = new System.Drawing.Size(52, 13);
            this.labelAffiliation.TabIndex = 2;
            this.labelAffiliation.Text = "Affiliation:";
            // 
            // labelDeckAuthor
            // 
            this.labelDeckAuthor.AutoSize = true;
            this.labelDeckAuthor.Location = new System.Drawing.Point(6, 52);
            this.labelDeckAuthor.Name = "labelDeckAuthor";
            this.labelDeckAuthor.Size = new System.Drawing.Size(70, 13);
            this.labelDeckAuthor.TabIndex = 1;
            this.labelDeckAuthor.Text = "Deck Author:";
            // 
            // labelDeckName
            // 
            this.labelDeckName.AutoSize = true;
            this.labelDeckName.Location = new System.Drawing.Point(6, 26);
            this.labelDeckName.Name = "labelDeckName";
            this.labelDeckName.Size = new System.Drawing.Size(67, 13);
            this.labelDeckName.TabIndex = 0;
            this.labelDeckName.Text = "Deck Name:";
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoScroll = true;
            this.tableLayoutPanel.ColumnCount = 4;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.66667F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.33333F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 198F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 259F));
            this.tableLayoutPanel.Controls.Add(this.labelCharacters, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.labelEffects, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.labelEquipments, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.labelStarships, 0, 3);
            this.tableLayoutPanel.Location = new System.Drawing.Point(6, 17);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(678, 630);
            this.tableLayoutPanel.TabIndex = 3;
            // 
            // labelCharacters
            // 
            this.labelCharacters.AutoSize = true;
            this.labelCharacters.Location = new System.Drawing.Point(3, 0);
            this.labelCharacters.Name = "labelCharacters";
            this.labelCharacters.Size = new System.Drawing.Size(76, 13);
            this.labelCharacters.TabIndex = 0;
            this.labelCharacters.Text = "Characters (0):";
            // 
            // labelEffects
            // 
            this.labelEffects.AutoSize = true;
            this.labelEffects.Location = new System.Drawing.Point(3, 295);
            this.labelEffects.Name = "labelEffects";
            this.labelEffects.Size = new System.Drawing.Size(35, 13);
            this.labelEffects.TabIndex = 1;
            this.labelEffects.Text = "label1";
            // 
            // labelEquipments
            // 
            this.labelEquipments.AutoSize = true;
            this.labelEquipments.Location = new System.Drawing.Point(3, 590);
            this.labelEquipments.Name = "labelEquipments";
            this.labelEquipments.Size = new System.Drawing.Size(35, 13);
            this.labelEquipments.TabIndex = 2;
            this.labelEquipments.Text = "label1";
            // 
            // labelStarships
            // 
            this.labelStarships.AutoSize = true;
            this.labelStarships.Location = new System.Drawing.Point(3, 610);
            this.labelStarships.Name = "labelStarships";
            this.labelStarships.Size = new System.Drawing.Size(35, 13);
            this.labelStarships.TabIndex = 3;
            this.labelStarships.Text = "label1";
            // 
            // groupBoxDeckList
            // 
            this.groupBoxDeckList.Controls.Add(this.tableLayoutPanel);
            this.groupBoxDeckList.Location = new System.Drawing.Point(306, 52);
            this.groupBoxDeckList.Name = "groupBoxDeckList";
            this.groupBoxDeckList.Size = new System.Drawing.Size(690, 653);
            this.groupBoxDeckList.TabIndex = 4;
            this.groupBoxDeckList.TabStop = false;
            this.groupBoxDeckList.Text = "Deck List";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "deck.pdd";
            this.openFileDialog.Filter = "Pinned Down Deck|*.pdd";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "deck.pdd";
            this.saveFileDialog.Filter = "Pinned Down Deck|*.pdd";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNewDeck,
            this.toolStripButtonOpenDeck,
            this.toolStripButtonSaveDeck});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1008, 25);
            this.toolStrip.TabIndex = 5;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButtonNewDeck
            // 
            this.toolStripButtonNewDeck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNewDeck.Image = global::PinnedDownDeckEditor.Properties.Resources.NewDocumentHS;
            this.toolStripButtonNewDeck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNewDeck.Name = "toolStripButtonNewDeck";
            this.toolStripButtonNewDeck.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonNewDeck.Text = "New Deck (Ctrl+N)";
            this.toolStripButtonNewDeck.Click += new System.EventHandler(this.toolStripButtonNewDeck_Click);
            // 
            // toolStripButtonOpenDeck
            // 
            this.toolStripButtonOpenDeck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpenDeck.Image = global::PinnedDownDeckEditor.Properties.Resources.openHS;
            this.toolStripButtonOpenDeck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpenDeck.Name = "toolStripButtonOpenDeck";
            this.toolStripButtonOpenDeck.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOpenDeck.Text = "Open Deck (Ctrl+O)";
            this.toolStripButtonOpenDeck.Click += new System.EventHandler(this.toolStripButtonOpenDeck_Click);
            // 
            // toolStripButtonSaveDeck
            // 
            this.toolStripButtonSaveDeck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSaveDeck.Image = global::PinnedDownDeckEditor.Properties.Resources.saveHS;
            this.toolStripButtonSaveDeck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveDeck.Name = "toolStripButtonSaveDeck";
            this.toolStripButtonSaveDeck.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSaveDeck.Text = "Save Deck (Ctrl+S)";
            this.toolStripButtonSaveDeck.Click += new System.EventHandler(this.toolStripButtonSaveDeck_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 708);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip.TabIndex = 6;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // groupBoxDeckOperations
            // 
            this.groupBoxDeckOperations.Controls.Add(this.buttonAddStarship);
            this.groupBoxDeckOperations.Controls.Add(this.buttonAddEquipment);
            this.groupBoxDeckOperations.Controls.Add(this.buttonAddEffect);
            this.groupBoxDeckOperations.Controls.Add(this.buttonAddCharacter);
            this.groupBoxDeckOperations.Location = new System.Drawing.Point(12, 212);
            this.groupBoxDeckOperations.Name = "groupBoxDeckOperations";
            this.groupBoxDeckOperations.Size = new System.Drawing.Size(288, 135);
            this.groupBoxDeckOperations.TabIndex = 7;
            this.groupBoxDeckOperations.TabStop = false;
            this.groupBoxDeckOperations.Text = "Deck Operations";
            // 
            // buttonAddStarship
            // 
            this.buttonAddStarship.Location = new System.Drawing.Point(6, 106);
            this.buttonAddStarship.Name = "buttonAddStarship";
            this.buttonAddStarship.Size = new System.Drawing.Size(276, 23);
            this.buttonAddStarship.TabIndex = 3;
            this.buttonAddStarship.Text = "Add Starship";
            this.buttonAddStarship.UseVisualStyleBackColor = true;
            this.buttonAddStarship.Click += new System.EventHandler(this.buttonAddStarship_Click);
            // 
            // buttonAddEquipment
            // 
            this.buttonAddEquipment.Location = new System.Drawing.Point(6, 77);
            this.buttonAddEquipment.Name = "buttonAddEquipment";
            this.buttonAddEquipment.Size = new System.Drawing.Size(276, 23);
            this.buttonAddEquipment.TabIndex = 2;
            this.buttonAddEquipment.Text = "Add Equipment";
            this.buttonAddEquipment.UseVisualStyleBackColor = true;
            this.buttonAddEquipment.Click += new System.EventHandler(this.buttonAddEquipment_Click);
            // 
            // buttonAddEffect
            // 
            this.buttonAddEffect.Location = new System.Drawing.Point(6, 48);
            this.buttonAddEffect.Name = "buttonAddEffect";
            this.buttonAddEffect.Size = new System.Drawing.Size(276, 23);
            this.buttonAddEffect.TabIndex = 1;
            this.buttonAddEffect.Text = "Add Effect";
            this.buttonAddEffect.UseVisualStyleBackColor = true;
            this.buttonAddEffect.Click += new System.EventHandler(this.buttonAddEffect_Click);
            // 
            // buttonAddCharacter
            // 
            this.buttonAddCharacter.Location = new System.Drawing.Point(6, 19);
            this.buttonAddCharacter.Name = "buttonAddCharacter";
            this.buttonAddCharacter.Size = new System.Drawing.Size(276, 23);
            this.buttonAddCharacter.TabIndex = 0;
            this.buttonAddCharacter.Text = "Add Character";
            this.buttonAddCharacter.UseVisualStyleBackColor = true;
            this.buttonAddCharacter.Click += new System.EventHandler(this.buttonAddCharacter_Click);
            // 
            // groupBoxDeckInformation
            // 
            this.groupBoxDeckInformation.Controls.Add(this.chart);
            this.groupBoxDeckInformation.Controls.Add(this.labelAvgCardCostValue);
            this.groupBoxDeckInformation.Controls.Add(this.labelAvgCardCost);
            this.groupBoxDeckInformation.Location = new System.Drawing.Point(12, 353);
            this.groupBoxDeckInformation.Name = "groupBoxDeckInformation";
            this.groupBoxDeckInformation.Size = new System.Drawing.Size(288, 346);
            this.groupBoxDeckInformation.TabIndex = 8;
            this.groupBoxDeckInformation.TabStop = false;
            this.groupBoxDeckInformation.Text = "Deck Information";
            // 
            // chart
            // 
            lineAnnotation1.AxisXName = "ChartArea\\rX";
            lineAnnotation1.Name = "LineAnnotationX";
            lineAnnotation2.Name = "LineAnnotationY";
            lineAnnotation2.YAxisName = "ChartArea\\rY";
            this.chart.Annotations.Add(lineAnnotation1);
            this.chart.Annotations.Add(lineAnnotation2);
            chartArea1.AxisX.Title = "Cost";
            chartArea1.AxisY.Title = "Cards";
            chartArea1.Name = "ChartArea";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Location = new System.Drawing.Point(9, 19);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea";
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(273, 287);
            this.chart.TabIndex = 2;
            this.chart.Text = "chart1";
            title1.Name = "Title";
            title1.Text = "Cards Per Cost";
            this.chart.Titles.Add(title1);
            // 
            // labelAvgCardCostValue
            // 
            this.labelAvgCardCostValue.AutoSize = true;
            this.labelAvgCardCostValue.Location = new System.Drawing.Point(111, 321);
            this.labelAvgCardCostValue.Name = "labelAvgCardCostValue";
            this.labelAvgCardCostValue.Size = new System.Drawing.Size(13, 13);
            this.labelAvgCardCostValue.TabIndex = 1;
            this.labelAvgCardCostValue.Text = "0";
            // 
            // labelAvgCardCost
            // 
            this.labelAvgCardCost.AutoSize = true;
            this.labelAvgCardCost.Location = new System.Drawing.Point(6, 321);
            this.labelAvgCardCost.Name = "labelAvgCardCost";
            this.labelAvgCardCost.Size = new System.Drawing.Size(99, 13);
            this.labelAvgCardCost.TabIndex = 0;
            this.labelAvgCardCost.Text = "Average Card Cost:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.groupBoxDeckInformation);
            this.Controls.Add(this.groupBoxDeckOperations);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.groupBoxDeckList);
            this.Controls.Add(this.groupBoxDeckInfo);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Pinned Down Deck Editor";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBoxDeckInfo.ResumeLayout(false);
            this.groupBoxDeckInfo.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.groupBoxDeckList.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBoxDeckOperations.ResumeLayout(false);
            this.groupBoxDeckInformation.ResumeLayout(false);
            this.groupBoxDeckInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDeckToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem openDeckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDeckToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem aboutPinnedDownDeckEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxDeckInfo;
        private System.Windows.Forms.Label labelDeckAuthor;
        private System.Windows.Forms.Label labelDeckName;
        private System.Windows.Forms.Label labelAffiliation;
        private System.Windows.Forms.TextBox textBoxDeckAuthor;
        private System.Windows.Forms.TextBox textBoxDeckName;
        private System.Windows.Forms.ComboBox comboBoxAffiliation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.GroupBox groupBoxDeckList;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButtonNewDeck;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpenDeck;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveDeck;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.GroupBox groupBoxDeckOperations;
        private System.Windows.Forms.Button buttonAddCharacter;
        private System.Windows.Forms.Button buttonAddEffect;
        private System.Windows.Forms.Button buttonAddEquipment;
        private System.Windows.Forms.Button buttonAddStarship;
        private System.Windows.Forms.Label labelCardCountValue;
        private System.Windows.Forms.Label labelCardCount;
        private System.Windows.Forms.Label labelFlagship;
        private System.Windows.Forms.LinkLabel linkLabelFlagship;
        private System.Windows.Forms.GroupBox groupBoxDeckInformation;
        private System.Windows.Forms.Label labelAvgCardCostValue;
        private System.Windows.Forms.Label labelAvgCardCost;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Label labelCharacters;
        private System.Windows.Forms.Label labelEffects;
        private System.Windows.Forms.Label labelEquipments;
        private System.Windows.Forms.Label labelStarships;
    }
}