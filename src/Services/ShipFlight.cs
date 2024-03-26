using SpaceShip.Entities.Engine;
using SpaceShip.Entities.Environment;
using SpaceShip.Entities.Obstacle;
using SpaceShip.Entities.Ship;
using SpaceShip.Models;

namespace SpaceShip.Services;

public class ShipFlight : IHandleTravel
{
    public TravelStatistics Travel(ShipBase ship, params EnvironmentBase[] route)
    {
        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        if (route == null)
        {
            throw new ArgumentNullException(nameof(route));
        }

        foreach (EnvironmentBase environment in route)
        {
            GoTrough(ship, environment);
            if (!ship.Statistics.IsAlive)
            {
                break;
            }
        }

        return ship.Statistics;
    }

    private static void GoTrough(ShipBase ship, EnvironmentBase environment)
    {
        IEngine? engine = null;
        bool canFlyIn = false;
        foreach (IEngine tryEngine in ship.Engines)
        {
            if (environment.CanFlyIn(tryEngine))
            {
                canFlyIn = true;
                if (environment is Tunnel)
                {
                    engine = tryEngine.CanJumpOver(environment.Length) ? tryEngine : engine;
                }
                else
                {
                    engine = tryEngine;
                }
            }
        }

        if (canFlyIn && engine == null)
        {
            ship.Statistics.UpdateResult(FlightResult.ShipLost);
        }

        if (!canFlyIn)
        {
            ship.Statistics.UpdateResult(FlightResult.UnfinishedRoute);
        }

        if (!ship.Statistics.IsAlive)
        {
            return;
        }

        foreach (IObstacle obstacle in environment.Obstacles)
        {
            obstacle.CollideWith(ship);

            if (!ship.Statistics.IsAlive)
            {
                return;
            }
        }

        ship.Statistics.AddTime(engine?.CountTime(environment.Length) ?? 0);
        ship.Statistics.AddMoney(engine?.CountMoney(environment.Length) ?? 0);
    }
}