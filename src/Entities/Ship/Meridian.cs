using SpaceShip.Entities.Deflector;
using SpaceShip.Entities.Engine;
using SpaceShip.Entities.Shell;

namespace SpaceShip.Entities.Ship;

public class Meridian : ShipBase
{
    public Meridian(bool isPhotonDeflector = false)
        : base(
            new List<IEngine> { new PulseEngineE() },
            new ShellNormal(),
            new DeflectorNormal(isPhotonDeflector),
            true)
    {
    }
}