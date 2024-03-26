namespace SpaceShip.Entities.Shell;

public class ShellStrong : ShellBase
{
    private const int MaxHitPoints = 200;

    public ShellStrong()
        : base(MaxHitPoints)
    {
    }
}