using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NftGeneratorGui.Models
{
    class NftMetadata
    {
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string external_url { get; set; }
        public IEnumerable<MetadataAttributes> attributes { get; set; }

        public NftMetadata(string name, string description, string image, string link,IEnumerable<MetadataAttributes> attr)
        {
            this.name = name;
            this.description = description;
            this.image = image;
            this.external_url = link;
            this.attributes = attr;
        }
    }
}
