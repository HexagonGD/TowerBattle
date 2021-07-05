using UnityEngine;

namespace TowerBattle.Managers
{
    public class Starter
    {
        [RuntimeInitializeOnLoadMethod]
        public static void StartGame()
        {
            new PlayerInput();
        }
    }
}