namespace SpaceShip.Entities.Obstacle;

public class SpaceWhale : HitObstacle
{
    private const int WhaleDamage = 300;

    public SpaceWhale(int number)
        : base(number * WhaleDamage)
    {
    }
}