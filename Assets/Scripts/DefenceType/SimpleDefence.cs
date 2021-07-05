using System.Collections.Generic;

namespace TowerBattle
{
    public class SimpleDefence : IDefenceType
    {
        UnitGroup IDefenceType.Fight(UnitGroup owner, UnitGroup attacker)
        {
            UnitGroup group;

            if(owner.Owner == attacker.Owner)
            {
                group = new UnitGroup(owner.Owner, owner.Count + attacker.Count);
            }
            else if(owner.Count > attacker.Count)
            {
                group = new UnitGroup(owner.Owner, owner.Count - attacker.Count);
            }
            else
            {
                group = new UnitGroup(attacker.Owner, attacker.Count - owner.Count);
            }

            return group;
        }

        List<IDefenceType> IDefenceType.GetPossibleUpgrade()
        {
            throw new System.NotImplementedException();
        }
    }
}