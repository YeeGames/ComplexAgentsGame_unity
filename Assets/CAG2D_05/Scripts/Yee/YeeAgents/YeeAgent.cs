using System;
using System.Collections.Generic;
using CAG2D_05;
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
        [HideInInspector] private string id;

        /// <summary>
        /// Yee类型
        /// </summary>
        [HideInInspector] private string yeeType;

        public string YeeType
        {
            get => yeeType;
            set => yeeType = value;
        }


        [HideInInspector] private YeeRule yeeRule;

        /// <summary>
        /// Unity3D标签
        /// </summary>
        public string Tag { get; set; } = "agent";


        [HideInInspector] public SpriteRenderer spriteRenderer;
        [HideInInspector] public Rigidbody2D rigidbody2D;
        [HideInInspector] public PointEffector2D pointEffector;
        [HideInInspector] public CircleCollider2D colliderCircleCollider2D;
        [HideInInspector] public CircleCollider2D effectorCircleCollider2D;
        [HideInInspector] public CircleCollider2D ruleCircleCollider2D;
        [HideInInspector] public PhysicsMaterial2D physicsMaterial2D;
        [HideInInspector] public GameObject agentRuleEffector;


        [HideInInspector] public float maxSpeed;
        [HideInInspector] public float maxAngularSpeed;


        public void SetPosition(Vector2 pos)
        {
            transform.position = pos;
        }


        public void SetVelocity(Vector2 vel, float spe)
        {
            rigidbody2D.velocity = vel * spe;
        }

        public void SetVelocity(Vector2 vel)
        {
            rigidbody2D.velocity = vel;
        }

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
        public void Initialize(AgentSettings agentSettings)
        {
            this.SetAgentSettings(agentSettings);
            // this.agentRuleEffector = this.gameObject.transform.Find("AgentRuleEffector").gameObject;
            // this.yeeFamily = YeeTypeChooser.ChooseYeeFamily(this.agentRuleEffector, this.gset.yeeFamilyEnum);
            // yee = YeeTypeChooser.ChooseYee(this.agentRuleEffector, this.gset.yeeFamilyEnum);

            this.yeeRule = YeeTypeChooser.ChooseYeeRule(agentRuleEffector, gset.yeeFamilyEnum);
            // this.yeeRule = _yeeTypeChooserNotStatics.ChooseYeeRule(agentRuleEffector, this.gset.yeeFamilyEnum);
            // YeeRule yeeRule = _yeeTypeChooserNotStatics.ChooseYeeRule(agentRuleEffector, gset.yeeFamilyEnum);

            // this.yeeRule.Initialize(ruleSettings);
        }


        /// <summary>
        /// 设置agent
        /// </summary>
        /// <param name="agentSettings"></param>
        public void SetAgentSettings(AgentSettings agentSettings)
        {
            this.aset = agentSettings;
            // this.yeeFamily = this.aset.yeeFamily;
            this.id = this.aset.id;
            this.yeeType = this.aset.YeeType;
            this.name = this.aset.agentBaseName + this.aset.YeeType + this.id;
            this.SetColor(this.aset.color);
            this.SetPosition(this.aset.position);
            this.SetVelocity(this.aset.velocity, this.aset.initSpeed);
            this.colliderCircleCollider2D.radius = this.aset.collisionRadius;
            this.effectorCircleCollider2D.radius = this.aset.magnitudeForceRadius;
            this.pointEffector.forceMagnitude = this.aset.magnitudeForce;
            this.maxSpeed = this.aset.maxSpeed;
            this.maxAngularSpeed = this.aset.maxAngularSpeed;
            this.rigidbody2D.mass = this.aset.mass;
            this.rigidbody2D.drag = this.aset.linearDrag;
            this.rigidbody2D.angularDrag = this.aset.angularDrag;


            // 自定义2D物理材质。
            this.physicsMaterial2D = new PhysicsMaterial2D(); // 自行新建2D物理材质
            if (this.physicsMaterial2D != null)
            {
                this.physicsMaterial2D.friction = this.aset.physicsMaterialFriction;
                this.physicsMaterial2D.bounciness = this.aset.physicsMaterialBounciness;
            }

            this.rigidbody2D.sharedMaterial = this.physicsMaterial2D;
            this.colliderCircleCollider2D.sharedMaterial = this.physicsMaterial2D;
            this.effectorCircleCollider2D.sharedMaterial = this.physicsMaterial2D;
            this.ruleCircleCollider2D.sharedMaterial = this.physicsMaterial2D;
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
            // this.yeeRule = this.gameObject.transform.Find("AgentRuleEffector").GetComponent<YeeRule>();
            // this.yeeRule = YeeTypeChooser.ChooseYeeRule(agentRuleEffector, gset.yeeFamilyEnum);

            // Initialize(this.aset, this.rset);
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
            this.rigidbody2D.velocity = Vector2.ClampMagnitude(rigidbody2D.velocity, maxSpeed); // 限制最大速度；
            this.rigidbody2D.angularVelocity = Mathf.Max(rigidbody2D.angularVelocity, maxAngularSpeed); // 限制最大角速度；
            // Debug.Log("updated");
        }

        public void OnTriggerStay(Collider other)
        {
            throw new NotImplementedException();
        }
    }
}