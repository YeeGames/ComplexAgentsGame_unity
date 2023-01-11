using System;
using Unity.Collections;
using UnityEngine;

namespace CAG2D_05
{
    public class YeeAgent : MonoBehaviour
    {
        /// <summary>
        /// 设定`Agent`设置项
        /// </summary>
        [HideInInspector] public AgentSettings aset;


        /// <summary>
        /// 设定`Game`设置项
        /// </summary>
        [HideInInspector] public GameSettings gset;

        /// <summary>
        /// 设定`Rule`设置项
        /// </summary>
        [HideInInspector] public RuleSettings rset;


        /// <summary>
        /// id
        /// </summary>
        [ReadOnly] [SerializeField] private string id;

        /// <summary>
        /// Yee类型
        /// </summary>
        [ReadOnly] [SerializeField] private string yeeType;

        public string YeeType
        {
            get => yeeType;
            // set => yeeType = value;
        }
        
        // public string YeeInterType

        [HideInInspector] private YeeRule yeeRule;

        /// <summary>
        /// Unity3D标签
        /// </summary>
        public string Tag { get; set; } = "agent";


        [HideInInspector] public SpriteRenderer spriteRenderer;
        [HideInInspector] public new Rigidbody2D rigidbody2D;
        [HideInInspector] public PointEffector2D pointEffector;
        [HideInInspector] public CircleCollider2D colliderCircleCollider2D;
        [HideInInspector] public CircleCollider2D effectorCircleCollider2D;
        [HideInInspector] public CircleCollider2D ruleCircleCollider2D;
        [HideInInspector] public PhysicsMaterial2D physicsMaterial2D;
        [HideInInspector] public GameObject agentRuleEffector;


        [HideInInspector] public float maxSpeed;
        [HideInInspector] public float maxAngularSpeed;

        public YeeAgent()
        {
        }

        /// <summary>
        /// 设置位置
        /// </summary>
        /// <param name="pos">位置</param>
        public void SetPosition(Vector2 pos)
        {
            transform.position = pos;
        }

        /// <summary>
        /// 设置速度
        /// </summary>
        /// <param name="vel">速度</param>
        /// <param name="spe">初始速度</param>
        public void SetVelocity(Vector2 vel, float spe)
        {
            rigidbody2D.velocity = vel * spe;
        }

        /// <summary>
        /// 设置颜色
        /// </summary>
        /// <param name="col">颜色</param>
        public void SetColor(Color col)
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.color = col;
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="agentSettings"></param>
        /// <param name="ruleSettings"></param>
        public void Initialize(AgentSettings agentSettings, RuleSettings ruleSettings)
        {
            this.yeeRule = YeeTypeChooser.ChooseYeeRule(agentRuleEffector, gset.yeeFamilyEnum);
            this.yeeRule.SetRule(ruleSettings);
            this.SetAgentSettings(agentSettings);
        }


        /// <summary>
        /// 设置agent
        /// </summary>
        /// <param name="agentSettings"></param>
        public void SetAgentSettings(AgentSettings agentSettings)
        {
            this.id = agentSettings.id;
            this.yeeType = agentSettings.YeeType;
            this.name = agentSettings.agentBaseName + agentSettings.YeeType + this.id;
            this.SetColor(agentSettings.color);
            this.SetPosition(agentSettings.position);
            this.SetVelocity(agentSettings.velocity, agentSettings.initSpeed);
            this.colliderCircleCollider2D.radius = agentSettings.collisionRadius;
            this.effectorCircleCollider2D.radius = agentSettings.magnitudeForceRadius;
            this.pointEffector.forceMagnitude = agentSettings.magnitudeForce;
            this.maxSpeed = agentSettings.maxSpeed;
            this.maxAngularSpeed = agentSettings.maxAngularSpeed;
            this.rigidbody2D.mass = agentSettings.mass;
            this.rigidbody2D.drag = agentSettings.linearDrag;
            this.rigidbody2D.angularDrag = agentSettings.angularDrag;


            /// 自定义2D物理材质。
            this.physicsMaterial2D = new PhysicsMaterial2D();
            if (this.physicsMaterial2D != null)
            {
                this.physicsMaterial2D.friction = this.aset.physicsMaterialFriction;
                this.physicsMaterial2D.bounciness = this.aset.physicsMaterialBounciness;
            }

            this.rigidbody2D.sharedMaterial = this.physicsMaterial2D;
            this.colliderCircleCollider2D.sharedMaterial = this.physicsMaterial2D;
            this.effectorCircleCollider2D.sharedMaterial = this.physicsMaterial2D;
            this.ruleCircleCollider2D.sharedMaterial = this.physicsMaterial2D;

            /// 设置规则圆圈碰撞器之圆圈半径
            this.ruleCircleCollider2D.radius = this.yeeRule.ruleCircleCollider2DRadius;
        }


        void Awake()
        {
            this.rigidbody2D = GetComponent<Rigidbody2D>();
            this.spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            this.colliderCircleCollider2D = this.gameObject.transform.Find("AgentCollider").GetComponent<CircleCollider2D>();
            this.effectorCircleCollider2D = this.gameObject.transform.Find("AgentEffector").GetComponent<CircleCollider2D>();
            this.ruleCircleCollider2D = this.gameObject.transform.Find("AgentRuleEffector").GetComponent<CircleCollider2D>();
            this.pointEffector = this.gameObject.transform.Find("AgentEffector").GetComponent<PointEffector2D>();
            this.agentRuleEffector = this.gameObject.transform.Find("AgentRuleEffector").gameObject;
        }

        // Start is called before the first frame update
        void Start()
        {
            // Initialize(this.aset,this.rset);
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void FixedUpdate()
        {
            this.transform.Translate(Vector2.zero * (Time.deltaTime));
            this.rigidbody2D.velocity = Vector2.ClampMagnitude(rigidbody2D.velocity, maxSpeed); /// 限制最大速度；
            this.rigidbody2D.angularVelocity = Mathf.Max(rigidbody2D.angularVelocity, maxAngularSpeed); /// 限制最大角速度；
        }

        // public void OnTriggerStay(Collider other) //TODO
        // {
        //     throw new NotImplementedException();
        // }
    }
}