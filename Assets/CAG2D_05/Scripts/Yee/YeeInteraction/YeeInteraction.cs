// using System.Drawing.Drawing2D;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra;

// using NumSharp;

namespace CAG2D_05
{
    internal class YeeInteraction
    {
        internal Matrix<double> DistanceMatrix;
        internal Matrix<int> IsInteractionMatrix;
        internal Matrix<double> ForceStrengthMatrix;
        internal Matrix<Vector2> ForceDirectionMatrix;
        internal Vector2 Point;

        public YeeInteraction(int totalAgent)
        {
            //TODO 构建矩阵描述粒子之间之距离
            // double[,] distanceMatrix = new double[gameSettings.numAgent * yeeType.NumElement, gameSettings.numAgent * yeeType.NumElement];
            this.DistanceMatrix = Matrix<double>.Build.Dense(totalAgent, totalAgent, 0.0);
            
            
            //TODO 构建矩阵描述粒子间是否有交互
            this.IsInteractionMatrix = Matrix<int>.Build.Dense(totalAgent, totalAgent, 0);

            //TODO 构建矩阵描述粒子间之力大小与方向
            this.Point = new Vector2(0,0);
            this.ForceStrengthMatrix = Matrix<double>.Build.Dense(totalAgent, totalAgent, 0.0);
            this.ForceDirectionMatrix = Matrix<Vector2>.Build.Dense(totalAgent, totalAgent, Point);
        }

        public void CalculateYeeInteraction()
        {
            
        }
        
    }
}