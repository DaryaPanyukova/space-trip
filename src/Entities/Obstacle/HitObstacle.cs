using SpaceShip.Entities.Ship;

namespace SpaceShip.Entities.Obstacle;

public class HitObstacle : IObstacle
{
    public HitObstacle(int leftDamage)
    {
        LeftDamage = leftDamage;
    }

    public int LeftDamage { get; private set; }

    public void CollideWith(ShipBase ship)
    {
        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        ship.CollideWith(this);
    }

    public void WasteDamage(int wastedDamage) => LeftDamage -= LeftDamage - wastedDamage > 0 ? wastedDamage : LeftDamage;
}