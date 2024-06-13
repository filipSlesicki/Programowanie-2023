public enum ShootType
{
    /// <summary>
    /// Doesen't do anything
    /// </summary>
    None,
    /// <summary>
    /// Spawn and launch bullet
    /// </summary>
    Bullet,
    /// <summary>
    /// Shoot with raycast
    /// </summary>
    Ray,
    /// <summary>
    /// Spawn any object
    /// </summary>
    Spawn,
    /// <summary>
    /// Damage all targets in range (OverlapSphere)
    /// </summary>
    AllInRange
}
