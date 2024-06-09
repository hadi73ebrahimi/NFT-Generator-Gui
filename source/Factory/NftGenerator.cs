using NftGeneratorGui.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NftGeneratorGui.Tools;
using System.Xml.Linq;
using System.Drawing.Imaging;
using System.Reflection.Metadata;
using static System.Windows.Forms.LinkLabel;
using NftGeneratorGui.Models;
using System.Security.Cryptography;
using NftGeneratorGui.ViewModels;
namespace NftGeneratorGui.Factory
{

    public sealed class NftGenerator
    {
        public int CompletedProgress { get; private set; }
        public int TotalProgress { get; private set; }
        public string Status { get; private set; }

        Dictionary<GenerateSetting, object> NftSetting;

        Dictionary<string, Dictionary<string, int>> NftAttribute;
        Dictionary<string, string> NftAttributePath;

        IEnumerable<NftMetadata> FinalProducedMeta;

        public List<string> Errors { get; private set; }

        public NftGenerator()
        {
            Errors = new();
        }

        public void SetNftSetting(Dictionary<GenerateSetting,object> setting)
        {
            NftSetting = setting;
        }

        public void SetNftAttributePathDirectory(Dictionary<string, string> attrpath)
        {
            NftAttributePath = attrpath;
        }

        public void SetNftAttribute(Dictionary<string, Dictionary<string, int>> nftattr)
        {
            NftAttribute = nftattr;
        }

        public void Generate()
        {
            BeginOperation();


        }

        private void BeginOperation()
        {
            ProduceNfts();
            ProduceImages();
            ProduceMetadata();
            
        }

        private void ProduceNfts()
        {

            SetStatus("Producing metadata");

            bool RarityCompliance = false;
            while (RarityCompliance==false)
            {
                
                var allattributes = _GenerateAttributeList();
                if (allattributes.Count == 0) { continue; }
                var forgednfts = _NewForgeNftMetadata(allattributes);
                FinalProducedMeta = forgednfts;
                RarityCompliance = true;
            }

        }

        private async void ProduceImages()
        {
            var NftStartingId = (int)NftSetting[GenerateSetting.StartingFrom];
            int nftindex = NftStartingId;
            foreach (var nft in FinalProducedMeta)
            {
                List<string> pathlist = new List<string>();
                foreach (var trait in nft.attributes)
                {
                    if (NftAttributePath.ContainsKey(trait.trait_type) == false) { continue; }
                    string dirpath = NftAttributePath[trait.trait_type];
                    var allfiles = Directory.GetFiles(dirpath);
                    var filepath = allfiles.FirstOrDefault(filepath =>
                        Path.GetFileNameWithoutExtension(filepath) == trait.value);

                    if (filepath != null) { pathlist.Add(filepath); }
                    
                }

                MergeAndSaveImage(pathlist, nftindex);
                CompletedProgress++;
                nftindex++;
                await Task.Delay(1000);
            }
        }

        private async void ProduceMetadata()
        {
            var NftStartingId = (int)NftSetting[GenerateSetting.StartingFrom];
            var NftExport = NftSetting[GenerateSetting.ExportPath].ToString();
            int nftindex = NftStartingId;
            foreach (var nft in FinalProducedMeta)
            {

                var finaljson = JsonConvert.SerializeObject(nft);
                File.WriteAllText(NftExport + nftindex + ".json", finaljson);
                CompletedProgress++;
                nftindex++;
                await Task.Delay(10);
            }
        }

        private void MergeAndSaveImage(List<string> filepaths, int nftindex)
        {
            bool isdone = false;
            string lastimg = "";
            var NftExport = NftSetting[GenerateSetting.ExportPath].ToString();
            while (isdone == false)
            {
                try
                {

                    using (var baseimage = new Bitmap(filepaths[0]))
                    {
                        var drawbitmap = new Bitmap(baseimage.Width, baseimage.Height, PixelFormat.Format32bppRgb);
                        drawbitmap.SetResolution(120f, 120f);
                        using (var g = Graphics.FromImage(drawbitmap))
                        {
                            foreach (var imagepath in filepaths)
                            {
                                lastimg = imagepath;
                                using (var thisimg = Bitmap.FromFile(imagepath))
                                {
                                    using (var newbmp = new Bitmap(thisimg))
                                    {
                                        newbmp.SetResolution(120f, 120f);
                                        g.DrawImage(newbmp, 0, 0);
                                    }
                                }
                            }
                        }

                        drawbitmap.Save(NftExport + nftindex + ".jpg", ImageFormat.Jpeg);
                    }
                    isdone = true;
                }
                catch (Exception ex)
                {
                }
            }

        }

        private string[] _GetExistingMetaHashes()
        {
            var result = new List<string>();
            if (NftSetting.ContainsKey(GenerateSetting.ExistingMetaData)==false) { return []; }
            var existinglink = (string)NftSetting[GenerateSetting.ExistingMetaData];
            var files = Directory.GetFiles(existinglink,"*.json");
            foreach (var item in files)
            {
                var jsoncontent = File.ReadAllText(item);
                try
                {
                    var Nftobj = JsonConvert.DeserializeObject<NftMetadata>(jsoncontent);
                    var jsonattributes = JsonConvert.SerializeObject(Nftobj.attributes);
                    result.Add(GetSHA1Hash(jsonattributes));
                }
                catch (Exception ex)
                {
                    AddError(ex.Message);
                }
            }

            return result.ToArray();
        }

        private void AddError(string msg)
        {
            Errors.Add(msg);
        }

        private static string GetSHA1Hash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha1.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        private void SetStatus(string msg)
        {
            Status = msg;
        }

        private NftMetadata[] _NewForgeNftMetadata(List<IEnumerable<MetadataAttributes>> allattributes)
        {

            string NftName = NftSetting[GenerateSetting.CollectionName].ToString();
            string NftWebsite = NftSetting[GenerateSetting.CollectionExternalLink].ToString();
            string NftDesc = NftSetting[GenerateSetting.CollectionDescription].ToString();
            var NftCounts = (int)NftSetting[GenerateSetting.Count];
            var NftStartingId = (int)NftSetting[GenerateSetting.StartingFrom];

            var producedHashes = new List<string>();
            var ProducedMeta = new List<NftMetadata>(NftCounts);

            int nftidnex = 0;


            foreach (var attrrow in allattributes)
            {
                var generatedattr = attrrow;


                var newid = NftStartingId + nftidnex;
                var newname = NftName.Replace("{id}", newid.ToString());
                var newllink = NftWebsite.Replace("{id}", newid.ToString());
                var imglink = string.Format("imageipfshash/{0}.jpg", newid);
                var newnft = new NftMetadata(newname, NftDesc, imglink, newllink, generatedattr);

                ProducedMeta.Add(newnft);

                nftidnex++;
            }

            return ProducedMeta.ToArray();
        }

        private List<IEnumerable<MetadataAttributes>> _GenerateAttributeList()
        {
            var AttrMap = new Dictionary<string, Dictionary<string, int>>(NftAttribute);
            var result = new List<IEnumerable<MetadataAttributes>>();
            var producedHashes = new List<string>();
            var oldHashes = _GetExistingMetaHashes();
            var NftCounts = (int)NftSetting[GenerateSetting.Count];
            while (result.Count < NftCounts)
            {
                var generatedattr = _GenerateRandomAttributes(AttrMap);

                var attrjson = JsonConvert.SerializeObject(generatedattr);
                var attrhash = GetSHA1Hash(attrjson);

                if (producedHashes.IndexOf(attrhash) > -1) { continue; }
                if (oldHashes.Count(it => it == attrhash) > 0) { continue; }

                result.Add(generatedattr);
            }
            // if rarity is not complete then clean all to start over
            var cleanrarity = AttrMap.Any(innerDict => innerDict.Value.Any(value => value.Value > 0));
            if (cleanrarity == false) { result.Clear(); }

            return result;
        }

        private List<MetadataAttributes> _GenerateRandomAttributes(Dictionary<string, Dictionary<string, int>> AttrMap)
        {
            var result = new List<MetadataAttributes>();
            
            var RndTraitSelector = new Random();
            foreach (var attr in AttrMap)
            {

                var AllTraits = attr.Value;
                var veryraretraits = AllTraits.Where(it=> it.Value>0).ToDictionary();
                var commontraits = AllTraits.Where(it => it.Value == -1).ToDictionary();

                if (commontraits.Count == 0 && veryraretraits.Count == 0) { continue; }

                var consider_rare = (veryraretraits.Count > 0 && commontraits.Count > 0);
                var availabletraits = new List<string>();
                if (consider_rare)
                {
                    availabletraits.AddRange(veryraretraits.Keys);
                    availabletraits.AddRange(commontraits.Keys);
                }
                else
                {
                    availabletraits.AddRange(commontraits.Keys);
                }

                var newattr = new MetadataAttributes();

                // like head, body or whatever
                newattr.trait_type = attr.Key;
                
                // value of selected attribute
                var selectedtraitindex = RndTraitSelector.Next(availabletraits.Count);
                var traitvalue = availabletraits[selectedtraitindex];

                newattr.value = traitvalue;

                result.Add(newattr);

                // update attribute rarity volume
                if(veryraretraits.ContainsKey(traitvalue))
                {
                    if(AttrMap[attr.Key][traitvalue]>0)
                    {
                        AttrMap[attr.Key][traitvalue]--;
                    }
                }
            }

            return result;
        }
    }

}
