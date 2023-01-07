// using CAG2D_05;

using UnityEngine;

namespace CAG2D_05
{
    public abstract class YeeRule : MonoBehaviour
    {
        // public RuleSettings rset;
        // public Yee3EType Yee3EType;
        // public string YeeInterType;
        //
        // private float forceStrength = 0f;
        //
        // private int direction = 1; // 方向取值1与-1。1表示推力方向，-1表示拉力方向；
        // private float expCoefficient = 2f;
        // private CircleCollider2D ruleCircleCollider2D;
        //
        // private Rigidbody2D rb1;
        // private Rigidbody2D rb2;
        // private Transform tf1;
        // private Transform tf2;



        // /// <summary>
        // /// 起始YeeType向量
        // /// </summary>
        // private string[] FromYeeTypeArray = new string[]
        // {
        // };

        // /// <summary>
        // /// 目标YeeType向量
        // /// </summary>
        // private string[] ToYeeTypeArray = new string[]
        // {
        // };

        // /// <summary>
        // /// YeeTypeInter之规则之邻接矩阵
        // /// </summary>
        // private string[,] YeeRuleAdjecentMatrix = new string[,]
        // {
        // };


        // /// <summary>
        // /// 起始YeeType向量
        // /// </summary>
        // public string[] FromYeeTypeArray = 
        // {
        //     YeeFamily.YeeTypes[0], YeeFamily.YeeTypes[1], YeeFamily.YeeTypes[2]
        // };
        // // private Yee3ETypeEnum[] FromYeeTypeArray = new Yee3ETypeEnum[]
        // // {
        //
        // //     Yee3ETypeEnum.Rock, Yee3ETypeEnum.Scissors, Yee3ETypeEnum.Cloth
        // // };
        //
        // /// <summary>
        // /// 目标YeeType向量
        // /// </summary>
        // public string[] ToYeeTypeArray = 
        // {
        //     Yee3E.YeeTypes[0], Yee3E.YeeTypes[1], Yee3E.YeeTypes[2]
        // };
        // // private Yee3ETypeEnum[] ToYeeTypeArray = new Yee3ETypeEnum[]
        // // {
        // //     Yee3ETypeEnum.Rock, Yee3ETypeEnum.Scissors, Yee3ETypeEnum.Cloth
        // // };
        //
        // /// <summary>
        // /// YeeTypeInter之规则之邻接矩阵
        // /// </summary>
        // public string[,] YeeRuleAdjecentMatrix = 
        // {
        //     {Yee3E.YeeInterTypes[0], Yee3E.YeeInterTypes[1], Yee3E.YeeInterTypes[2]},
        //     {Yee3E.YeeInterTypes[2], Yee3E.YeeInterTypes[0], Yee3E.YeeInterTypes[1]},
        //     {Yee3E.YeeInterTypes[1], Yee3E.YeeInterTypes[0], Yee3E.YeeInterTypes[2]},
        // };
        // // private static readonly Yee3EInterTypeEnum[,] YeeRuleAdjecentMatrix = new Yee3EInterTypeEnum[RowSize, ColSize]
        // // {
        // //     {Yee3EInterTypeEnum.Self, Yee3EInterTypeEnum.Ke, Yee3EInterTypeEnum.BeKe},
        // //     {Yee3EInterTypeEnum.BeKe, Yee3EInterTypeEnum.Self, Yee3EInterTypeEnum.Ke},
        // //     {Yee3EInterTypeEnum.Ke, Yee3EInterTypeEnum.BeKe, Yee3EInterTypeEnum.Self}
        // // };


        public virtual void SetRule(RuleSettings ruleSettings)
        {
        }


        public virtual void Initialize(RuleSettings ruleSettings)
        {
        }

        public virtual string CalcInterType(string thisYeeType, string thatYeeType)
        {
            return null;
        }

        public virtual void ApplyBehaviorRule(string yeeInterType, Rigidbody2D rb1, Vector2 pos1, Rigidbody2D rb2,
            Vector2 pos2)
        {
        }


        // private void Awake()
        // {
        //     // this.ruleCircleCollider2D = GameObject.Find("AgentRuleEffector").GetComponent<CircleCollider2D>();
        //     // Initialize(rset);
        // }

        // public virtual void OnTriggerStay2D(Collider2D otherCollider2D)
        // {
        // }
    }
}