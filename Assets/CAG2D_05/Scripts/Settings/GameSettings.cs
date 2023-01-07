using CAG2D_05;
using UnityEngine;

namespace CAG2D_05
{
    [CreateAssetMenu]
    public class GameSettings : ScriptableObject
    {
        /// <summary>
        /// 游戏维度
        /// </summary>
        public short dimention = 2;

        /// <summary>
        /// 个体初始数量
        /// </summary>
        public int numAgent = 10;

        /// <summary>
        /// 启动暂停时间
        /// </summary>
        public int pauseTime = 0;

        /// <summary>
        /// 围墙半径
        /// </summary>
        public float wallRadiu = 100;

        /// <summary>
        /// 围墙宽度
        /// </summary>
        public float wallWidth = 100;

        /// <summary>
        /// 围墙之摩擦性
        /// </summary>
        public float physicsMaterialsFriction = 0.0f;

        /// <summary>
        /// 围墙之弹性
        /// </summary>
        public float physicsMaterialsBounciness = 1.0f;

        /// <summary>
        /// Yee类型
        /// </summary>
        public YeeFamilyEnum yeeFamilyEnum = YeeFamilyEnum.Yee3E;

        // public YeeType YeeType = new YeeType();


        // public YeeFamily yeeFamily=new Yee3E();
        // public Yee yee=new Yee();
    }
}