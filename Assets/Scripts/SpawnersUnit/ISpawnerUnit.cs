using System.Collections.Generic;

namespace TowerBattle
{
    public interface ISpawnerUnit
    {
        bool TrySpawnUnit(out int countSpawnedUnit);
        List<ISpawnerUnit> GetPossibleUpgrade();
    }
}