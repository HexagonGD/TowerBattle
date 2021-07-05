using TowerBattle.Events;
using UnityEngine;

namespace TowerBattle.Managers
{
    public class PlayerInput
    {
        private Tower _lastClickTower;

        public PlayerInput()
        {
            EventSystem.AddListener<TowerClickEvent>(this, OnTowerClick);
            Debug.Log("PlayerInput");
        }

        private void OnTowerClick(TowerClickEvent eventArg)
        {
            Debug.Log("OnTowerClick");
            if (_lastClickTower == null)
            {
                _lastClickTower = eventArg.tower;
                _lastClickTower.Select();
            }
            else if (_lastClickTower == eventArg.tower)
            {
                _lastClickTower.Deselect();
                _lastClickTower = null;
            }
            else
            {
                _lastClickTower.TrySendGroup(eventArg.tower);
                _lastClickTower.Deselect();
                _lastClickTower = null;
            }
        }
    }
}