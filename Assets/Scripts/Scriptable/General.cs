using UnityEngine;

namespace TowerBattle
{
    public class General
    {
        private static General _instance;
        public static General Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new General();
                }

                return _instance;
            }
        }

        private GameResources _gameResources;
        public GameResources GameResources => _gameResources;

        private General()
        {
            _instance = this;
            _gameResources = Resources.Load<GameResources>("GameResources");
        }
    }
}