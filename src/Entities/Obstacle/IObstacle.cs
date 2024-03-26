using SpaceShip.Entities.Ship;

namespace SpaceShip.Entities.Obstacle;

public interface IObstacle
{
    public void CollideWith(ShipBase ship);
}
