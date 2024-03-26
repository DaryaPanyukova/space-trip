namespace SpaceShip.Entities.Obstacle;

public class Asteroid : HitObstacle
{
    private const int AsteroidDamage = 10;

    public Asteroid(int number)
        : base(number * AsteroidDamage)
    {
    }
}