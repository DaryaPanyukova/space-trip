namespace SpaceShip.Entities.Engine;

public interface IEngine
{
    public EngineType Type { get;  set; }
    public int CountMoney(int distance);
    public double CountTime(int distance);

    public bool CanJumpOver(int distance);
}