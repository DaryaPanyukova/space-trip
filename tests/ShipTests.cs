using SpaceShip.Entities.Ship;
using SpaceShip.Entities.Environment;
using SpaceShip.Models;
using SpaceShip.Services;
using Xunit;

namespace SpaceShip.Tests;

public class ShipTests
{
    [Theory]
    [MemberData(nameof(TestDataGenerator.Test1), MemberType = typeof(TestDataGenerator))]
    public void MediumDistanceTunnelTest(ShipBase ship, TravelStatistics correctResult)
    {
        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        if (correctResult == null)
        {
            throw new ArgumentNullException(nameof(correctResult));
        }

        // Arrange
        var tunnel = new Tunnel(700);

        var flight = new ShipFlight();

        // Act
        TravelStatistics result = flight.Travel(ship, tunnel);

        // Assert
        Assert.Equal(correctResult.Result, result.Result);
    }

    [Theory]
    [MemberData(nameof(TestDataGenerator.Test2), MemberType = typeof(TestDataGenerator))]
    public void FlashTest(ShipBase ship, TravelStatistics correctResult)
    {
        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        if (correctResult == null)
        {
            throw new ArgumentNullException(nameof(correctResult));
        }

        // Arrange
        var tunnel = new Tunnel(400);

        var flight = new ShipFlight();
        tunnel.AddFlash(1);

        // Act
        TravelStatistics result = flight.Travel(ship, tunnel);

        // Assert
        Assert.Equal(correctResult.Result, result.Result);
    }

    [Theory]
    [MemberData(nameof(TestDataGenerator.Test3), MemberType = typeof(TestDataGenerator))]
    public void WhaleTest(ShipBase ship, TravelStatistics correctResult)
    {
        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        if (correctResult == null)
        {
            throw new ArgumentNullException(nameof(correctResult));
        }

        // Arrange
        var nebula = new Nebula(400);
        nebula.AddWhale(1);
        var flight = new ShipFlight();

        // Act
        TravelStatistics result = flight.Travel(ship, nebula);

        // Assert
        Assert.Equal(correctResult.Result, result.Result);
    }

    [Fact]
    public void ShortSpaceShuttleVaklasTest()
    {
        // Arrange
        var space = new Space(300);
        var shuttle = new Shuttle();
        var vaklas = new Vaklas();
        var flight = new ShipFlight();

        // Act
        TravelStatistics shuttleResult = flight.Travel(shuttle, space);
        TravelStatistics vaklasResult = flight.Travel(vaklas, space);

        // Assert
        Assert.Equal(FlightResult.Success, shuttleResult.Result);
        Assert.Equal(FlightResult.Success, vaklasResult.Result);
        Assert.Equal(TravelStatistics.GetBestResult(shuttleResult, vaklasResult), vaklasResult);
    }

    [Fact]
    public void MediumNebulaAugurStellaTest()
    {
        // Arrange
        var tunnel = new Tunnel(700);
        var augur = new Augur();
        var stella = new Stella();
        var flight = new ShipFlight();

        // Act
        TravelStatistics augurResult = flight.Travel(augur, tunnel);
        TravelStatistics stellaResult = flight.Travel(stella, tunnel);

        // Assert
        Assert.Equal(FlightResult.ShipLost, augurResult.Result);
        Assert.Equal(FlightResult.Success, stellaResult.Result);
        Assert.Equal(TravelStatistics.GetBestResult(augurResult, stellaResult), stellaResult);
    }

    [Fact]
    public void NebulaShuttleVaklasTest()
    {
        // Arrange
        var nebula = new Nebula(400);
        var shuttle = new Shuttle();
        var vaklas = new Vaklas();
        var flight = new ShipFlight();

        // Act
        TravelStatistics shuttleResult = flight.Travel(shuttle, nebula);
        TravelStatistics vaklasResult = flight.Travel(vaklas, nebula);

        // Assert
        Assert.Equal(FlightResult.UnfinishedRoute, shuttleResult.Result);
        Assert.Equal(FlightResult.Success, vaklasResult.Result);
        Assert.Equal(TravelStatistics.GetBestResult(vaklasResult, shuttleResult), vaklasResult);
    }

    [Fact]
    public void SpaceVaklasMeredianTest()
    {
        // Arrange
        var meridian = new Meridian();
        var vaklas = new Vaklas();

        var space1 = new Space(1000);
        space1.AddMeteorite(2);
        space1.AddAsteroid(1);
        var space2 = new Space(1000);
        space2.AddMeteorite(2);
        space2.AddAsteroid(1);

        var flight = new ShipFlight();

        // Act
        TravelStatistics meridianResult = flight.Travel(meridian, space1);
        TravelStatistics vaklasResult = flight.Travel(vaklas, space2);

        // Assert
        Assert.Equal(FlightResult.Success, meridianResult.Result);
        Assert.Equal(FlightResult.DeflectorDestroyed, vaklasResult.Result);
        Assert.Equal(TravelStatistics.GetBestResult(vaklasResult, meridianResult), vaklasResult);
    }

    [Fact]
    public void FlashMeredianVaklasTest()
    {
        // Arrange
        var augur = new Augur(true);
        var vaklas = new Vaklas();

        var tunnel1 = new Tunnel(300);
        tunnel1.AddFlash(2);
        var tunnel2 = new Tunnel(300);
        tunnel2.AddFlash(2);

        var flight = new ShipFlight();

        // Act
        TravelStatistics augurResult = flight.Travel(augur, tunnel1);
        TravelStatistics vaklasResult = flight.Travel(vaklas, tunnel2);

        // Assert
        Assert.Equal(FlightResult.Success, augurResult.Result);
        Assert.Equal(FlightResult.CrewDead, vaklasResult.Result);
        Assert.Equal(TravelStatistics.GetBestResult(vaklasResult, augurResult), augurResult);
    }

    [Fact]
    public void SeveralSegmentsTest()
    {
        // Arrange
        var augur = new Augur();
        var stella = new Stella();

        var tunnel1 = new Tunnel(300);
        var space1 = new Space(500);
        var tunnel2 = new Tunnel(300);
        var space2 = new Space(500);

        var flight = new ShipFlight();

        // Act
        TravelStatistics augurResult = flight.Travel(augur, tunnel1, space1);
        TravelStatistics stellaResult = flight.Travel(stella, tunnel2, space2);

        // Assert
        Assert.Equal(FlightResult.Success, augurResult.Result);
        Assert.Equal(FlightResult.Success, stellaResult.Result);
        Assert.Equal(TravelStatistics.GetBestResult(stellaResult, augurResult), augurResult);
    }
}