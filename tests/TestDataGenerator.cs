using SpaceShip.Entities.Ship;
using SpaceShip.Models;

namespace SpaceShip.Tests;

public class TestDataGenerator : IEnumerable<object[]>
{
    public static IEnumerable<object[]> Test1()
    {
        yield return new object[]
        {
            new Shuttle(),
            new TravelStatistics(FlightResult.UnfinishedRoute),
        };

        yield return new object[]
        {
            new Augur(),
            new TravelStatistics(FlightResult.ShipLost),
        };
    }

    public static IEnumerable<object[]> Test2()
    {
        yield return new object[]
        {
            new Vaklas(),
            new TravelStatistics(FlightResult.CrewDead),
        };

        yield return new object[]
        {
            new Vaklas(true),
            new TravelStatistics(FlightResult.Success),
        };
    }

    public static IEnumerable<object[]> Test3()
    {
        yield return new object[]
        {
            new Vaklas(),
            new TravelStatistics(FlightResult.ShipDestroyed),
        };

        yield return new object[]
        {
            new Augur(true),
            new TravelStatistics(FlightResult.DeflectorDestroyed),
        };

        yield return new object[]
        {
            new Meridian(true),
            new TravelStatistics(FlightResult.Success),
        };
    }

    public IEnumerator<object[]> GetEnumerator() => Test1().GetEnumerator();

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
}