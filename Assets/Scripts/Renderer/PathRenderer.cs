using System.Collections.Generic;
using UnityEngine;

namespace TowerBattle.Renderer
{
    public class PathRenderer : IRenderer
    {
        public const int CountSegments = 100;

        private readonly LineRenderer _renderer;
        private readonly Curve _curve;

        public PathRenderer(LineRenderer renderer, Curve curve)
        {
            _renderer = renderer;
            _curve = curve;
        }

        void IRenderer.Deselect()
        {
            _renderer.positionCount = 0;
        }

        void IRenderer.Select()
        {
            _renderer.positionCount = CountSegments;
            for (var i = 0; i < CountSegments; i++)
            {
                _renderer.SetPosition(i, _curve.GetPoint((float)i / CountSegments));
            }
        }
    }
}