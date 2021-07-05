using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerBattle
{
    public class SimpleSpawner : ISpawnerUnit
    {
        public const float _timeSpawn = 1f;

        private float _totalTime = 0;

        List<ISpawnerUnit> ISpawnerUnit.GetPossibleUpgrade() //TODO
        {
            throw new System.NotImplementedException();
        }

        bool ISpawnerUnit.TrySpawnUnit(out int countSpawnedUnit)
        {
            bool result = false;
            countSpawnedUnit = 0;

            _totalTime += Time.deltaTime;
            while(_totalTime > _timeSpawn)
            {
                countSpawnedUnit++;
                _totalTime -= _timeSpawn;
                result = true;
            }

            return result;
        }
    }
}