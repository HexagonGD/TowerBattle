using UnityEngine;

namespace TowerBattle.Renderer
{
    public class TowerRenderer : IRenderer
    {
        private readonly SpriteRenderer _renderer;

        public TowerRenderer(SpriteRenderer renderer)
        {
            _renderer = renderer;
        }

        void IRenderer.Deselect()
        {
            _renderer.color = Color.white;
        }

        void IRenderer.Select()
        {
            _renderer.color = Color.red;
        }
    }
}