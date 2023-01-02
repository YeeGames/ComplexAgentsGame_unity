
using System.Drawing;

namespace CAG2D_05
{
    public class Yee2E : YeeFamily
    {
        public Yee2EType Yee2EType;
        
        public new const int NumElement = 2;

        public Color[] Colors = {Color.Red, Color.Blue};
        // public Dictionary<string, object> Yee2EDict = new Dictionary<string, object>();
        // public List<object> Yee2EList = new List<object>();
        // public Dictionary<string, object> Yee2ETypeDict = new Dictionary<string, object>();
        // public List<string> Yee2EType = new List<string>();
        // public Dictionary<string, object> Yee2EInterTypeDict = new Dictionary<string, object>();
        // public List<string> Yee2EInterType = new List<string>();
        // public Dictionary<string, object> Yee2ERuleDict = new Dictionary<string, object>();
        // public List<string> Yee2ERule = new List<string>();

        public Yee2ETypeEnum Yee2ETypeEnum;

        public Yee2E()
        {
            // YeeTypes.Add(Yee2ETypeEnum.Yang);
            // YeeTypes.Add(Yee2ETypeEnum.Yin);
            YeeTypes.Add("Yang");
            YeeTypes.Add("Yin");
            YeeType_dict.Add("YeeTypes", YeeTypes);
            // YeeInterTypes.Add(Yee2EInterTypeEnum.Me);
            // YeeInterTypes.Add(Yee2EInterTypeEnum.You);
            YeeInterTypes.Add("Me");
            YeeInterTypes.Add("You");
            YeeInterType_dict.Add("YeeInterTypes", YeeInterTypes);
            // YeeRule.Add("Yee2ERule");
            YeeRule_dict.Add("YeeRule", YeeRule);
            YeeFamily_list.Add(YeeType_dict);
            YeeFamily_list.Add(YeeInterType_dict);
            YeeFamily_list.Add(YeeRule_dict);
        }
    }
    
}