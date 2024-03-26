using SpaceShip.Entities.DefenseDetails;
using SpaceShip.Entities.Obstacle;

namespace SpaceShip.Entities.Deflector;

public class DeflectorBase
{
    private int _hitPoints;

    private PhotonModification? _photonModification;

    protected DeflectorBase(int maxHitPoints, bool isPhoton = false)
    {
        _hitPoints = maxHitPoints;
        if (isPhoton)
        {
            _photonModification = new PhotonModification();
        }
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

    public void CollideWith(Flash flash)
    {
        if (flash == null)
        {
            throw new ArgumentNullException(nameof(flash));
        }

        _photonModification?.ReflectFlashes(flash);
    }

    public bool IsDestroyed() => _hitPoints == 0;
}