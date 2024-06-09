using NftGeneratorGui.Enums;
using NftGeneratorGui.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NftGeneratorGui.Factory
{
    public sealed class NftSettings
    {
        public Dictionary<string, Dictionary<string, int>> AttributesRarityList { get; set; } = new Dictionary<string, Dictionary<string, int>>();
        public Dictionary<string, Dictionary<string, int>> OtherAttributesRarityList { get; set; } = new Dictionary<string, Dictionary<string, int>>();
        public Dictionary<string, string> AttributeList { get; set; } = new Dictionary<string, string>();

        public Dictionary<GenerateSetting, object> GenerateSetting { get; set; } = new Dictionary<GenerateSetting, object>();

        public NftSettings()
        {

        }

        public ActionResult Load(string path)
        {
            try
            {
                var filecontent = File.ReadAllText(path);
                var savedconfigs = JsonSerializer.Deserialize<NftSettings>(filecontent);
                this.GenerateSetting = savedconfigs.GenerateSetting;
                this.AttributesRarityList = savedconfigs.AttributesRarityList;
                this.OtherAttributesRarityList = savedconfigs.OtherAttributesRarityList;
                this.AttributeList = savedconfigs.AttributeList;

                return new ActionResult(true, null); 
            }
            catch (Exception ex)
            {
                return new ActionResult(false, ex);
            }
            
        }

        public ActionResult Save(string path)
        {
            try
            {
                var json = JsonSerializer.Serialize(this);
                File.WriteAllText(path, json);
                return new ActionResult(true,null);
            }
            catch (Exception ex)
            {

                return new ActionResult(false, ex); 
            }
        }
    }
}
