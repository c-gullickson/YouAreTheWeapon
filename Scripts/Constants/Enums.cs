namespace Constants
{
    public enum StatType
    {
        Health,
        Armor,
        Shield
    }

    public enum EnemyAttackType
    {
        Bomb,
        SimpleLaser,
        AutoLaser
    }

    public enum EnemyMovementPattern
    {
        SideToSide,
        V,
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