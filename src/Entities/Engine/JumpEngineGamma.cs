namespace SpaceShip.Entities.Engine;

public class JumpEngineGamma : IEngine
{
    // fuel = coef * n^2; n = distance, coef = FuelWasteCoefficient
    private const int MaxJumpDistance = 700;
    private const int Speed = 40;
    private const int FuelWasteCoefficient = 1;
    private const int FuelCost = 50;

    public EngineType Type { get; set; } = EngineType.JumpEngine;
    public int CountMoney(int distance) => FuelWasteCoefficient * distance * distance * FuelCost;

    public double CountTime(int distance) => (float)distance / Speed;

    public bool CanJumpOver(int distance) => distance <= MaxJumpDistance;
}