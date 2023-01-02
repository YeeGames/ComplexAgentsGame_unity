using System;
using System.Collections.Generic;
using UnityEngine;

namespace CAG2D_05
{
    [CreateAssetMenu]
    public class AgentSettings : ScriptableObject
    {
        private GameSettings gameSettings;

        /// <summary>
        /// 主名
        /// </summary>
        public string agentBaseName = "thisAgent";

        /// <summary>
        /// id
        /// </summary>
        public string id = "";

        /// <summary>
        /// 全名
        /// </summary>
        [HideInInspector] public string agentName;

        /// <summary>
        /// 属性之是否可移动
        /// </summary>
        [HideInInspector] public bool isMovable = true;

        /// <summary>
        /// 颜色。默认白色
        /// </summary>
        public Color color = Color.white;

        /// <summary>
        /// Yee类型族
        /// </summary>
        [HideInInspector] public YeeFamily yeeFamily;

        public string YeeType;

        // public string YeeInterType;

        // /// <summary>
        // /// yee 2元素类型之性质
        // /// </summary>
        // public Yee2ETypeEnum yee2ETypeEnum = Yee2ETypeEnum.Yang;

        // /// <summary>
        // /// yee 3元素类型之性质
        // /// </summary>
        // public Yee3ETypeEnum yee3ETypeEnum = Yee3ETypeEnum.Rock;

        /// <summary>
        /// 质量。默认1f。
        /// </summary>
        public float mass = 1f;

        /// <summary>
        /// 尺寸。默认10f。
        /// </summary>
        public float size = 10f;

        /// <summary>
        /// 线性阻力，默认0.
        /// </summary>
        public float linearDrag = 0;

        /// <summary>
        /// 旋转阻力
        /// </summary>
        public float angularDrag = 0;

        /// <summary>
        /// 碰撞半径
        /// </summary>
        public float collisionRadius = 0.5f;

        /// <summary>
        /// 位置
        /// </summary>
        public Vector2 position;

        /// <summary>
        /// 速度
        /// </summary>
        public Vector2 velocity = new Vector2(0, 0);

        /// <summary>
        /// 最大速度
        /// </summary>
        public float maxSpeed = 20f;

        /// <summary>
        /// 最大角速度
        /// </summary>
        public float maxAngularSpeed = 20f;

        /// <summary>
        /// 初始速度
        /// </summary>
        public float initSpeed = 0f;

        /// <summary>
        /// 磁力大小
        /// </summary>
        public float magnitudeForce = -10f;

        /// <summary>
        /// 磁力影响半径
        /// </summary>
        public float magnitudeForceRadius = 5f;

        /// <summary>
        /// 物理材质之摩擦性
        /// </summary>
        public float physicsMaterialFriction = 0.0f;

        /// <summary>
        /// 物理材质之弹性
        /// </summary>
        public float physicsMaterialBounciness = 1.0f;

        [HideInInspector] public float energy = 1f;

        [HideInInspector] public Vector2 acceleration;
        [HideInInspector] public Vector2 momentum;
    }
}