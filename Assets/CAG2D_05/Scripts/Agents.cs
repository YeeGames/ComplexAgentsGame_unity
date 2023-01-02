using System;
using System.CodeDom;
using UnityEngine;
using Random = UnityEngine.Random;
using CAG2D_05;

// using Unity.Mathematics;

namespace CAG2D_05
{
    public class Agents : MonoBehaviour
    {
        [HideInInspector] public GameSettings gameSettings;

        [HideInInspector] public Agent agent;

        private int _totalAgent;


        public float radiusSize = 30f;

        [HideInInspector] private Yee2ERule _yee2ERule;

        [HideInInspector] private YeeFamilyEnum yeeFamilyEnum;

        [HideInInspector] private YeeRule yeeRule;
        [HideInInspector] private Yee yee;

        [HideInInspector] private YeeType yeeType;

        [HideInInspector] internal YeeInteraction YeeInteraction;
        // private YeeTypeChooserNotStatics _yeeTypeChooserNotStatics = new YeeTypeChooserNotStatics();

        /// <summary>
        /// 使用静态的YeeTypeChooser
        /// </summary>
        private void Awake()
        {
            yeeType = YeeTypeChooser.ChooseYeeType(gameSettings.yeeFamilyEnum);

            // 生成agent对象众
            for (var t = 0; t < yeeType.NumElement; t++) // 遍历每一类yeeType，以生成agent
            {
                for (var i = 0; i < gameSettings.numAgent; i++) // 遍历单类yeeType之所有预定数量，以生成agent
                {
                    Agent a = Agent.Instantiate(agent);

                    Vector2 pos = (Vector2) (this.transform.position) + Random.insideUnitCircle * radiusSize;

                    a.aset.position = pos;
                    a.aset.velocity = Random.insideUnitCircle;
                    a.aset.id = i.ToString();
                    a.aset.YeeType = yeeType.YeeTypes[t];
                    a.aset.color = yeeType.Colors[t];
                    // a.aset.agentName = a.aset.agentBaseName + a.aset.YeeType + i.ToString();

                    a.Initialize(a.aset);

                    // a.agentRuleEffector = GameObject.Find("AgentRuleEffector").gameObject;
                    // a.yeeRule = YeeTypeChooser.ChooseYeeRule(a.agentRuleEffector, gameSettings.yeeFamilyEnum);
                }
            }

            // 计算agent总数
            _totalAgent = gameSettings.numAgent * yeeType.NumElement;
            YeeInteraction  = new YeeInteraction(_totalAgent);
        }


        // Start is called before the first frame update
        void Start()
        {
        }


        // Update is called once per frame
        void FixedUpdate()
        {
            //TODO 获取所有的粒子对象
            
            // TODO 计算交互情况
            YeeInteraction.CalculateYeeInteraction();
            //
        }
    }
}