using System.Collections.Generic;
using TowerBattle.Events;
using TowerBattle.Renderer;
using UnityEngine;

namespace TowerBattle
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Tower : MonoBehaviour
    {
        private IDefenceType _defenceType;
        private ISpawnerUnit _spawnerUnit;
        private IRenderer _renderer;

        private UnitGroup _unitGroup;
        [SerializeField] private List<Magistrale> _magistrales;

        private void Awake()
        {
            _unitGroup = new UnitGroup(new Player(), 10);
            _defenceType = new SimpleDefence();
            _spawnerUnit = new SimpleSpawner();
            _renderer = new TowerRenderer(GetComponent<SpriteRenderer>());
        }

        private void Update()
        {
            if(_spawnerUnit.TrySpawnUnit(out var countSpawnedUnit))
            {
                _unitGroup = new UnitGroup(_unitGroup.Owner, _unitGroup.Count + countSpawnedUnit);
            }
        }

        private void OnMouseDown()
        {
            EventSystem.Execute(new TowerClickEvent(this));
        }

        public bool TrySendGroup(Tower tower) => TrySendGroup(tower, _unitGroup.Count);

        public bool TrySendGroup(Tower tower, int count)
        {
            if (_unitGroup.Count == 0 || _unitGroup.Count < count) return false;

            foreach(var magistrale in _magistrales)
            {
                if(magistrale.TryGetNeigbourTower(this, out var neigbourTower))
                {
                    if (neigbourTower != tower) continue;
                    var group = new UnitGroup(_unitGroup.Owner, count);
                    _unitGroup = new UnitGroup(_unitGroup.Owner, _unitGroup.Count - count);
                    magistrale.AcceptGroup(this, group);
                    return true;
                }
            }

            return false;
        }

        public void Select() => _renderer.Select();
        public void Deselect() => _renderer.Deselect();
    }
}