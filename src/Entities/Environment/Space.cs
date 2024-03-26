using SpaceShip.Entities.Engine;
using SpaceShip.Entities.Obstacle;

namespace SpaceShip.Entities.Environment;

public class Space : EnvironmentBase
{
    public Space(int length)
        : base(length)
    {
    }

    public void AddAsteroid(int number)
    {
        if (number < 0)
        {
            throw new ArgumentException("number of obstacles cannot be negative,", nameof(number));
        }

        AddObstacle(new Asteroid(number));
    }

    public void AddAsteroid(Asteroid asteroid) => AddObstacle(asteroid);

    public void AddMeteorite(int number)
    {
        if (number < 0)
        {
            throw new ArgumentException("number of obstacles cannot be negative,", nameof(number));
        }

        AddObstacle(new Meteorite(number));
    }

    public void AddMeteorite(Meteorite meteorite) => AddObstacle(meteorite);

    public override bool CanFlyIn(IEngine? engine)
    {
        if (engine == null)
        {
            return false;
        }

        return engine.Type == EngineType.PulseEngine;
    }
}