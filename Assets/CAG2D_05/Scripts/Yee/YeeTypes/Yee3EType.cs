using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace CAG2D_05
{
    public class Yee3EType : YeeType
    {
        public Yee3ETypeEnum Yee3ETypeEnum;

        public Yee3EType()
        {
            this.NumElement = 3;
            this.Colors = new Color[] {Color.red, Color.yellow, Color.blue};
            this.YeeTypes = new string[] {"Rock", "Scissors", "Cloth"};
            this.YeeInterTypes = new string[] {"Self", "Ke", "BeKe"};

            this.FromYeeTypeArray = new string[]
            {
                this.YeeTypes[0], this.YeeTypes[1], this.YeeTypes[2]
            };

            this.ToYeeTypeArray = new string[]
            {
                this.YeeTypes[0], this.YeeTypes[1], this.YeeTypes[2]
            };

            this.YeeRuleAdjecentMatrix = new string[,]
            {
                {this.YeeInterTypes[0], this.YeeInterTypes[1], this.YeeInterTypes[2]},
                {this.YeeInterTypes[2], this.YeeInterTypes[0], this.YeeInterTypes[1]},
                {this.YeeInterTypes[1], this.YeeInterTypes[0], this.YeeInterTypes[2]},
            };
        }
    }
}