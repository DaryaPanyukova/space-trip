namespace SpaceShip.Exceptions;

public class TravelStatusUpgrateException : Exception
{
    public TravelStatusUpgrateException()
    {
    }

    public TravelStatusUpgrateException(string message)
        : base(message)
    {
    }

    public TravelStatusUpgrateException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}