namespace SpaceShip.Entities.Engine;

public class PulseEngineE : IEngine
{
    // Speed = exp(t)
    private const int FuelWaste = 10;
    private const int StartFuelWaste = 20;
    private const int FuelCost = 30;

    public EngineType Type { get; set; } = EngineType.PulseEngine;
    public int CountMoney(int distance) => (StartFuelWaste + (FuelWaste * distance)) * FuelCost;

    public double CountTime(int distance) => Math.Log(distance + 1);

    public bool CanJumpOver(int distance) => false;
}