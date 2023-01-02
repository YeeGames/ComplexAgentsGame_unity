using System.Collections.Generic;
using UnityEngine;

namespace CAG2D_05
{
    public class YeeFamily : MonoBehaviour
    {
        [HideInInspector] public YeeType yeeType;
        [HideInInspector] public Dictionary<string, object> YeeFamilyDict = new Dictionary<string, object>();
        [HideInInspector] public List<object> YeeFamily_list = new List<object>();
        [HideInInspector] public Dictionary<string, List<string>> YeeType_dict = new Dictionary<string, List<string>>();
        [HideInInspector] public List<string> YeeTypes = new List<string>();
        [HideInInspector] public Dictionary<string, object> YeeInterType_dict = new Dictionary<string, object>();
        [HideInInspector] public List<string> YeeInterTypes = new List<string>();
        [HideInInspector] public Dictionary<string, object> YeeRule_dict = new Dictionary<string, object>();
        [HideInInspector] public YeeRule YeeRule;

        public YeeFamily()
        {
            // YeeTypes.Add("Rock");
            // YeeTypes.Add("Scissors");
            // YeeTypes.Add("Cloth");
            // YeeType_dict.Add("YeeTypes", YeeTypes);
            // YeeInterTypes.Add("Self");
            // YeeInterTypes.Add("Ke");
            // YeeInterTypes.Add("BeKe");
            // YeeInterType_dict.Add("YeeInterTypes", YeeInterTypes);
            // // YeeRule=gameObject.AddComponent<Yee3ERule>();
            // YeeRule_dict.Add("YeeRule", YeeRule);
            // YeeFamily_list.Add(YeeType_dict);
            // YeeFamily_list.Add(YeeInterType_dict);
            // YeeFamily_list.Add(YeeRule_dict);
        }

        public void Awake()
        {
            // YeeTypes.Add("Rock");
            // YeeTypes.Add("Scissors");
            // YeeTypes.Add("Cloth");
            // YeeType_dict.Add("YeeTypes", YeeTypes);
            // YeeInterTypes.Add("Self");
            // YeeInterTypes.Add("Ke");
            // YeeInterTypes.Add("BeKe");
            // YeeInterType_dict.Add("YeeInterTypes", YeeInterTypes);
            // // YeeRule=gameObject.AddComponent<Yee3ERule>();
            // YeeRule_dict.Add("YeeRule", YeeRule);
            // YeeFamily_list.Add(YeeType_dict);
            // YeeFamily_list.Add(YeeInterType_dict);
            // YeeFamily_list.Add(YeeRule_dict);
        }
    }
}