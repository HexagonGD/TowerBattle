namespace TowerBattle.Events
{
    public readonly struct TowerClickEvent
    {
        public readonly Tower tower;

        public TowerClickEvent(Tower tower)
        {
            this.tower = tower;
        }
    }
}