namespace SpaceShip.Entities.Obstacle;

public class Meteorite : HitObstacle
{
    private const int MeteoriteDamage = 25;

    public Meteorite(int number)
        : base(number * MeteoriteDamage)
    {
    }
}