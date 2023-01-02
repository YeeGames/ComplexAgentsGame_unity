// using CAG2D_05;

using System;
using System.Collections.Generic;
using UnityEngine;

namespace CAG2D_05
{
    public class YeeTypeChooserNotStatics //NOW
    {
        public RuleSettings rset;

        // public YeeTypeFamilyEnum _yeeTypeFamily;
        // public YeeType _yeeType;
        // public Yee2EType _yee2EType;
        // public Yee3EType Yee3EType;
        public Yee _yee;
        public YeeFamily _yeeFamily;


        // public List<Enum> yeeTypeList;
        // public List<Enum> yee3ETypeList;


        public YeeRule ChooseYeeRule(GameObject gameObject, YeeFamilyEnum yeeFamilyEnum)
        {
            YeeRule yeeRule = null;
            switch (yeeFamilyEnum)
            {
                case YeeFamilyEnum.Yee2E:
                    // yeeRule = gameObject.AddComponent<Yee2ERule>(); //FIXME Yee3ERule to Yee2ERule
                    // yeeFamilyEnum = YeeTypeFamilyEnum.YeeType2E;
                    break;
                case YeeFamilyEnum.Yee3E:
                    yeeRule = gameObject.AddComponent<Yee3ERule>();
                    // yeeRule.Initialize(rset);
                    // yeeFamilyEnum = YeeTypeFamilyEnum.YeeType3E;
                    break;
                default:
                    break;
            }

            return yeeRule;
        }


        public YeeFamily ChooseYeeFamily(GameObject gameObject, YeeFamilyEnum yeeFamilyEnum)
        {
            switch (yeeFamilyEnum)
            {
                case YeeFamilyEnum.Yee2E:
                    // YeeFamily = new Yee2E();
                    _yeeFamily = gameObject.AddComponent<Yee2E>();
                    break;
                case YeeFamilyEnum.Yee3E:
                    // YeeFamily = new Yee3E();
                    _yeeFamily = gameObject.AddComponent<Yee3E>(); //BUG
                    break;
                default:
                    break;
            }


            return _yeeFamily;
        }

        public YeeType ChooseYeeType(YeeFamilyEnum yeeFamilyEnum)
        {
            YeeType yeeType = null;
            switch (yeeFamilyEnum)
            {
                case YeeFamilyEnum.Yee2E:
                    yeeType = new Yee2EType();
                    // YeeFamily = new Yee2E();
                    // YeeFamily = gameObject.AddComponent<Yee2E>();
                    break;
                case YeeFamilyEnum.Yee3E:
                    yeeType = new Yee3EType();
                    // YeeFamily = new Yee3E();
                    // YeeFamily = gameObject.AddComponent<Yee3E>();
                    break;
                default:
                    break;
            }


            return yeeType;
        }

        public Yee ChooseYee(GameObject gameObject, YeeFamilyEnum yeeFamilyEnum)
        {
            switch (yeeFamilyEnum)
            {
                case YeeFamilyEnum.Yee2E:
                    // YeeFamily = new Yee2E();
                    _yeeFamily = gameObject.AddComponent<Yee2E>();
                    break;
                case YeeFamilyEnum.Yee3E:
                    // YeeFamily = new Yee3E();
                    _yeeFamily = gameObject.AddComponent<Yee3E>();
                    break;
                default:
                    break;
            }

            _yee.YeeFamily = _yeeFamily; //BUG

            return _yee;
        }
    }
}