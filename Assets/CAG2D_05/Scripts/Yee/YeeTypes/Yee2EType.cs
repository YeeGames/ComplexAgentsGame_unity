using UnityEngine;

namespace CAG2D_05
{
    public class Yee2EType : YeeType
    {
        private Yee2ETypeEnum Yee2ETypeEnum;

        public Yee2EType()
        {
            this.NumElement = 2;
            this.Colors = new Color[] {Color.red, Color.blue};
            this.YeeTypes = new string[] {"Yang", "Yin"};
            this.YeeInterTypes = new string[] {"Me", "You"};
            
            this.FromYeeTypeArray = new string[]
            {
                this.YeeTypes[0], this.YeeTypes[1]
            };

            this.ToYeeTypeArray = new string[]
            {
                this.YeeTypes[0], this.YeeTypes[1]
            };

            this.YeeRuleAdjecentMatrix = new string[,]
            {
                {this.YeeInterTypes[0], this.YeeInterTypes[1]},
                {this.YeeInterTypes[1], this.YeeInterTypes[0]},
            };

        }
    }
}