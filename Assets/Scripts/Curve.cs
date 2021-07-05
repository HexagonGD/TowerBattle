using System.Collections.Generic;
using UnityEngine;

namespace TowerBattle
{
    public readonly struct Curve
    {
        private readonly List<Vector3> points;

        public Curve(params Vector3[] points)
        {
            this.points = new List<Vector3>(points);
        }

        public Vector3 GetPoint(float value)
        {
            if (points.Count == 0)
            {
                throw new System.Exception("Точки не определены");
            }

            List<Vector3> currentPoints = points;
            List<Vector3> nextPoints = new List<Vector3>();

            while (currentPoints.Count > 1)
            {
                nextPoints.Clear();
                for (var i = 0; i < currentPoints.Count - 1; i++)
                {
                    var nextPoint = Vector3.Lerp(currentPoints[i], currentPoints[i + 1], value);
                    nextPoints.Add(nextPoint);
                }
                currentPoints = new List<Vector3>(nextPoints);
            }

            return currentPoints[0];
        }
    }
}