using SpaceShip.Entities.Engine;
using SpaceShip.Entities.Obstacle;

namespace SpaceShip.Entities.Environment;

public class Tunnel : EnvironmentBase
{
    public Tunnel(int length)
        : base(length)
    {
    }

    public void AddFlash(int number)
    {
        if (number < 0)
        {
            throw new ArgumentException("number of obstacles cannot be negative,", nameof(number));
        }

        AddObstacle(new Flash(number));
    }

    public void AddFlash(Flash flash) => AddObstacle(flash);

    public override bool CanFlyIn(IEngine? engine)
    {
        if (engine == null)
        {
            return false;
        }

        return engine.Type == EngineType.JumpEngine;
    }
}