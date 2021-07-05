using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerBattle
{
    public class Tower : MonoBehaviour
    {
        private IDefenceType _defenceType;
        private ISpawnerUnit _spawnerUnit;

        private UnitGroup _unitGroup;
        private List<Magistrale> _magistrales;

        private void OnMouseDown()
        {
            Debug.Log("Click");
        }

        private bool TrySendGroup(Tower tower, int count)
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
    }
}