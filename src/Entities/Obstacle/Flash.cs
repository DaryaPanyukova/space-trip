using SpaceShip.Entities.Ship;

namespace SpaceShip.Entities.Obstacle;

public class Flash : IObstacle
{
    public Flash(int number)
    {
        Number = number;
    }

    public int Number { get; private set; }

    public void CollideWith(ShipBase ship)
    {
        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        ship.CollideWith(this);
    }

    public void DecreaseNumber(int number) => Number -= Number - number > 0 ? number : Number;
}