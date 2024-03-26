using SpaceShip.Entities.Deflector;
using SpaceShip.Entities.Engine;
using SpaceShip.Entities.Shell;

namespace SpaceShip.Entities.Ship;

public class Augur : ShipBase
{
    public Augur(bool isPhotonDeflector = false)
        : base(
            new List<IEngine> { new JumpEngineAlpha(), new PulseEngineE() },
            new ShellStrong(),
            new DeflectorStrong(isPhotonDeflector))
    {
    }
}