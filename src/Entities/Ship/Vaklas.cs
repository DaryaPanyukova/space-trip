using SpaceShip.Entities.Deflector;
using SpaceShip.Entities.Engine;
using SpaceShip.Entities.Shell;

namespace SpaceShip.Entities.Ship;

public class Vaklas : ShipBase
{
    public Vaklas(bool isPhotonDeflector = false)
        : base(
            new List<IEngine> { new JumpEngineGamma(), new PulseEngineE() },
            new ShellNormal(),
            new DeflectorWeak(isPhotonDeflector))
    {
    }
}