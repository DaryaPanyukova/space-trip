using SpaceShip.Entities.Deflector;
using SpaceShip.Entities.Engine;
using SpaceShip.Entities.Obstacle;
using SpaceShip.Entities.Shell;
using SpaceShip.Exceptions;
using SpaceShip.Models;

namespace SpaceShip.Entities.Ship;

public abstract class ShipBase
{
    private readonly List<IEngine> _engines;

    protected ShipBase(
        IReadOnlyCollection<IEngine> engines,
        ShellBase shell,
        DeflectorBase? deflector,
        bool hasEmitter = false)
    {
        if (engines == null || engines.Count == 0)
        {
            throw new NoEngineShipException();
        }

        Shell = shell ?? throw new ArgumentNullException(nameof(shell));
        _engines = new List<IEngine>(engines);
        Deflector = deflector ?? new NullDeflector();
        HasAntiNitrineEmitter = hasEmitter;
        Statistics = new TravelStatistics(FlightResult.Success);
    }

    public IReadOnlyCollection<IEngine> Engines => _engines;
    public ShellBase Shell { get; init; }
    public DeflectorBase Deflector { get; init; }

    public bool HasAntiNitrineEmitter { get; init; }

    public TravelStatistics Statistics { get; init; }

    public void CollideWith(HitObstacle obstacle)
    {
        if (obstacle is SpaceWhale)
        {
            if (HasAntiNitrineEmitter)
            {
                return;
            }
        }

        Deflector.CollideWith(obstacle);
        Shell.CollideWith(obstacle);
        if (Shell.IsDestroyed())
        {
            Statistics.UpdateResult(FlightResult.ShipDestroyed);
        }
        else if (Deflector.IsDestroyed())
        {
            Statistics.UpdateResult(FlightResult.DeflectorDestroyed);
        }
    }

    public void CollideWith(Flash flash)
    {
        Deflector.CollideWith(flash);
        if (flash.Number > 0)
        {
            Statistics.UpdateResult(FlightResult.CrewDead);
        }
    }
}