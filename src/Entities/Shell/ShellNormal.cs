namespace SpaceShip.Entities.Shell;

public class ShellNormal : ShellBase
{
    private const int MaxHitPoints = 50;

    public ShellNormal()
        : base(MaxHitPoints)
    {
    }
}