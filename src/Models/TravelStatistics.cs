using SpaceShip.Exceptions;

namespace SpaceShip.Models;

public class TravelStatistics
{
    private FlightResult _result;

    public TravelStatistics(FlightResult result)
    {
        _result = result;
    }

    public double TimeSpent { get; private set; }
    public int MoneySpent { get; private set; }

    public bool IsAlive => _result == FlightResult.Success || _result == FlightResult.DeflectorDestroyed;

    public FlightResult Result
    {
        get => _result;
        private set { _result = value; }
    }

    public static TravelStatistics GetBestResult(
        TravelStatistics left,
        TravelStatistics right,
        bool prioritizeTime = true)
    {
        if (right == null)
        {
            throw new ArgumentNullException(nameof(right));
        }

        if (left == null)
        {
            throw new ArgumentNullException(nameof(left));
        }

        TravelStatistics? bestResult = new[] { left, right }
            .Where(result => result.IsAlive)
            .MinBy(stat => prioritizeTime ? stat.TimeSpent : stat.MoneySpent);

        return bestResult ?? left;
    }

    public void AddTime(double time)
    {
        if (time < 0)
        {
            throw new ArgumentException("Time cannot be negative.", nameof(time));
        }

        TimeSpent += time;
    }

    public void AddMoney(int money)
    {
        if (money < 0)
        {
            throw new ArgumentException("Money cannot be negative.", nameof(money));
        }

        MoneySpent += money;
    }

    public void UpdateResult(FlightResult value)
    {
        if ((value == FlightResult.Success && _result != FlightResult.Success) ||
            (value == FlightResult.DeflectorDestroyed &&
             !(_result == FlightResult.Success || _result == FlightResult.DeflectorDestroyed)))
        {
            throw new TravelStatusUpgrateException();
        }

        _result = value;
    }
}