using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace CAG2D_05
{
    public class YeeType
    {
        [ReadOnly] [SerializeField] public int NumElement;
        [ReadOnly] [SerializeField] public Color[] Colors;
        [ReadOnly] [SerializeField] public string[] YeeTypes;
        [ReadOnly] [SerializeField] public string[] YeeInterTypes;

        /// <summary>
        /// 起始YeeType向量
        /// </summary>
        internal string[] FromYeeTypeArray = new string[]
        {
        };


        /// <summary>
        /// 目标YeeType向量
        /// </summary>
        internal string[] ToYeeTypeArray = new string[]
        {
        };

        /// <summary>
        /// YeeTypeInter之规则之邻接矩阵
        /// </summary>
        internal string[,] YeeRuleAdjecentMatrix = new string[,]
        {
        };


        // internal int SetNumElement()
        // {
        //     NumElement = 0;
        //     return NumElement;
        // }


        // internal int NumElement
        // {
        //     get => _numElement;
        //     set => _numElement = value;
        // }
        //
        // internal Color[] Colors
        // {
        //     get => _colors;
        //     set => _colors = value;
        // }
        //
        // internal string[] YeeTypes
        // {
        //     get => _yeeTypes;
        //     set => _yeeTypes = value;
        // }
        //
        // internal string[] YeeInterTypes
        // {
        //     get => _yeeInterTypes;
        //     set => _yeeInterTypes = value;
        // }
        //
        // internal string[] FromYeeTypeArray
        // {
        //     get => _fromYeeTypeArray;
        //     set => _fromYeeTypeArray = value;
        // }
        //
        // internal string[] ToYeeTypeArray
        // {
        //     get => _toYeeTypeArray;
        //     set => _toYeeTypeArray = value;
        // }
        //
        // internal string[,] YeeRuleAdjecentMatrix
        // {
        //     get => _yeeRuleAdjecentMatrix;
        //     set => _yeeRuleAdjecentMatrix = value;
        // }
    }
}