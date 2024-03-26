namespace SpaceShip.Entities.Deflector;

public class DeflectorNormal : DeflectorBase
{
    private const int MaxHitPoints = 100;

    public DeflectorNormal(bool isPhoton = false)
        : base(MaxHitPoints, isPhoton)
    {
    }
}