namespace Constants
{
    public enum StatType
    {
        Health,
        Armor,
        Shield
    }

    public enum EnemyMovementPattern
    {
        SideToSide,
        VShaped,
        Circular,
        Forward
    }
    
    public enum EnemyType
    {
        BasicBombDrone,
        AdvancedBombDrone,
        SmallLaserDrone,
        AutoLaserDrone
    }

    public enum EnemySpawnType
    {
        Basic,
        Advanced,
        Boss
    }
}