using SpaceShip.Entities.Environment;
using SpaceShip.Entities.Ship;
using SpaceShip.Models;

namespace SpaceShip.Services;

public interface IHandleTravel
{
    public TravelStatistics Travel(ShipBase ship, params EnvironmentBase[] route);
}