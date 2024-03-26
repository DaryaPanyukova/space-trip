using SpaceShip.Entities.Deflector;
using SpaceShip.Entities.Engine;
using SpaceShip.Entities.Shell;

namespace SpaceShip.Entities.Ship;

public class Shuttle : ShipBase
{
    public Shuttle()
        : base(new List<IEngine> { new PulseEngineC() }, new ShellWeak(), new NullDeflector())
    {
    }
}