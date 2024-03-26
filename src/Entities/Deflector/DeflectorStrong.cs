namespace SpaceShip.Entities.Deflector;

public class DeflectorStrong : DeflectorBase
{
    private const int MaxHitPoints = 300;

    public DeflectorStrong(bool isPhoton = false)
    : base(MaxHitPoints, isPhoton)
    {
    }
}