using System.Collections.Generic;
using UnityEngine;

namespace CAG2D_05
{
    public class YeeType
    {
        private int _numElement;
        private Color[] _colors;
        private string[] _yeeTypes;
        private string[] _yeeInterTypes;

        /// <summary>
        /// 起始YeeType向量
        /// </summary>
        private string[] fromYeeTypeArray = new string[]
        {
        };


        /// <summary>
        /// 目标YeeType向量
        /// </summary>
        private string[] toYeeTypeArray = new string[]
        {
        };

        /// <summary>
        /// YeeTypeInter之规则之邻接矩阵
        /// </summary>
        private string[,] yeeRuleAdjecentMatrix = new string[,]
        {
        };


        public int setNumElement()
        {
            _numElement = 1;
            return _numElement;
        }


        public int NumElement
        {
            get => _numElement;
            set => _numElement = value;
        }

        public Color[] Colors
        {
            get => _colors;
            set => _colors = value;
        }

        public string[] YeeTypes
        {
            get => _yeeTypes;
            set => _yeeTypes = value;
        }

        public string[] YeeInterTypes
        {
            get => _yeeInterTypes;
            set => _yeeInterTypes = value;
        }

        public string[] FromYeeTypeArray
        {
            get => fromYeeTypeArray;
            set => fromYeeTypeArray = value;
        }

        public string[] ToYeeTypeArray
        {
            get => toYeeTypeArray;
            set => toYeeTypeArray = value;
        }

        public string[,] YeeRuleAdjecentMatrix
        {
            get => yeeRuleAdjecentMatrix;
            set => yeeRuleAdjecentMatrix = value;
        }
    }
}