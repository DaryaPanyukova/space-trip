namespace SpaceShip.Entities.Shell;

public class ShellWeak : ShellBase
{
    private const int MaxHitPoints = 10;

    public ShellWeak()
        : base(MaxHitPoints)
    {
    }
}