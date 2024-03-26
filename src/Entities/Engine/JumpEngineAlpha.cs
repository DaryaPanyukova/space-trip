namespace SpaceShip.Entities.Engine;

public class JumpEngineAlpha : IEngine
{
    // fuel = coef * n; n = distance, coef = FuelWasteCoefficient
    private const int MaxJumpDistance = 300;
    private const int Speed = 40;
    private const int FuelWasteCoefficient = 10;
    private const int FuelCost = 50;

    public EngineType Type { get; set; } = EngineType.JumpEngine;

    public int CountMoney(int distance) => FuelWasteCoefficient * distance * FuelCost;

    public double CountTime(int distance) => (float)distance / Speed;

    public bool CanJumpOver(int distance) => distance <= MaxJumpDistance;
}