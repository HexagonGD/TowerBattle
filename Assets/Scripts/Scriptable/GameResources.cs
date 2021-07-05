using UnityEngine;

namespace TowerBattle
{
    [CreateAssetMenu(menuName = "TowerBattle/GameResources")]
    public class GameResources : ScriptableObject
    {
        [SerializeField] private Transport _transportPrefab;

        public Transport TransportPrefab => _transportPrefab;
    }
}