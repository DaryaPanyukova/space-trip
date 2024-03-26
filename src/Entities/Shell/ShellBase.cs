using SpaceShip.Entities.Obstacle;

namespace SpaceShip.Entities.Shell;

public class ShellBase
{
    private int _hitPoints;

    protected ShellBase(int maxHitPoints)
    {
        _hitPoints = maxHitPoints;
    }

    public void CollideWith(HitObstacle obstacle)
    {
        if (obstacle == null)
        {
            throw new ArgumentNullException(nameof(obstacle));
        }

        int damage = _hitPoints > obstacle.LeftDamage ? obstacle.LeftDamage : _hitPoints;
        _hitPoints -= damage;
        obstacle.WasteDamage(damage);
    }

    public bool IsDestroyed() => _hitPoints == 0;
}