namespace SpaceShip.Entities.Engine;

public class PulseEngineC : IEngine
{
    private const int FuelWaste = 9;
    private const int Speed = 20;
    private const int StartFuelWaste = 10;
    private const int FuelCost = 30;

    public EngineType Type { get; set; } = EngineType.PulseEngine;
    public int CountMoney(int distance) => (StartFuelWaste + (FuelWaste * distance)) * FuelCost;

    public double CountTime(int distance) => (double)distance / Speed;

    public bool CanJumpOver(int distance) => false;
}