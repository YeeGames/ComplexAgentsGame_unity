using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace CAG2D_05
{
    // public class Yee3ERule : MonoBehaviour,IYeeRule
    public class Yee3ERule :YeeRule
    {
        [SerializeField] private RuleSettings rset;

        // private static YeeFamily YeeFamily;
        // private static Yee3E Yee3E;
        [SerializeField] private Yee3EType Yee3EType = new Yee3EType();

        // private static List<string> yeeTypes;
        // private Yee _yee;
        [SerializeField] private string YeeInterType;


        [SerializeField] private float forceStrength = 10f;
        [SerializeField] private int direction = 1; // 方向取值1与-1。1表示推力方向，-1表示拉力方向；
        [SerializeField] private float expCoefficient = 2f;
        [SerializeField] private CircleCollider2D ruleCircleCollider2D;

        // [SerializeField] private Rigidbody2D rb1;
        // [SerializeField] private Rigidbody2D rb2;
        // [SerializeField] private Transform tf1;
        // [SerializeField] private Transform tf2;


        // /// <summary>
        // /// 起始YeeType向量
        // /// </summary>
        // private string[] FromYeeTypeArray = new string[]
        // {
        //     Yee3E.YeeTypes[0], Yee3E.YeeTypes[1], Yee3E.YeeTypes[2]
        // };
        // private Yee3ETypeEnum[] FromYeeTypeArray = new Yee3ETypeEnum[]
        // {
        //     Yee3ETypeEnum.Rock, Yee3ETypeEnum.Scissors, Yee3ETypeEnum.Cloth
        // };

        // /// <summary>
        // /// 目标YeeType向量
        // /// </summary>
        // private string[] ToYeeTypeArray = new string[] 
        // {
        //     Yee3E.YeeTypes[0], Yee3E.YeeTypes[1], Yee3E.YeeTypes[2]
        // };
        // private Yee3ETypeEnum[] ToYeeTypeArray = new Yee3ETypeEnum[]
        // {
        //     Yee3ETypeEnum.Rock, Yee3ETypeEnum.Scissors, Yee3ETypeEnum.Cloth
        // };

        // /// <summary>
        // /// YeeTypeInter之规则之邻接矩阵
        // /// </summary>
        // private string[,] YeeRuleAdjecentMatrix = new string[,]
        // {
        //     {Yee3E.YeeInterTypes[0], Yee3E.YeeInterTypes[1], Yee3E.YeeInterTypes[2]},
        //     {Yee3E.YeeInterTypes[2], Yee3E.YeeInterTypes[0], Yee3E.YeeInterTypes[1]},
        //     {Yee3E.YeeInterTypes[1], Yee3E.YeeInterTypes[0], Yee3E.YeeInterTypes[2]},
        // };
        // private static readonly Yee3EInterTypeEnum[,] YeeRuleAdjecentMatrix = new Yee3EInterTypeEnum[RowSize, ColSize]
        // {
        //     {Yee3EInterTypeEnum.Self, Yee3EInterTypeEnum.Ke, Yee3EInterTypeEnum.BeKe},
        //     {Yee3EInterTypeEnum.BeKe, Yee3EInterTypeEnum.Self, Yee3EInterTypeEnum.Ke},
        //     {Yee3EInterTypeEnum.Ke, Yee3EInterTypeEnum.BeKe, Yee3EInterTypeEnum.Self}
        // };


        /// <summary>
        /// 设置规则
        /// </summary>
        /// <param name="ruleSettings"></param>
        // public override void SetRule(RuleSettings ruleSettings)
        public override void SetRule(RuleSettings ruleSettings)
        {
            this.rset = ruleSettings;
            // this.rset = this.transform.GetComponent<YeeTypeFamilyEnum>();
            this.ruleCircleCollider2D.radius = this.rset.forceEffectiveRadius;
            this.forceStrength = this.rset.forceStrength;
            this.expCoefficient = this.rset.expCoefficient;
            this.direction = this.rset.direction;
            Debug.Log(this.rset.direction);
        }

        // protected override void Initialize(RuleSettings ruleSettings)
        public override void Initialize(RuleSettings ruleSettings)
        {
            SetRule(ruleSettings);
        }


        /// <summary>
        /// 判断类型交互规则 
        /// </summary>
        /// <param name="thisYeeType">己方YeeType3E类型</param>
        /// <param name="thatYeeType">对方YeeType3E类型</param>
        public override string GetInterRule(string thisYeeType, string thatYeeType)
        {
            return Yee3EType.YeeRuleAdjecentMatrix[Array.IndexOf(Yee3EType.FromYeeTypeArray, thisYeeType), Array.IndexOf(Yee3EType.ToYeeTypeArray, thatYeeType)]; //BUG
        }


        /// <summary>
        /// 应用行为规则
        /// </summary>
        /// <param name="yeeInterType">YeeTypeInter3E类型</param>
        /// <param name="rb1">我方agent刚体</param>
        /// <param name="pos1">我方agent位置</param>
        /// <param name="rb2">对方agent刚体</param>
        /// <param name="pos2">对方agent位置</param>
        public override void ApplyBehaviorRule(string yeeInterType, Rigidbody2D rb1, Vector2 pos1, Rigidbody2D rb2, Vector2 pos2)
        {
            Vector2 vector_from_a1_to_a2 = (Vector2) (pos2 - pos1);
            Vector2 direction_from_a1_to_a2 = vector_from_a1_to_a2.normalized;
            float distance_from_a1_to_a2 = direction_from_a1_to_a2.magnitude;


            // 应用施力规则。
            // 如果是交互状态我方为Ke，则己方受到拉力，对方受到推力，形成效果力之于己方追逐对方逃避；
            // 如果是交互状态我方为BeKe，则己方受到推力，对方受到拉力，形成效果力之于对方追逐我方逃避；
            if (yeeInterType == Yee3EInterTypeEnum.Ke.ToString())
            {
                rb1.AddForce(
                    forceStrength * ((float) direction * direction_from_a1_to_a2) /
                    math.pow(distance_from_a1_to_a2, expCoefficient), ForceMode2D.Force);
                rb2.AddForce(
                    forceStrength * ((float) -direction * direction_from_a1_to_a2) /
                    math.pow(distance_from_a1_to_a2, expCoefficient),
                    ForceMode2D.Force);
            }
            else if (yeeInterType == Yee3EInterTypeEnum.BeKe.ToString())
            {
                rb1.AddForce(
                    forceStrength * ((float) -direction * direction_from_a1_to_a2) /
                    math.pow(distance_from_a1_to_a2, expCoefficient),
                    ForceMode2D.Force);
                rb2.AddForce(
                    forceStrength * ((float) direction * direction_from_a1_to_a2) /
                    math.pow(distance_from_a1_to_a2, expCoefficient),
                    ForceMode2D.Force);
            }
        }


        private void Awake()
        {
            // this.ruleCircleCollider2D = this.transform.Find("AgentRuleEffector").GetComponent<CircleCollider2D>();
            this.ruleCircleCollider2D = this.gameObject.transform.GetComponent<CircleCollider2D>(); //BUG
            // this.Yee3E = this.gameObject.transform.Find("AgentRuleEffector").GetComponent<Yee3E>();
            // Initialize(rset);
        }


        // public override void OnTriggerStay2D(Collider2D otherCollider2D)
        public void OnTriggerStay2D(Collider2D otherCollider2D)
        {
            Rigidbody2D thisRigidbody2D = this.gameObject.transform.GetComponentInParent<Rigidbody2D>();
            Vector2 thisPosition2D = this.gameObject.transform.GetComponentInParent<Transform>().position;
            string thisYeeType = this.gameObject.transform.GetComponentInParent<YeeAgent>().YeeType;
            // string thisYeeInterType = this.gameObject.transform.GetComponentInParent<YeeAgent>().aset.YeeInterTypes;
            Rigidbody2D thatRigidbody2D = otherCollider2D.gameObject.transform.GetComponentInParent<Rigidbody2D>();
            Vector2 thatPosition2D = otherCollider2D.gameObject.transform.GetComponentInParent<Transform>().position;
            // Yee3ETypeEnum thatYeeType = otherCollider2D.gameObject.transform.GetComponentInParent<YeeAgent>().yee3ETypeEnum;
            // yeeFamilyEnum thatYeeFamily = otherCollider2D.gameObject.transform.GetComponent<yee>().yeeFamilyEnum;
            string thatYeeType = otherCollider2D.gameObject.transform.GetComponentInParent<YeeAgent>().YeeType;
            // List<string> thatYeeType = YeeFamily.YeeTypes;
            // this._yee3EInterTypeEnum = GetInterRule(thisYeeFamily.YeeTypes[1], thatYeeType);
            YeeInterType = GetInterRule(thisYeeType, thatYeeType);
            ApplyBehaviorRule(YeeInterType, thisRigidbody2D, thisPosition2D, thatRigidbody2D, thatPosition2D);
        }
    }
}