using NftGeneratorGui.Enums;
using NftGeneratorGui.Factory;
using NftGeneratorGui.Models;
using NftGeneratorGui.Tools;
using NftGeneratorGui.ViewModels;
using System.Diagnostics;
using System.Net;
using System.Numerics;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace NftGeneratorGui
{
    public partial class FrmGenerate : Form
    {

        NftGenerator Generator;
        Dictionary<string, Dictionary<string, int>> AttributesRarityList = new Dictionary<string, Dictionary<string, int>>();
        Dictionary<string, Dictionary<string, int>> OtherAttributesRarityList = new Dictionary<string, Dictionary<string, int>>();
        string ExistingMetaPath = "";
        string ExportNftPath = "";

        public FrmGenerate()
        {
            InitializeComponent();
        }

        private void FrmGenerate_Load(object sender, EventArgs e)
        {
            InitTabBasics();
            InitTabOtherAttr();
            InitTabGenerate();
            InitTabSettings();

        }


        private void InitTabBasics()
        {
            BtnAttrAdd.Click += BtnAttrAdd_Click;
            BtnAttrDown.Click += BtnAttrDown_Click;
            BtnAttrUp.Click += BtnAttrUp_Click;
            BtnAttrRemove.Click += BtnAttrRemove_Click;
            DgvTraits.CellValueChanged += DgvTraits_CellValueChanged;
        }



        private void InitTabOtherAttr()
        {

        }

        private void InitTabGenerate()
        {
            //TcMain.TabIndexChanged += TcMain_TabIndexChanged;
            BtnGenerateStart.Click += BtnGenerateStart_Click;
            BtnGenerateErrorCopy.Click += BtnGenerateErrorCopy_Click;
            BtnExportPath.Click += BtnExportPath_Click;
            BtnGenerateExistingPath.Click += BtnGenerateExistingPath_Click;

        }



        private void InitTabSettings()
        {
            BtnSettingLoad.Click += BtnSettingLoad_Click;
            BtnSettingSave.Click += BtnSettingSave_Click;
        }



        #region >>> Tab Basics
        private void BtnAttrRemove_Click(object? sender, EventArgs e)
        {
            if (LbAttr.SelectedIndex != -1)
            {
                var thisitem = (CustomListBoxItem)LbAttr.SelectedItem;
                if (AttributesRarityList.ContainsKey(thisitem.Text))
                {
                    AttributesRarityList.Remove(thisitem.Text);
                }
                LbAttr.Items.RemoveAt(LbAttr.SelectedIndex);
            }
        }

        private void DgvTraits_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            if (e.ColumnIndex < 0) { return; }

            var row = DgvTraits.Rows[e.RowIndex];
            if (row == null) { return; }
            if (LbAttr.SelectedIndex == -1) { return; }

            var traitname = row.Cells[0].Value.ToString();
            var rarity = -1;
            var validrarity = int.TryParse(row.Cells[1].Value.ToString(), out rarity);
            if (validrarity == false) { return; }

            var selectedattr = (CustomListBoxItem)LbAttr.Items[LbAttr.SelectedIndex];
            var attrname = selectedattr.Text;
            if (rarity == -1 &&
                AttributesRarityList.ContainsKey(attrname) &&
                AttributesRarityList[attrname].ContainsKey(traitname))
            {
                AttributesRarityList[attrname].Remove(attrname);
                return;
            }
            else
            if (AttributesRarityList.ContainsKey(attrname) == false)
            {
                AttributesRarityList.Add(attrname, new Dictionary<string, int>());
                AttributesRarityList[attrname][traitname] = rarity;
                return;
            }
            else
            {
                AttributesRarityList[attrname][traitname] = rarity;
            }

        }

        private void BtnAttrUp_Click(object? sender, EventArgs e)
        {
            UiUtils.ShiftListBoxItem(LbAttr, -1);
        }

        private void BtnAttrDown_Click(object? sender, EventArgs e)
        {
            UiUtils.ShiftListBoxItem(LbAttr, 1);
        }

        private void BtnAttrAdd_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TbxAttrNew.Text))
            {
                MessageBox.Show("Attribute name is empty");
                return;
            }

            string attname = TbxAttrNew.Text.Trim();
            string folderpath = "";

            bool itemExists = LbAttr.Items.Cast<CustomListBoxItem>().Any(item => item.Text == attname);
            if (itemExists)
            {
                MessageBox.Show("An item with same name already exists");
                return;
            }

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();


            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                folderpath = folderBrowserDialog.SelectedPath;
            }
            else
            {
                MessageBox.Show("No folder selected on it's empty");
                return;
            }

            var item = new CustomListBoxItem(attname, folderpath);
            LbAttr.Items.Add(item);
            AttributesRarityList.Add(item.Text, new Dictionary<string, int>());
            LbAttr.SelectedIndex = LbAttr.Items.Count - 1;
            TbxAttrNew.Text = "";
        }

        private void LbAttr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LbAttr.SelectedIndex == -1) { return; }
            DgvTraits.Rows.Clear();

            var selecteditem = (CustomListBoxItem)LbAttr.SelectedItem;

            var TraitsAddress = Directory.GetFiles(selecteditem.Tag.ToString());
            foreach (var traitaddr in TraitsAddress)
            {
                var thisfilename = Path.GetFileNameWithoutExtension(traitaddr);
                var traitweight = -1;

                // check if rarity of this trait is modified
                if (AttributesRarityList.ContainsKey(selecteditem.Text))
                {
                    if (AttributesRarityList[selecteditem.Text].ContainsKey(thisfilename))
                    {
                        traitweight = AttributesRarityList[selecteditem.Text][thisfilename];
                    }
                }

                var newrows = new string[] { thisfilename, traitweight.ToString() };
                DgvTraits.Rows.Add(newrows);
            }
        }

        #endregion

        #region >>> Tab Other Attribute

        #endregion

        #region >>> Tab Generate 

        private void BtnGenerateExistingPath_Click(object sender, EventArgs e)
        {
            // Create an instance of FolderBrowserDialog
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                // Show the dialog and check if the user clicked OK
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    // User selected a folder
                    string selectedFolder = folderBrowserDialog.SelectedPath;
                    ExistingMetaPath = selectedFolder;
                    LblGenerateExistingPath.Text = selectedFolder;
                }
                else
                {
                }
            }
        }

        private void BtnExportPath_Click(object sender, EventArgs e)
        {
            // Create an instance of FolderBrowserDialog
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                // Show the dialog and check if the user clicked OK
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    // User selected a folder
                    string selectedFolder = folderBrowserDialog.SelectedPath;
                    ExportNftPath = selectedFolder;
                    LblExportPath.Text = selectedFolder;
                }
                else
                {
                }
            }
        }

        private void BtnGenerateErrorCopy_Click(object sender, EventArgs e)
        {
            if (LblGenerateError.Text.Length == 0) { return; }
            Clipboard.SetText(LblGenerateError.Text);
        }

        private void BtnGenerateStart_Click(object sender, EventArgs e)
        {
            ErrorHide();

            var inputvalidation = ValidateGenerateInput();
            if (inputvalidation.Success == false)
            {
                ErrorShow(inputvalidation.error.Message);
                return;
            }

            Generator = new NftGenerator();
            Generator.SetNftSetting(GetGenerateSetting());
            Generator.SetNftAttribute(GetNftAttributeData());
            Generator.SetNftAttributePathDirectory(GetAttrPathDirectory());
            InitTimer();
        }

        private void TcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TcMain.SelectedIndex != 2) { return; }
            var nftdata = GetNftAttributeData();
            var prob = Otherutils.CalculateMaxProbabilites(nftdata);
            LblGenerateProbability.Text = prob + " NFT";
        }

        #endregion

        #region >>> Tab Setting

        private void BtnSettingSave_Click(object sender, EventArgs e)
        {
            // Create a new instance of the SaveFileDialog class
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            // Set the file filter and default file extension
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.DefaultExt = "txt";

            // Display the dialog box and get the result
            DialogResult result = saveFileDialog1.ShowDialog();

            // If the user clicked the OK button, save the file
            if (result != DialogResult.OK) { return; }

            // Get the file name and path from the dialog box
            string fileName = saveFileDialog1.FileName;

            var Nftsetting = new NftSettings();
            Nftsetting.AttributesRarityList = AttributesRarityList;
            Nftsetting.OtherAttributesRarityList = OtherAttributesRarityList;
            Nftsetting.GenerateSetting.Add(Enums.GenerateSetting.CollectionName, TbxCollectionName.Text);
            Nftsetting.GenerateSetting.Add(Enums.GenerateSetting.CollectionDescription, TbxCollDescription.Text);
            Nftsetting.GenerateSetting.Add(Enums.GenerateSetting.CollectionExternalLink, TbxExternalLink.Text);
            Nftsetting.GenerateSetting.Add(Enums.GenerateSetting.Count, TbxGenerateCount.Text);
            Nftsetting.GenerateSetting.Add(Enums.GenerateSetting.StartingFrom, TbxGenerateStartId.Text);
            Nftsetting.GenerateSetting.Add(Enums.GenerateSetting.ExistingMetaData, ExistingMetaPath);
            Nftsetting.GenerateSetting.Add(Enums.GenerateSetting.ExportPath, ExportNftPath);

            foreach (CustomListBoxItem item in LbAttr.Items)
            {
                Nftsetting.AttributeList.Add(item.Text, item.Tag.ToString());
            }


            var saveresult = Nftsetting.Save(fileName);
            if (saveresult.Success)
            {
                MessageBox.Show("Operation was successful");
            }
            else
            {
                MessageBox.Show("Nope \n" + saveresult.error.Message);
            }


        }

        private void BtnSettingLoad_Click(object sender, EventArgs e)
        {

            // Create a new instance of the OpenFileDialog class
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set the file filter and default file extension
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.DefaultExt = "txt";

            // Set the dialog to allow selecting a single file
            openFileDialog1.Multiselect = false;

            // Display the dialog box and get the result
            DialogResult result = openFileDialog1.ShowDialog();

            // If the user clicked the OK button, open the file
            if (result != DialogResult.OK) { return; }

            // Get the file name and path from the dialog box
            string fileName = openFileDialog1.FileName;

            var loadedsetting = new NftSettings();
            var loadresult = loadedsetting.Load(fileName);
            if (loadresult.Success)
            {
                MessageBox.Show("Operation was successful");
            }
            else
            {
                MessageBox.Show("Nope \n" + loadresult.error.Message);
                return;
            }

            LoadSettingContent(loadedsetting);
        }

        private void LoadSettingContent(NftSettings setting)
        {
            AttributesRarityList = setting.AttributesRarityList;
            OtherAttributesRarityList = setting.OtherAttributesRarityList;

            TbxCollectionName.Text = setting.GenerateSetting[Enums.GenerateSetting.CollectionName].ToString();
            TbxCollDescription.Text = setting.GenerateSetting[Enums.GenerateSetting.CollectionDescription].ToString();
            TbxExternalLink.Text = setting.GenerateSetting[Enums.GenerateSetting.CollectionExternalLink].ToString();
            TbxGenerateCount.Text = setting.GenerateSetting[Enums.GenerateSetting.Count].ToString();
            TbxGenerateStartId.Text = setting.GenerateSetting[Enums.GenerateSetting.StartingFrom].ToString();
            ExportNftPath = setting.GenerateSetting[Enums.GenerateSetting.ExportPath].ToString();
            ExistingMetaPath = setting.GenerateSetting[Enums.GenerateSetting.ExistingMetaData].ToString();

            LbAttr.Items.Clear();
            foreach (var item in setting.AttributeList)
            {
                var lbitem = new CustomListBoxItem(item.Key, item.Value);
                LbAttr.Items.Add(lbitem);
            }
        }

        #endregion


        #region >>> Generator util functions

        private Dictionary<string, Dictionary<string, int>> GetNftAttributeData()
        {
            var result = new Dictionary<string, Dictionary<string, int>>(AttributesRarityList);
            foreach (var item in LbAttr.Items)
            {
                var lbitem = (CustomListBoxItem)item;
                if (result.ContainsKey(lbitem.Text) == false) { result.Add(lbitem.Text, new Dictionary<string, int>()); }
                var TraitItems = Directory.GetFiles(lbitem.Tag.ToString());
                TraitItems = TraitItems.Select(ti => Path.GetFileNameWithoutExtension(ti)).ToArray();

                result[lbitem.Text] = result[lbitem.Text]
                    .Where(kv => TraitItems.Contains(kv.Key))
                        .ToDictionary(kv => kv.Key, kv => kv.Value);

                foreach (var filename in TraitItems)
                {
                    if (result[lbitem.Text].ContainsKey(filename) == false)
                    {
                        result[lbitem.Text].Add(filename, -1);
                    }
                }
            }

            return result;
        }

        private Dictionary<string,string> GetAttrPathDirectory()
        {
            var result = new Dictionary<string, string>();

            return result;
        }

        private Dictionary<GenerateSetting,object> GetGenerateSetting()
        {
            var result = new Dictionary<GenerateSetting, object>();

            return result;
        }

        private ActionResult ValidateGenerateInput()
        {
            if (LbAttr.Items.Count == 0) { new ActionResult(false, new Exception("Add some attributes")); }

            if (string.IsNullOrEmpty(TbxCollectionName.Text.Trim()))
            { new ActionResult(false, new Exception("Collection name is empty")); }

            if (string.IsNullOrEmpty(TbxCollDescription.Text.Trim()))
            { new ActionResult(false, new Exception("Collection name is empty")); }

            if (string.IsNullOrEmpty(TbxCollectionName.Text.Trim()))
            { new ActionResult(false, new Exception("Collection description is empty")); }

            if (string.IsNullOrEmpty(TbxGenerateCount.Text.Trim()))
            { new ActionResult(false, new Exception("Collection count is empty")); }

            if (string.IsNullOrEmpty(TbxGenerateStartId.Text.Trim()))
            { new ActionResult(false, new Exception("Collection starting id is empty")); }

            if (UiUtils.IsValidInt(TbxGenerateCount.Text.Trim()) == false)
            { new ActionResult(false, new Exception("Collection count is invalid")); }

            if (UiUtils.IsValidInt(TbxGenerateStartId.Text.Trim()) == false)
            { new ActionResult(false, new Exception("Collection starting id is invalid")); }

            var nftdata = GetNftAttributeData();
            var prob = Otherutils.CalculateMaxProbabilites(nftdata);
            var nftcounts = int.Parse(TbxGenerateCount.Text.Trim());
            if (nftcounts > prob) { new ActionResult(false, new Exception("Nft probability is smaller than counts you want!")); }

            return new ActionResult(true, null);
        }


        #endregion

        #region Ui functions

        private void ErrorShow(string text)
        {
            PnlGenerateError.Visible = true;
            LblGenerateError.Text = text;
        }

        private void ErrorHide()
        {
            PnlGenerateError.Visible = false;
        }

        private void InitTimer()
        {
            var timticking = new System.Windows.Forms.Timer();

        }

        #endregion
    }
}
