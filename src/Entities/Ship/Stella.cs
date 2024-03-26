using SpaceShip.Entities.Deflector;
using SpaceShip.Entities.Engine;
using SpaceShip.Entities.Shell;

namespace SpaceShip.Entities.Ship;

public class Stella : ShipBase
{
    public Stella(bool isPhotonDeflector = false)
        : base(
            new List<IEngine> { new JumpEngineOmega(), new PulseEngineC() },
            new ShellWeak(),
            new DeflectorWeak(isPhotonDeflector))
    {
    }
}