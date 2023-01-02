using System;
using System.Linq;
using System.Collections.Generic;
// using System.Runtime.Serialization.Json;
// using Newtonsoft.Json;
using UnityEngine;

namespace CAG2D_05
{
    public class Yee : MonoBehaviour 
    {
        public List<YeeType> enumToList<YeeType>() where YeeType : Enum
        {
            List<YeeType> yeeTypeList = Enum.GetValues(typeof(YeeType)).Cast<YeeType>().ToList();
            return yeeTypeList;
        }


        public YeeFamily YeeFamily { get; set; }

        public Dictionary<string, object> YeeFamily_dict = new Dictionary<string, object>();
        public List<object> YeeFamily_list = new List<object>();

        public Yee()
        {
            YeeFamily_list.Add(YeeFamily);
            YeeFamily_dict.Add("yeeFamilyEnum", YeeFamily_list);
        }
    }
}