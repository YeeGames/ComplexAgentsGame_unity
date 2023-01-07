// using System.Drawing.Drawing2D;

// using Vector2 = System.Numerics.Vector2;
// using Vector3 = System.Numerics.Vector3;

using Numpy;
using Vector3 = UnityEngine.Vector3;


// using NumSharp;

namespace CAG2D_05
{
    internal class YeeInteraction
    {
        internal static Vector3 PointVector;
        internal static Vector3[] AgentsPosition;
        internal static int[] AgentsID;
        private static float _forceEffectiveRadius;

        internal static float[,] DistanceMatrix;
        internal static bool[,] IsInteractionMatrix;
        internal static Yee3EInterTypeEnum[,] YeeInterTypeMatrix;
        internal static float[,] ForceStrengthMatrix;
        internal static Vector3[,] ForceDirectionMatrix;
        private static int _numAgent;
        private static int _numDimension;

        // internal YeeInteraction(int numAgent, int numDimension)


        public static void Initialize(int numAgent, int numDimension, int[] agentsID)
        {
            _numAgent = numAgent;
            _numDimension = numDimension;
            AgentsID = new int[_numAgent];
            AgentsPosition = new Vector3[_numAgent];

            /// 初始化矩阵描述个体间之距离
            DistanceMatrix = new float[_numAgent, _numAgent];
            // DistanceMatrix = Matrix<float>.Build.Dense(_numAgent, _numAgent, 0.0f);

            /// 初始化矩阵描述个体间是否有交互
            IsInteractionMatrix = new bool[_numAgent, _numAgent];
            for (var i = 0; i < _numAgent; i++)
            {
                for (var j = 0; j < _numAgent; j++)
                {
                    IsInteractionMatrix[i, j] = false;
                }
            }


            /// 初始化矩阵描述个体间之力大小与方向
            PointVector = new Vector3(0, 0, 0);
            ForceStrengthMatrix = new float[_numAgent, _numAgent];
            ForceDirectionMatrix = new Vector3[_numAgent, _numAgent];
        }


        public static void CalculateYeeInteraction(Vector3[] agentsPosition)
        {
            YeeInteraction.AgentsPosition = agentsPosition;

            // float[] agentPosition01;
            // float[] agentPosition02;
            // _numAent = agentsPosition.GetLength(0);
            // _numDimension = agentsPosition.GetLength(1);


            for (var i = 0; i < _numAgent; i++)
            {
                for (var j = 0; j < _numAgent; j++)
                {
                    // agentPosition01 = agentsPosition[i];
                    // float[] agentsPosition_array = new float[] {agentsPosition[i].X,agentsPosition[i].Y};

                    /// 计算个体间之距离
                    DistanceMatrix[i, j] = Vector3.Distance(agentsPosition[i], agentsPosition[j]);

                    /// 计算个体间是否交互
                    if (DistanceMatrix[i, j] < _forceEffectiveRadius)
                    {
                        IsInteractionMatrix[i, j] = true;
                    }

                    /// TODO 计算个体间之YeeRule
                }
            }

            // Debug.Log("Distance Matrix: " + YeeInteraction.DistanceMatrix.ToString());
            // Debug.Log("DistanceMatrix size: (" + DistanceMatrix.GetLength(0) + "," + DistanceMatrix.GetLength(1) + ")");

        }
    }
}