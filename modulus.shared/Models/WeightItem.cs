using Modulus.Shared.Enums;

namespace Modulus.Shared.Models
{
    public class WeightItem
    {
        public string Sort1 { get; set; }
        public string Sort2 { get; set; }
        public ModulusType Algorithm { get; set; }
        public int[] Notation { get; set; } 

        public int Ex { get; set; }
    }
}