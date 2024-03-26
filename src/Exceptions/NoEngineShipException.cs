namespace SpaceShip.Exceptions;

public class NoEngineShipException : Exception
{
    public NoEngineShipException()
    {
    }

    public NoEngineShipException(string message)
        : base(message)
    {
    }

    public NoEngineShipException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
