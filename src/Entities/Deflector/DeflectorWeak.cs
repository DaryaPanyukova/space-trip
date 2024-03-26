namespace SpaceShip.Entities.Deflector;

public class DeflectorWeak : DeflectorBase
{
    private const int MaxHitPoints = 25;

    public DeflectorWeak(bool isPhoton = false)
        : base(MaxHitPoints, isPhoton)
    {
    }
}