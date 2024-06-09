namespace NftGeneratorGui
{
    partial class FrmGenerate
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
            TcMain = new TabControl();
            tabPage1 = new TabPage();
            groupBox2 = new GroupBox();
            DgvTraits = new DataGridView();
            FileName = new DataGridViewTextBoxColumn();
            Rarity = new DataGridViewTextBoxColumn();
            groupBox1 = new GroupBox();
            BtnAttrDown = new Button();
            BtnAttrUp = new Button();
            BtnAttrRemove = new Button();
            groupBox4 = new GroupBox();
            TbxAttrNew = new TextBox();
            BtnAttrAdd = new Button();
            LbAttr = new ListBox();
            tabPage2 = new TabPage();
            panel2 = new Panel();
            label7 = new Label();
            groupBox7 = new GroupBox();
            BtnOtherDelete = new Button();
            groupBox8 = new GroupBox();
            BtnOtherAdd = new Button();
            label6 = new Label();
            label5 = new Label();
            TbxValueAttr = new TextBox();
            TbxTypeAttr = new TextBox();
            DgvOtherAttr = new DataGridView();
            AttributeType = new DataGridViewTextBoxColumn();
            AttributeValue = new DataGridViewTextBoxColumn();
            AttributeRarity = new DataGridViewTextBoxColumn();
            tabPage3 = new TabPage();
            label1 = new Label();
            groupBox3 = new GroupBox();
            groupBox6 = new GroupBox();
            TbxExternalLink = new TextBox();
            TbxCollDescription = new TextBox();
            TbxCollectionName = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            groupBox5 = new GroupBox();
            BtnExportPath = new Button();
            LblExportPath = new Label();
            PnlGenerateError = new Panel();
            BtnGenerateErrorCopy = new Button();
            BtnGenerateStart = new Button();
            LblGenerateProbability = new Label();
            label12 = new Label();
            groupBox10 = new GroupBox();
            label11 = new Label();
            BtnGenerateExistingPath = new Button();
            LblGenerateExistingPath = new Label();
            groupBox9 = new GroupBox();
            TbxGenerateCount = new TextBox();
            label9 = new Label();
            TbxGenerateStartId = new TextBox();
            label8 = new Label();
            LblGenerateStatus = new Label();
            PbGenerateProgress = new ProgressBar();
            tabPage4 = new TabPage();
            BtnSettingSave = new Button();
            BtnSettingLoad = new Button();
            LblGenerateError = new TextBox();
            TcMain.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvTraits).BeginInit();
            groupBox1.SuspendLayout();
            groupBox4.SuspendLayout();
            tabPage2.SuspendLayout();
            panel2.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvOtherAttr).BeginInit();
            tabPage3.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox5.SuspendLayout();
            PnlGenerateError.SuspendLayout();
            groupBox10.SuspendLayout();
            groupBox9.SuspendLayout();
            tabPage4.SuspendLayout();
            SuspendLayout();
            // 
            // TcMain
            // 
            TcMain.Controls.Add(tabPage1);
            TcMain.Controls.Add(tabPage2);
            TcMain.Controls.Add(tabPage3);
            TcMain.Controls.Add(tabPage4);
            TcMain.Dock = DockStyle.Fill;
            TcMain.Location = new Point(0, 0);
            TcMain.Name = "TcMain";
            TcMain.SelectedIndex = 0;
            TcMain.Size = new Size(765, 450);
            TcMain.TabIndex = 0;
            TcMain.SelectedIndexChanged += TcMain_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(757, 422);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Basics";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(DgvTraits);
            groupBox2.Dock = DockStyle.Left;
            groupBox2.Location = new Point(262, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(489, 416);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Traits Rarity";
            // 
            // DgvTraits
            // 
            DgvTraits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvTraits.Columns.AddRange(new DataGridViewColumn[] { FileName, Rarity });
            DgvTraits.Dock = DockStyle.Top;
            DgvTraits.Location = new Point(3, 19);
            DgvTraits.Name = "DgvTraits";
            DgvTraits.Size = new Size(483, 391);
            DgvTraits.TabIndex = 0;
            // 
            // FileName
            // 
            FileName.HeaderText = "File Name";
            FileName.Name = "FileName";
            FileName.ReadOnly = true;
            FileName.Width = 300;
            // 
            // Rarity
            // 
            Rarity.HeaderText = "Rarity";
            Rarity.Name = "Rarity";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BtnAttrDown);
            groupBox1.Controls.Add(BtnAttrUp);
            groupBox1.Controls.Add(BtnAttrRemove);
            groupBox1.Controls.Add(groupBox4);
            groupBox1.Controls.Add(LbAttr);
            groupBox1.Dock = DockStyle.Left;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(259, 416);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Attribute";
            // 
            // BtnAttrDown
            // 
            BtnAttrDown.Location = new Point(15, 390);
            BtnAttrDown.Name = "BtnAttrDown";
            BtnAttrDown.Size = new Size(227, 23);
            BtnAttrDown.TabIndex = 5;
            BtnAttrDown.Text = "Move down";
            BtnAttrDown.UseVisualStyleBackColor = true;
            // 
            // BtnAttrUp
            // 
            BtnAttrUp.Location = new Point(15, 365);
            BtnAttrUp.Name = "BtnAttrUp";
            BtnAttrUp.Size = new Size(227, 23);
            BtnAttrUp.TabIndex = 4;
            BtnAttrUp.Text = "Move up";
            BtnAttrUp.UseVisualStyleBackColor = true;
            // 
            // BtnAttrRemove
            // 
            BtnAttrRemove.Location = new Point(15, 254);
            BtnAttrRemove.Name = "BtnAttrRemove";
            BtnAttrRemove.Size = new Size(227, 23);
            BtnAttrRemove.TabIndex = 2;
            BtnAttrRemove.Text = "Remove Item";
            BtnAttrRemove.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(TbxAttrNew);
            groupBox4.Controls.Add(BtnAttrAdd);
            groupBox4.ForeColor = SystemColors.ControlText;
            groupBox4.Location = new Point(0, 280);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(259, 79);
            groupBox4.TabIndex = 1;
            groupBox4.TabStop = false;
            groupBox4.Text = "New item";
            // 
            // TbxAttrNew
            // 
            TbxAttrNew.Location = new Point(15, 22);
            TbxAttrNew.Name = "TbxAttrNew";
            TbxAttrNew.Size = new Size(227, 23);
            TbxAttrNew.TabIndex = 4;
            // 
            // BtnAttrAdd
            // 
            BtnAttrAdd.Location = new Point(15, 50);
            BtnAttrAdd.Name = "BtnAttrAdd";
            BtnAttrAdd.Size = new Size(227, 23);
            BtnAttrAdd.TabIndex = 3;
            BtnAttrAdd.Text = "Add Item";
            BtnAttrAdd.UseVisualStyleBackColor = true;
            // 
            // LbAttr
            // 
            LbAttr.Dock = DockStyle.Top;
            LbAttr.FormattingEnabled = true;
            LbAttr.ItemHeight = 15;
            LbAttr.Location = new Point(3, 19);
            LbAttr.Name = "LbAttr";
            LbAttr.Size = new Size(253, 229);
            LbAttr.TabIndex = 0;
            LbAttr.SelectedIndexChanged += LbAttr_SelectedIndexChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel2);
            tabPage2.Controls.Add(groupBox7);
            tabPage2.Controls.Add(DgvOtherAttr);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(757, 422);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Other Attr";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gray;
            panel2.Controls.Add(label7);
            panel2.ForeColor = SystemColors.AppWorkspace;
            panel2.Location = new Point(8, 7);
            panel2.Name = "panel2";
            panel2.Size = new Size(743, 407);
            panel2.TabIndex = 6;
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 14F);
            label7.ForeColor = SystemColors.ButtonHighlight;
            label7.Location = new Point(284, 160);
            label7.Name = "label7";
            label7.Size = new Size(154, 23);
            label7.TabIndex = 0;
            label7.Text = "Disable for now";
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(BtnOtherDelete);
            groupBox7.Controls.Add(groupBox8);
            groupBox7.Dock = DockStyle.Left;
            groupBox7.Location = new Point(3, 3);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(164, 416);
            groupBox7.TabIndex = 1;
            groupBox7.TabStop = false;
            groupBox7.Text = "Actions";
            // 
            // BtnOtherDelete
            // 
            BtnOtherDelete.Location = new Point(5, 178);
            BtnOtherDelete.Name = "BtnOtherDelete";
            BtnOtherDelete.Size = new Size(152, 40);
            BtnOtherDelete.TabIndex = 5;
            BtnOtherDelete.Text = "Delete";
            BtnOtherDelete.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(BtnOtherAdd);
            groupBox8.Controls.Add(label6);
            groupBox8.Controls.Add(label5);
            groupBox8.Controls.Add(TbxValueAttr);
            groupBox8.Controls.Add(TbxTypeAttr);
            groupBox8.Dock = DockStyle.Top;
            groupBox8.Location = new Point(3, 19);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(158, 150);
            groupBox8.TabIndex = 0;
            groupBox8.TabStop = false;
            groupBox8.Text = "Add";
            // 
            // BtnOtherAdd
            // 
            BtnOtherAdd.Location = new Point(16, 124);
            BtnOtherAdd.Name = "BtnOtherAdd";
            BtnOtherAdd.Size = new Size(122, 23);
            BtnOtherAdd.TabIndex = 4;
            BtnOtherAdd.Text = "Add";
            BtnOtherAdd.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(57, 77);
            label6.Name = "label6";
            label6.Size = new Size(35, 15);
            label6.TabIndex = 3;
            label6.Text = "Value";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(57, 26);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 2;
            label5.Text = "Type";
            // 
            // TbxValueAttr
            // 
            TbxValueAttr.Location = new Point(6, 95);
            TbxValueAttr.Name = "TbxValueAttr";
            TbxValueAttr.Size = new Size(146, 23);
            TbxValueAttr.TabIndex = 1;
            // 
            // TbxTypeAttr
            // 
            TbxTypeAttr.Location = new Point(6, 44);
            TbxTypeAttr.Name = "TbxTypeAttr";
            TbxTypeAttr.Size = new Size(146, 23);
            TbxTypeAttr.TabIndex = 0;
            // 
            // DgvOtherAttr
            // 
            DgvOtherAttr.AllowUserToDeleteRows = false;
            DgvOtherAttr.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvOtherAttr.Columns.AddRange(new DataGridViewColumn[] { AttributeType, AttributeValue, AttributeRarity });
            DgvOtherAttr.Dock = DockStyle.Right;
            DgvOtherAttr.Location = new Point(173, 3);
            DgvOtherAttr.Name = "DgvOtherAttr";
            DgvOtherAttr.Size = new Size(581, 416);
            DgvOtherAttr.TabIndex = 0;
            // 
            // AttributeType
            // 
            AttributeType.HeaderText = "Attribute Type";
            AttributeType.Name = "AttributeType";
            AttributeType.Width = 200;
            // 
            // AttributeValue
            // 
            AttributeValue.HeaderText = "Attribute Value";
            AttributeValue.Name = "AttributeValue";
            // 
            // AttributeRarity
            // 
            AttributeRarity.HeaderText = "Rarity";
            AttributeRarity.Name = "AttributeRarity";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label1);
            tabPage3.Controls.Add(groupBox3);
            tabPage3.Controls.Add(PnlGenerateError);
            tabPage3.Controls.Add(BtnGenerateStart);
            tabPage3.Controls.Add(LblGenerateProbability);
            tabPage3.Controls.Add(label12);
            tabPage3.Controls.Add(groupBox10);
            tabPage3.Controls.Add(groupBox9);
            tabPage3.Controls.Add(LblGenerateStatus);
            tabPage3.Controls.Add(PbGenerateProgress);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(757, 422);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Generate";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Location = new Point(441, 322);
            label1.Name = "label1";
            label1.Size = new Size(296, 35);
            label1.TabIndex = 12;
            label1.Text = "Version 1.0.0\r\n";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(groupBox6);
            groupBox3.Controls.Add(groupBox5);
            groupBox3.Location = new Point(209, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(226, 354);
            groupBox3.TabIndex = 11;
            groupBox3.TabStop = false;
            groupBox3.Text = "Setting";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(TbxExternalLink);
            groupBox6.Controls.Add(TbxCollDescription);
            groupBox6.Controls.Add(TbxCollectionName);
            groupBox6.Controls.Add(label4);
            groupBox6.Controls.Add(label3);
            groupBox6.Controls.Add(label2);
            groupBox6.Dock = DockStyle.Top;
            groupBox6.Location = new Point(3, 107);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(220, 254);
            groupBox6.TabIndex = 1;
            groupBox6.TabStop = false;
            groupBox6.Text = "General info";
            // 
            // TbxExternalLink
            // 
            TbxExternalLink.Location = new Point(3, 202);
            TbxExternalLink.Multiline = true;
            TbxExternalLink.Name = "TbxExternalLink";
            TbxExternalLink.Size = new Size(214, 37);
            TbxExternalLink.TabIndex = 5;
            // 
            // TbxCollDescription
            // 
            TbxCollDescription.Location = new Point(2, 97);
            TbxCollDescription.Multiline = true;
            TbxCollDescription.Name = "TbxCollDescription";
            TbxCollDescription.Size = new Size(214, 81);
            TbxCollDescription.TabIndex = 4;
            // 
            // TbxCollectionName
            // 
            TbxCollectionName.Location = new Point(6, 46);
            TbxCollectionName.Name = "TbxCollectionName";
            TbxCollectionName.Size = new Size(214, 23);
            TbxCollectionName.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(78, 184);
            label4.Name = "label4";
            label4.Size = new Size(71, 15);
            label4.TabIndex = 2;
            label4.Text = "External link";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 78);
            label3.Name = "label3";
            label3.Size = new Size(124, 15);
            label3.TabIndex = 1;
            label3.Text = "Collection Description";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(62, 28);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 0;
            label2.Text = "Collection Name";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(BtnExportPath);
            groupBox5.Controls.Add(LblExportPath);
            groupBox5.Dock = DockStyle.Top;
            groupBox5.Location = new Point(3, 19);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(220, 88);
            groupBox5.TabIndex = 0;
            groupBox5.TabStop = false;
            groupBox5.Text = "Export Path";
            // 
            // BtnExportPath
            // 
            BtnExportPath.Dock = DockStyle.Bottom;
            BtnExportPath.Location = new Point(3, 62);
            BtnExportPath.Name = "BtnExportPath";
            BtnExportPath.Size = new Size(214, 23);
            BtnExportPath.TabIndex = 1;
            BtnExportPath.Text = "Export Path";
            BtnExportPath.UseVisualStyleBackColor = true;
            // 
            // LblExportPath
            // 
            LblExportPath.Dock = DockStyle.Top;
            LblExportPath.Location = new Point(3, 19);
            LblExportPath.Name = "LblExportPath";
            LblExportPath.Size = new Size(214, 37);
            LblExportPath.TabIndex = 0;
            LblExportPath.Text = "default path";
            // 
            // PnlGenerateError
            // 
            PnlGenerateError.Controls.Add(LblGenerateError);
            PnlGenerateError.Controls.Add(BtnGenerateErrorCopy);
            PnlGenerateError.Location = new Point(441, 122);
            PnlGenerateError.Name = "PnlGenerateError";
            PnlGenerateError.Size = new Size(296, 197);
            PnlGenerateError.TabIndex = 10;
            PnlGenerateError.Visible = false;
            // 
            // BtnGenerateErrorCopy
            // 
            BtnGenerateErrorCopy.Location = new Point(100, 174);
            BtnGenerateErrorCopy.Name = "BtnGenerateErrorCopy";
            BtnGenerateErrorCopy.Size = new Size(85, 23);
            BtnGenerateErrorCopy.TabIndex = 9;
            BtnGenerateErrorCopy.Text = "Copy";
            BtnGenerateErrorCopy.UseVisualStyleBackColor = true;
            // 
            // BtnGenerateStart
            // 
            BtnGenerateStart.Location = new Point(494, 31);
            BtnGenerateStart.Name = "BtnGenerateStart";
            BtnGenerateStart.Size = new Size(206, 79);
            BtnGenerateStart.TabIndex = 6;
            BtnGenerateStart.Text = "Generate";
            BtnGenerateStart.UseVisualStyleBackColor = true;
            // 
            // LblGenerateProbability
            // 
            LblGenerateProbability.BackColor = Color.Silver;
            LblGenerateProbability.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            LblGenerateProbability.Location = new Point(9, 319);
            LblGenerateProbability.Name = "LblGenerateProbability";
            LblGenerateProbability.Size = new Size(188, 23);
            LblGenerateProbability.TabIndex = 5;
            LblGenerateProbability.Text = "0 NFT";
            LblGenerateProbability.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            label12.Location = new Point(14, 296);
            label12.Name = "label12";
            label12.Size = new Size(183, 23);
            label12.TabIndex = 4;
            label12.Text = "Probability";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox10
            // 
            groupBox10.Controls.Add(label11);
            groupBox10.Controls.Add(BtnGenerateExistingPath);
            groupBox10.Controls.Add(LblGenerateExistingPath);
            groupBox10.Location = new Point(3, 137);
            groupBox10.Name = "groupBox10";
            groupBox10.Size = new Size(200, 151);
            groupBox10.TabIndex = 3;
            groupBox10.TabStop = false;
            groupBox10.Text = "Existing Meta";
            // 
            // label11
            // 
            label11.Location = new Point(6, 93);
            label11.Name = "label11";
            label11.Size = new Size(188, 55);
            label11.TabIndex = 8;
            label11.Text = "Generator will check metadata in selected folder to not generate dupplicate NFT";
            // 
            // BtnGenerateExistingPath
            // 
            BtnGenerateExistingPath.Location = new Point(6, 67);
            BtnGenerateExistingPath.Name = "BtnGenerateExistingPath";
            BtnGenerateExistingPath.Size = new Size(188, 23);
            BtnGenerateExistingPath.TabIndex = 2;
            BtnGenerateExistingPath.Text = "Select Folder";
            BtnGenerateExistingPath.UseVisualStyleBackColor = true;
            // 
            // LblGenerateExistingPath
            // 
            LblGenerateExistingPath.Dock = DockStyle.Top;
            LblGenerateExistingPath.Location = new Point(3, 19);
            LblGenerateExistingPath.Name = "LblGenerateExistingPath";
            LblGenerateExistingPath.Size = new Size(194, 45);
            LblGenerateExistingPath.TabIndex = 1;
            // 
            // groupBox9
            // 
            groupBox9.Controls.Add(TbxGenerateCount);
            groupBox9.Controls.Add(label9);
            groupBox9.Controls.Add(TbxGenerateStartId);
            groupBox9.Controls.Add(label8);
            groupBox9.Location = new Point(3, 3);
            groupBox9.Name = "groupBox9";
            groupBox9.Size = new Size(200, 128);
            groupBox9.TabIndex = 2;
            groupBox9.TabStop = false;
            groupBox9.Text = "Generate Setting";
            // 
            // TbxGenerateCount
            // 
            TbxGenerateCount.Location = new Point(4, 89);
            TbxGenerateCount.Name = "TbxGenerateCount";
            TbxGenerateCount.Size = new Size(190, 23);
            TbxGenerateCount.TabIndex = 7;
            TbxGenerateCount.Text = "1000";
            TbxGenerateCount.TextAlign = HorizontalAlignment.Center;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(71, 71);
            label9.Name = "label9";
            label9.Size = new Size(40, 15);
            label9.TabIndex = 6;
            label9.Text = "Count";
            // 
            // TbxGenerateStartId
            // 
            TbxGenerateStartId.Location = new Point(4, 43);
            TbxGenerateStartId.Name = "TbxGenerateStartId";
            TbxGenerateStartId.Size = new Size(190, 23);
            TbxGenerateStartId.TabIndex = 5;
            TbxGenerateStartId.Text = "0";
            TbxGenerateStartId.TextAlign = HorizontalAlignment.Center;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(62, 25);
            label8.Name = "label8";
            label8.Size = new Size(62, 15);
            label8.TabIndex = 4;
            label8.Text = "Starting ID";
            // 
            // LblGenerateStatus
            // 
            LblGenerateStatus.Dock = DockStyle.Bottom;
            LblGenerateStatus.Location = new Point(0, 360);
            LblGenerateStatus.Name = "LblGenerateStatus";
            LblGenerateStatus.Size = new Size(757, 32);
            LblGenerateStatus.TabIndex = 1;
            LblGenerateStatus.Text = "...";
            LblGenerateStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PbGenerateProgress
            // 
            PbGenerateProgress.Dock = DockStyle.Bottom;
            PbGenerateProgress.Location = new Point(0, 392);
            PbGenerateProgress.Name = "PbGenerateProgress";
            PbGenerateProgress.Size = new Size(757, 30);
            PbGenerateProgress.TabIndex = 0;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(BtnSettingSave);
            tabPage4.Controls.Add(BtnSettingLoad);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(757, 422);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Settings";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // BtnSettingSave
            // 
            BtnSettingSave.Location = new Point(440, 142);
            BtnSettingSave.Name = "BtnSettingSave";
            BtnSettingSave.Size = new Size(174, 98);
            BtnSettingSave.TabIndex = 1;
            BtnSettingSave.Text = "Save";
            BtnSettingSave.UseVisualStyleBackColor = true;
            // 
            // BtnSettingLoad
            // 
            BtnSettingLoad.Location = new Point(120, 142);
            BtnSettingLoad.Name = "BtnSettingLoad";
            BtnSettingLoad.Size = new Size(174, 98);
            BtnSettingLoad.TabIndex = 0;
            BtnSettingLoad.Text = "Load";
            BtnSettingLoad.UseVisualStyleBackColor = true;
            // 
            // LblGenerateError
            // 
            LblGenerateError.BackColor = Color.RosyBrown;
            LblGenerateError.Dock = DockStyle.Top;
            LblGenerateError.Location = new Point(0, 0);
            LblGenerateError.Multiline = true;
            LblGenerateError.Name = "LblGenerateError";
            LblGenerateError.ReadOnly = true;
            LblGenerateError.ScrollBars = ScrollBars.Vertical;
            LblGenerateError.Size = new Size(296, 166);
            LblGenerateError.TabIndex = 10;
            // 
            // FrmGenerate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(765, 450);
            Controls.Add(TcMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmGenerate";
            Text = "Nft Generator";
            Load += FrmGenerate_Load;
            TcMain.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvTraits).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            tabPage2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvOtherAttr).EndInit();
            tabPage3.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox5.ResumeLayout(false);
            PnlGenerateError.ResumeLayout(false);
            PnlGenerateError.PerformLayout();
            groupBox10.ResumeLayout(false);
            groupBox9.ResumeLayout(false);
            groupBox9.PerformLayout();
            tabPage4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl TcMain;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private Button BtnAttrRemove;
        private GroupBox groupBox4;
        private ListBox LbAttr;
        private DataGridView DgvTraits;
        private Button BtnAttrDown;
        private Button BtnAttrUp;
        private TextBox TbxAttrNew;
        private Button BtnAttrAdd;
        private DataGridView DgvOtherAttr;
        private GroupBox groupBox7;
        private GroupBox groupBox8;
        private Button BtnOtherDelete;
        private Button BtnOtherAdd;
        private Label label6;
        private Label label5;
        private TextBox TbxValueAttr;
        private TextBox TbxTypeAttr;
        private Label LblGenerateStatus;
        private ProgressBar PbGenerateProgress;
        private GroupBox groupBox10;
        private GroupBox groupBox9;
        private Button BtnGenerateExistingPath;
        private Label LblGenerateExistingPath;
        private TextBox TbxGenerateCount;
        private Label label9;
        private TextBox TbxGenerateStartId;
        private Label label8;
        private Label label11;
        private Label label12;
        private Label LblGenerateProbability;
        private Button BtnGenerateStart;
        private Panel PnlGenerateError;
        private Button BtnGenerateErrorCopy;
        private GroupBox groupBox3;
        private GroupBox groupBox6;
        private TextBox TbxExternalLink;
        private TextBox TbxCollDescription;
        private TextBox TbxCollectionName;
        private Label label4;
        private Label label3;
        private Label label2;
        private GroupBox groupBox5;
        private Button BtnExportPath;
        private Label LblExportPath;
        private DataGridViewTextBoxColumn FileName;
        private DataGridViewTextBoxColumn Rarity;
        private DataGridViewTextBoxColumn AttributeType;
        private DataGridViewTextBoxColumn AttributeValue;
        private DataGridViewTextBoxColumn AttributeRarity;
        private TabPage tabPage4;
        private Button BtnSettingSave;
        private Button BtnSettingLoad;
        private Label label1;
        private Panel panel2;
        private Label label7;
        private TextBox LblGenerateError;
    }
}
