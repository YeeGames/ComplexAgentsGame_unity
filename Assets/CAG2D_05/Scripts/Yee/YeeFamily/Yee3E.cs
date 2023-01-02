
using System.Drawing;

namespace CAG2D_05
{
    public class Yee3E : YeeFamily
    {
        public Yee3EType Yee3EType;

        public new int NumElement = 3;

        public Color[] Colors = {Color.Red, Color.Yellow, Color.Blue};

        public Yee3E()
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
            YeeTypes.Add("Rock");
            YeeTypes.Add("Scissors");
            YeeTypes.Add("Cloth");
            YeeType_dict.Add("YeeTypes", YeeTypes);
            YeeInterTypes.Add("Self");
            YeeInterTypes.Add("Ke");
            YeeInterTypes.Add("BeKe");
            YeeInterType_dict.Add("YeeInterTypes", YeeInterTypes);
            // YeeRule=gameObject.AddComponent<Yee3ERule>();
            YeeRule_dict.Add("YeeRule", YeeRule);
            YeeFamily_list.Add(YeeType_dict);
            YeeFamily_list.Add(YeeInterType_dict);
            YeeFamily_list.Add(YeeRule_dict);
        }
    }
}