using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NftGeneratorGui.Tools
{
    public class Otherutils
    {
        public static BigInteger CalculateMaxProbabilites(Dictionary<string,Dictionary<string,int>> nftdata)
        {
            if (nftdata.Count == 0) { return 0; }
            BigInteger probability =1;

            // common items
            foreach (var attribute in nftdata)
            {
                var commonattrcounts = attribute.Value.Values.ToArray().Count(it => it == -1);
                probability = probability * commonattrcounts;
                //Debug.WriteLine();
            }

            // restricted items
            foreach (var attribute in nftdata)
            {
                var rarecounter = attribute.Value.Values.ToArray().Where(it=> it>0).ToArray();
                probability = probability + rarecounter.Sum();
            }


            return probability;
        }
    }
}
