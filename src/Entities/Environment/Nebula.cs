using SpaceShip.Entities.Engine;
using SpaceShip.Entities.Obstacle;

namespace SpaceShip.Entities.Environment;

public class Nebula : EnvironmentBase
{
    public Nebula(int length)
        : base(length)
    {
    }

    public void AddWhale(int number)
    {
        if (number < 0)
        {
            throw new ArgumentException("number of obstacles cannot be negative,", nameof(number));
        }

        AddObstacle(new SpaceWhale(number));
    }

    public void AddWhale(SpaceWhale whale) => AddObstacle(whale);

    public override bool CanFlyIn(IEngine? engine)
    {
        if (engine == null)
        {
            return false;
        }

        return engine is PulseEngineE;
    }
}