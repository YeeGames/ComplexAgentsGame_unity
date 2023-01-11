using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

namespace CAG2D_05
{
    public class AgentsManager : MonoBehaviour
    {
        [HideInInspector] public GameSettings gameSettings;

        [HideInInspector] public YeeAgent yeeAgent;

        [HideInInspector] private GameObject[] yeeAgentObjects;

        // private Vector3[] agentsPosition;

        private int _numDimentsionInWorld;
        private int _numAgentInWorld;


        public float radiusSize = 30f;

        // [HideInInspector] private Yee2ERule _yee2ERule;

        [HideInInspector] private YeeFamilyEnum yeeFamilyEnum;

        [HideInInspector] private YeeRule yeeRule;
        // [HideInInspector] private Yee yee;

        [HideInInspector] private YeeType yeeType;

        // private YeeInteraction YeeInteraction;

        /// <summary>
        /// 使用静态的YeeTypeChooser
        /// </summary>
        private void Awake()
        {
            /// 选择YeeType类型
            yeeType = YeeTypeChooser.ChooseYeeType(gameSettings.yeeFamilyEnum);

            /// 生成个体众
            for (var t = 0; t < yeeType.NumElement; t++) // 遍历每一类YeeType，以生成个体
            {
                for (var i = 0; i < gameSettings.numAgent; i++) // 遍历单类YeeType之所有预定数量，以生成个体
                {
                    YeeAgent a = Instantiate(yeeAgent);

                    Vector2 pos = (Vector2) (this.transform.position) + Random.insideUnitCircle * radiusSize;

                    a.aset.position = pos;
                    a.aset.velocity = Random.insideUnitCircle;
                    a.aset.id = i.ToString();
                    a.aset.YeeType = yeeType.YeeTypes[t];
                    a.aset.color = yeeType.Colors[t];
                    // a.aset.agentName = a.aset.agentBaseName + a.aset.YeeType + i.ToString();
                    a.agentRuleEffector.tag = a.Tag;

                    a.Initialize(a.aset, a.rset);

                    // a.agentRuleEffector = GameObject.Find("AgentRuleEffector").gameObject;
                    // a.yeeRule = YeeTypeChooser.ChooseYeeRule(a.agentRuleEffector, gameSettings.yeeFamilyEnum);
                }
            }

            // 计算个体总数
            _numAgentInWorld = gameSettings.numAgent * yeeType.NumElement;
            _numDimentsionInWorld =gameSettings.dimension;
        }


        // Start is called before the first frame update
        void Start()
        {
            int[] agentsID = new int[_numAgentInWorld];
            /// 查找所有具有`agent`标记的游戏对象，这里是`AgentRuleEffector`  NOTE 后续可能会改变对象名称
            yeeAgentObjects = GameObject.FindGameObjectsWithTag(yeeAgent.Tag);

            Debug.Log("yeeAgentObjects.Length = " + yeeAgentObjects.Length);
            /// 获取各个体之ID值
            for (var i = 0; i < _numAgentInWorld; i++)
            {
                agentsID[i] = yeeAgentObjects[i].GetInstanceID();
            }

            /// 初始化YeeInteraction
            YeeInteraction.Initialize(_numAgentInWorld, _numDimentsionInWorld, agentsID);
        }


        // Update is called once per frame
        void FixedUpdate()
        {
            ///TODO 获取所有的粒子对象相关的属性值，用一个数组向量
            for (int i = 0; i < _numAgentInWorld; i++)
            {
                YeeInteraction.AgentsPosition[i] = yeeAgentObjects[i].transform.position;
                // agentsPosition[i].X = yeeAgentObjects[i].transform.position.x;
                // agentsPosition[i].Y = yeeAgentObjects[i].transform.position.y;
                // agentsPosition[i].Z = yeeAgentObjects[i].transform.position.z;
            }

            /// TODO 计算交互情况
            // float[,] DistanceMatrix = YeeInteraction.CalculateYeeInteraction(agentsPosition);
            YeeInteraction.CalculateYeeInteraction(YeeInteraction.AgentsPosition);
            // Console.Write(YeeInteraction.DistanceMatrix);
            Debug.Log("Distance Matrix: " + YeeInteraction.DistanceMatrix.ToString());
        }
    }
}