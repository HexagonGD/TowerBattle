using System.Collections.Generic;

namespace TowerBattle
{
    public interface IDefenceType
    {
        UnitGroup Fight(UnitGroup owner, UnitGroup attacker);
        List<IDefenceType> GetPossibleUpgrade();
    }
}