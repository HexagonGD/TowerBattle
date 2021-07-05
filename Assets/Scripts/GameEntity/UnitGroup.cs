namespace TowerBattle
{
    public struct UnitGroup
    {
        private readonly IOwner _owner;
        private readonly int _count;

        public IOwner Owner => _owner;
        public int Count => _count;

        public UnitGroup(IOwner owner, int count)
        {
            _owner = owner;
            _count = count;
        }
    }
}