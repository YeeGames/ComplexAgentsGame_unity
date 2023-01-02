using UnityEngine;

namespace CAG2D_05
{
    [CreateAssetMenu]
    public class RuleSettings : ScriptableObject
    {
        /// <summary>
        /// Yee类型族
        /// </summary>
        public YeeType YeeType = new YeeType();

        // public YeeTypeFamilyEnum yeeTypeFamily;
        // public YeeRule yeeRule;
        // public bool isEnableForce;
        public float forceStrength = 10f; // 力场强度；
        public float forceEffectiveRadius = 5f; // 力场影响半径；
        public float expCoefficient = 2f; // 力场衰减指数系数；
        public int direction = 1;
    }
}