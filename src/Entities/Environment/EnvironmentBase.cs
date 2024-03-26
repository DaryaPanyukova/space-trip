using SpaceShip.Entities.Engine;
using SpaceShip.Entities.Obstacle;

namespace SpaceShip.Entities.Environment;

public abstract class EnvironmentBase
{
    private readonly List<IObstacle> _obstacles;

    protected EnvironmentBase(int length)
    {
        Length = length;
        _obstacles = new List<IObstacle>();
    }

    public int Length { get; init; }

    public IReadOnlyCollection<IObstacle> Obstacles => _obstacles;

    public abstract bool CanFlyIn(IEngine? engine);

    protected void AddObstacle(IObstacle obstacle)
    {
        if (obstacle == null)
        {
            throw new ArgumentNullException(nameof(obstacle));
        }

        _obstacles.Add(obstacle);
    }
}