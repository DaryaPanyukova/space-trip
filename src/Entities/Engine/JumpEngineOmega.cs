namespace SpaceShip.Entities.Engine;

public class JumpEngineOmega : IEngine
{
    // fuel = coef * nlogn; n = distance, coef = FuelWasteCoefficient
    private const int MaxJumpDistance = 1500;
    private const int Speed = 40;
    private const int FuelWasteCoefficient = 15;
    private const int FuelCost = 50;

    public EngineType Type { get; set; } = EngineType.JumpEngine;

    public int CountMoney(int distance) =>
        FuelWasteCoefficient * distance * (int)Math.Ceiling(Math.Log(distance)) * FuelCost;

    public double CountTime(int distance) => (float)distance / Speed;

    public bool CanJumpOver(int distance) => distance <= MaxJumpDistance;
}