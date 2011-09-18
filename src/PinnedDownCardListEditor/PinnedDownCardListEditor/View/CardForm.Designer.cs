namespace PinnedDownCardListEditor.View
{
    partial class CardForm
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
            this.labelCardName = new System.Windows.Forms.Label();
            this.textBoxCardName = new System.Windows.Forms.TextBox();
            this.labelGameText = new System.Windows.Forms.Label();
            this.textBoxGameText = new System.Windows.Forms.TextBox();
            this.checkBoxUnique = new System.Windows.Forms.CheckBox();
            this.labelAffiliation = new System.Windows.Forms.Label();
            this.comboBoxAffiliation = new System.Windows.Forms.ComboBox();
            this.labelCardType = new System.Windows.Forms.Label();
            this.groupBoxBasicAttributes = new System.Windows.Forms.GroupBox();
            this.comboBoxCardType = new System.Windows.Forms.ComboBox();
            this.groupBoxSpecialAttributes = new System.Windows.Forms.GroupBox();
            this.numericUpDownStructureMalus = new System.Windows.Forms.NumericUpDown();
            this.labelStructureMalus = new System.Windows.Forms.Label();
            this.numericUpDownDistance = new System.Windows.Forms.NumericUpDown();
            this.labelDistance = new System.Windows.Forms.Label();
            this.labelLocationType = new System.Windows.Forms.Label();
            this.comboBoxLocationType = new System.Windows.Forms.ComboBox();
            this.checkBoxFlagship = new System.Windows.Forms.CheckBox();
            this.labelShipClass = new System.Windows.Forms.Label();
            this.labelCapacity = new System.Windows.Forms.Label();
            this.labelPower = new System.Windows.Forms.Label();
            this.textBoxShipClass = new System.Windows.Forms.TextBox();
            this.numericUpDownCapacity = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPower = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownThreat = new System.Windows.Forms.NumericUpDown();
            this.labelThreat = new System.Windows.Forms.Label();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxBasicAttributes.SuspendLayout();
            this.groupBoxSpecialAttributes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStructureMalus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreat)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCardName
            // 
            this.labelCardName.AutoSize = true;
            this.labelCardName.Location = new System.Drawing.Point(6, 25);
            this.labelCardName.Name = "labelCardName";
            this.labelCardName.Size = new System.Drawing.Size(63, 13);
            this.labelCardName.TabIndex = 0;
            this.labelCardName.Text = "Card Name:";
            // 
            // textBoxCardName
            // 
            this.textBoxCardName.Location = new System.Drawing.Point(105, 22);
            this.textBoxCardName.Name = "textBoxCardName";
            this.textBoxCardName.Size = new System.Drawing.Size(489, 20);
            this.textBoxCardName.TabIndex = 1;
            // 
            // labelGameText
            // 
            this.labelGameText.AutoSize = true;
            this.labelGameText.Location = new System.Drawing.Point(6, 78);
            this.labelGameText.Name = "labelGameText";
            this.labelGameText.Size = new System.Drawing.Size(62, 13);
            this.labelGameText.TabIndex = 2;
            this.labelGameText.Text = "Game Text:";
            // 
            // textBoxGameText
            // 
            this.textBoxGameText.Location = new System.Drawing.Point(105, 75);
            this.textBoxGameText.Multiline = true;
            this.textBoxGameText.Name = "textBoxGameText";
            this.textBoxGameText.Size = new System.Drawing.Size(489, 106);
            this.textBoxGameText.TabIndex = 3;
            // 
            // checkBoxUnique
            // 
            this.checkBoxUnique.AutoSize = true;
            this.checkBoxUnique.Location = new System.Drawing.Point(105, 187);
            this.checkBoxUnique.Name = "checkBoxUnique";
            this.checkBoxUnique.Size = new System.Drawing.Size(71, 17);
            this.checkBoxUnique.TabIndex = 4;
            this.checkBoxUnique.Text = "Is Unique";
            this.checkBoxUnique.UseVisualStyleBackColor = true;
            // 
            // labelAffiliation
            // 
            this.labelAffiliation.AutoSize = true;
            this.labelAffiliation.Location = new System.Drawing.Point(6, 25);
            this.labelAffiliation.Name = "labelAffiliation";
            this.labelAffiliation.Size = new System.Drawing.Size(52, 13);
            this.labelAffiliation.TabIndex = 5;
            this.labelAffiliation.Text = "Affiliation:";
            // 
            // comboBoxAffiliation
            // 
            this.comboBoxAffiliation.FormattingEnabled = true;
            this.comboBoxAffiliation.Location = new System.Drawing.Point(94, 22);
            this.comboBoxAffiliation.Name = "comboBoxAffiliation";
            this.comboBoxAffiliation.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAffiliation.TabIndex = 6;
            // 
            // labelCardType
            // 
            this.labelCardType.AutoSize = true;
            this.labelCardType.Location = new System.Drawing.Point(6, 51);
            this.labelCardType.Name = "labelCardType";
            this.labelCardType.Size = new System.Drawing.Size(59, 13);
            this.labelCardType.TabIndex = 7;
            this.labelCardType.Text = "Card Type:";
            // 
            // groupBoxBasicAttributes
            // 
            this.groupBoxBasicAttributes.Controls.Add(this.comboBoxCardType);
            this.groupBoxBasicAttributes.Controls.Add(this.labelCardName);
            this.groupBoxBasicAttributes.Controls.Add(this.labelCardType);
            this.groupBoxBasicAttributes.Controls.Add(this.checkBoxUnique);
            this.groupBoxBasicAttributes.Controls.Add(this.textBoxCardName);
            this.groupBoxBasicAttributes.Controls.Add(this.textBoxGameText);
            this.groupBoxBasicAttributes.Controls.Add(this.labelGameText);
            this.groupBoxBasicAttributes.Location = new System.Drawing.Point(12, 12);
            this.groupBoxBasicAttributes.Name = "groupBoxBasicAttributes";
            this.groupBoxBasicAttributes.Size = new System.Drawing.Size(600, 210);
            this.groupBoxBasicAttributes.TabIndex = 8;
            this.groupBoxBasicAttributes.TabStop = false;
            this.groupBoxBasicAttributes.Text = "Basic Attributes";
            // 
            // comboBoxCardType
            // 
            this.comboBoxCardType.FormattingEnabled = true;
            this.comboBoxCardType.Location = new System.Drawing.Point(105, 48);
            this.comboBoxCardType.Name = "comboBoxCardType";
            this.comboBoxCardType.Size = new System.Drawing.Size(110, 21);
            this.comboBoxCardType.TabIndex = 8;
            this.comboBoxCardType.SelectedValueChanged += new System.EventHandler(this.comboBoxCardType_SelectedValueChanged);
            // 
            // groupBoxSpecialAttributes
            // 
            this.groupBoxSpecialAttributes.Controls.Add(this.numericUpDownStructureMalus);
            this.groupBoxSpecialAttributes.Controls.Add(this.labelStructureMalus);
            this.groupBoxSpecialAttributes.Controls.Add(this.numericUpDownDistance);
            this.groupBoxSpecialAttributes.Controls.Add(this.labelDistance);
            this.groupBoxSpecialAttributes.Controls.Add(this.labelLocationType);
            this.groupBoxSpecialAttributes.Controls.Add(this.comboBoxLocationType);
            this.groupBoxSpecialAttributes.Controls.Add(this.checkBoxFlagship);
            this.groupBoxSpecialAttributes.Controls.Add(this.labelShipClass);
            this.groupBoxSpecialAttributes.Controls.Add(this.labelCapacity);
            this.groupBoxSpecialAttributes.Controls.Add(this.labelPower);
            this.groupBoxSpecialAttributes.Controls.Add(this.textBoxShipClass);
            this.groupBoxSpecialAttributes.Controls.Add(this.numericUpDownCapacity);
            this.groupBoxSpecialAttributes.Controls.Add(this.numericUpDownPower);
            this.groupBoxSpecialAttributes.Controls.Add(this.numericUpDownThreat);
            this.groupBoxSpecialAttributes.Controls.Add(this.labelThreat);
            this.groupBoxSpecialAttributes.Controls.Add(this.labelAffiliation);
            this.groupBoxSpecialAttributes.Controls.Add(this.comboBoxAffiliation);
            this.groupBoxSpecialAttributes.Location = new System.Drawing.Point(12, 228);
            this.groupBoxSpecialAttributes.Name = "groupBoxSpecialAttributes";
            this.groupBoxSpecialAttributes.Size = new System.Drawing.Size(600, 210);
            this.groupBoxSpecialAttributes.TabIndex = 9;
            this.groupBoxSpecialAttributes.TabStop = false;
            this.groupBoxSpecialAttributes.Text = "Special Attributes";
            // 
            // numericUpDownStructureMalus
            // 
            this.numericUpDownStructureMalus.Location = new System.Drawing.Point(93, 180);
            this.numericUpDownStructureMalus.Name = "numericUpDownStructureMalus";
            this.numericUpDownStructureMalus.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownStructureMalus.TabIndex = 22;
            // 
            // labelStructureMalus
            // 
            this.labelStructureMalus.AutoSize = true;
            this.labelStructureMalus.Location = new System.Drawing.Point(6, 182);
            this.labelStructureMalus.Name = "labelStructureMalus";
            this.labelStructureMalus.Size = new System.Drawing.Size(84, 13);
            this.labelStructureMalus.TabIndex = 21;
            this.labelStructureMalus.Text = "Structure Malus:";
            // 
            // numericUpDownDistance
            // 
            this.numericUpDownDistance.Location = new System.Drawing.Point(346, 154);
            this.numericUpDownDistance.Name = "numericUpDownDistance";
            this.numericUpDownDistance.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownDistance.TabIndex = 20;
            // 
            // labelDistance
            // 
            this.labelDistance.AutoSize = true;
            this.labelDistance.Location = new System.Drawing.Point(288, 156);
            this.labelDistance.Name = "labelDistance";
            this.labelDistance.Size = new System.Drawing.Size(52, 13);
            this.labelDistance.TabIndex = 19;
            this.labelDistance.Text = "Distance:";
            // 
            // labelLocationType
            // 
            this.labelLocationType.AutoSize = true;
            this.labelLocationType.Location = new System.Drawing.Point(6, 156);
            this.labelLocationType.Name = "labelLocationType";
            this.labelLocationType.Size = new System.Drawing.Size(78, 13);
            this.labelLocationType.TabIndex = 18;
            this.labelLocationType.Text = "Location Type:";
            // 
            // comboBoxLocationType
            // 
            this.comboBoxLocationType.FormattingEnabled = true;
            this.comboBoxLocationType.Location = new System.Drawing.Point(93, 153);
            this.comboBoxLocationType.Name = "comboBoxLocationType";
            this.comboBoxLocationType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxLocationType.TabIndex = 17;
            // 
            // checkBoxFlagship
            // 
            this.checkBoxFlagship.AutoSize = true;
            this.checkBoxFlagship.Location = new System.Drawing.Point(346, 129);
            this.checkBoxFlagship.Name = "checkBoxFlagship";
            this.checkBoxFlagship.Size = new System.Drawing.Size(86, 17);
            this.checkBoxFlagship.TabIndex = 16;
            this.checkBoxFlagship.Text = "Is A Flagship";
            this.checkBoxFlagship.UseVisualStyleBackColor = true;
            // 
            // labelShipClass
            // 
            this.labelShipClass.AutoSize = true;
            this.labelShipClass.Location = new System.Drawing.Point(6, 130);
            this.labelShipClass.Name = "labelShipClass";
            this.labelShipClass.Size = new System.Drawing.Size(59, 13);
            this.labelShipClass.TabIndex = 15;
            this.labelShipClass.Text = "Ship Class:";
            // 
            // labelCapacity
            // 
            this.labelCapacity.AutoSize = true;
            this.labelCapacity.Location = new System.Drawing.Point(6, 103);
            this.labelCapacity.Name = "labelCapacity";
            this.labelCapacity.Size = new System.Drawing.Size(51, 13);
            this.labelCapacity.TabIndex = 14;
            this.labelCapacity.Text = "Capacity:";
            // 
            // labelPower
            // 
            this.labelPower.AutoSize = true;
            this.labelPower.Location = new System.Drawing.Point(6, 77);
            this.labelPower.Name = "labelPower";
            this.labelPower.Size = new System.Drawing.Size(40, 13);
            this.labelPower.TabIndex = 13;
            this.labelPower.Text = "Power:";
            // 
            // textBoxShipClass
            // 
            this.textBoxShipClass.Location = new System.Drawing.Point(93, 127);
            this.textBoxShipClass.Name = "textBoxShipClass";
            this.textBoxShipClass.Size = new System.Drawing.Size(121, 20);
            this.textBoxShipClass.TabIndex = 12;
            // 
            // numericUpDownCapacity
            // 
            this.numericUpDownCapacity.Location = new System.Drawing.Point(94, 101);
            this.numericUpDownCapacity.Name = "numericUpDownCapacity";
            this.numericUpDownCapacity.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownCapacity.TabIndex = 10;
            // 
            // numericUpDownPower
            // 
            this.numericUpDownPower.Location = new System.Drawing.Point(94, 75);
            this.numericUpDownPower.Name = "numericUpDownPower";
            this.numericUpDownPower.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownPower.TabIndex = 9;
            // 
            // numericUpDownThreat
            // 
            this.numericUpDownThreat.Location = new System.Drawing.Point(94, 49);
            this.numericUpDownThreat.Name = "numericUpDownThreat";
            this.numericUpDownThreat.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownThreat.TabIndex = 8;
            // 
            // labelThreat
            // 
            this.labelThreat.AutoSize = true;
            this.labelThreat.Location = new System.Drawing.Point(6, 51);
            this.labelThreat.Name = "labelThreat";
            this.labelThreat.Size = new System.Drawing.Size(41, 13);
            this.labelThreat.TabIndex = 7;
            this.labelThreat.Text = "Threat:";
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(12, 444);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonAccept.TabIndex = 10;
            this.buttonAccept.Text = "Add Card";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(537, 444);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // CardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 479);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.groupBoxSpecialAttributes);
            this.Controls.Add(this.groupBoxBasicAttributes);
            this.Name = "CardForm";
            this.Text = "Add New Card";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewCardForm_FormClosing);
            this.groupBoxBasicAttributes.ResumeLayout(false);
            this.groupBoxBasicAttributes.PerformLayout();
            this.groupBoxSpecialAttributes.ResumeLayout(false);
            this.groupBoxSpecialAttributes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStructureMalus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelCardName;
        private System.Windows.Forms.TextBox textBoxCardName;
        private System.Windows.Forms.Label labelGameText;
        private System.Windows.Forms.TextBox textBoxGameText;
        private System.Windows.Forms.CheckBox checkBoxUnique;
        private System.Windows.Forms.Label labelAffiliation;
        private System.Windows.Forms.ComboBox comboBoxAffiliation;
        private System.Windows.Forms.Label labelCardType;
        private System.Windows.Forms.GroupBox groupBoxBasicAttributes;
        private System.Windows.Forms.ComboBox comboBoxCardType;
        private System.Windows.Forms.GroupBox groupBoxSpecialAttributes;
        private System.Windows.Forms.NumericUpDown numericUpDownThreat;
        private System.Windows.Forms.Label labelThreat;
        private System.Windows.Forms.NumericUpDown numericUpDownCapacity;
        private System.Windows.Forms.NumericUpDown numericUpDownPower;
        private System.Windows.Forms.Label labelShipClass;
        private System.Windows.Forms.Label labelCapacity;
        private System.Windows.Forms.Label labelPower;
        private System.Windows.Forms.TextBox textBoxShipClass;
        private System.Windows.Forms.CheckBox checkBoxFlagship;
        private System.Windows.Forms.NumericUpDown numericUpDownDistance;
        private System.Windows.Forms.Label labelDistance;
        private System.Windows.Forms.Label labelLocationType;
        private System.Windows.Forms.ComboBox comboBoxLocationType;
        private System.Windows.Forms.NumericUpDown numericUpDownStructureMalus;
        private System.Windows.Forms.Label labelStructureMalus;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonCancel;
    }
}