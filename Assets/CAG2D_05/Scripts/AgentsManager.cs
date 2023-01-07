using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;
using CAG2D_05;

namespace CAG2D_05
{
    public class AgentsManager : MonoBehaviour
    {
        [HideInInspector] public GameSettings gameSettings;

        [HideInInspector] public YeeAgent yeeAgent;

        [HideInInspector] private GameObject[] agentGameObjects;

        // private Vector3[] agentsPosition;

        private int _numDimentsionInWorld;
        private int _numAgentInWorld;


        public float radiusSize = 30f;

        [HideInInspector] private Yee2ERule _yee2ERule;

        [HideInInspector] private YeeFamilyEnum yeeFamilyEnum;

        [HideInInspector] private YeeRule yeeRule;
        [HideInInspector] private Yee yee;

        [HideInInspector] private YeeType yeeType;

        // private YeeInteraction YeeInteraction;

        /// <summary>
        /// 使用静态的YeeTypeChooser
        /// </summary>
        private void Awake()
        {
            yeeType = YeeTypeChooser.ChooseYeeType(gameSettings.yeeFamilyEnum);

            // 生成个体众
            for (var t = 0; t < yeeType.NumElement; t++) // 遍历每一类yeeType，以生成个体
            {
                for (var i = 0; i < gameSettings.numAgent; i++) // 遍历单类yeeType之所有预定数量，以生成个体
                {
                    YeeAgent a = YeeAgent.Instantiate(yeeAgent);

                    Vector2 pos = (Vector2) (this.transform.position) + Random.insideUnitCircle * radiusSize;

                    a.aset.position = pos;
                    a.aset.velocity = Random.insideUnitCircle;
                    a.aset.id = i.ToString();
                    a.aset.YeeType = yeeType.YeeTypes[t];
                    a.aset.color = yeeType.Colors[t];
                    // a.aset.agentName = a.aset.agentBaseName + a.aset.YeeType + i.ToString();
                    a.agentRuleEffector.tag = a.Tag;

                    a.Initialize(a.aset);

                    // a.agentRuleEffector = GameObject.Find("AgentRuleEffector").gameObject;
                    // a.yeeRule = YeeTypeChooser.ChooseYeeRule(a.agentRuleEffector, gameSettings.yeeFamilyEnum);
                }
            }

            // 计算个体总数
            _numAgentInWorld = gameSettings.numAgent * yeeType.NumElement;
            _numDimentsionInWorld = 2;
        }


        // Start is called before the first frame update
        void Start()
        {
            int[] agentsID = new int[_numAgentInWorld];
            // 查找所有具有`agent`标记的游戏对象，这里是`AgentRuleEffector`  NOTE 后续可能会改变对象名称
            agentGameObjects = GameObject.FindGameObjectsWithTag(yeeAgent.Tag);

            Debug.Log("agentGameObjects.Length = " + agentGameObjects.Length);
            // 获取各个体之ID值
            for (var i = 0; i < _numAgentInWorld; i++)
            {
                agentsID[i] = agentGameObjects[i].GetInstanceID();
            }

            // 初始化YeeInteraction
            YeeInteraction.Initialize(_numAgentInWorld, _numDimentsionInWorld, agentsID);
        }


        // Update is called once per frame
        void FixedUpdate()
        {
            //TODO 获取所有的粒子对象相关的属性值，用一个数组向量
            for (int i = 0; i < _numAgentInWorld; i++)
            {
                YeeInteraction.AgentsPosition[i] = agentGameObjects[i].transform.position;
                // agentsPosition[i].X = agentGameObjects[i].transform.position.x;
                // agentsPosition[i].Y = agentGameObjects[i].transform.position.y;
                // agentsPosition[i].Z = agentGameObjects[i].transform.position.z;
            }
            // for (int i = 0; i < agentGameObjects.Length; i++)
            // {
            //     agentsPosition[i, 0] = agentGameObjects[i].transform.position.x;
            //     agentsPosition[i, 1] = agentGameObjects[i].transform.position.z;
            // }

            // TODO 计算交互情况
            // float[,] DistanceMatrix = YeeInteraction.CalculateYeeInteraction(agentsPosition);
            YeeInteraction.CalculateYeeInteraction(YeeInteraction.AgentsPosition);
            // Console.Write(YeeInteraction.DistanceMatrix);
            Debug.Log("Distance Matrix: " + YeeInteraction.DistanceMatrix.ToString());
        }
    }
}