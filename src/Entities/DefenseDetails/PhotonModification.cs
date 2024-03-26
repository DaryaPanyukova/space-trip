using SpaceShip.Entities.Obstacle;

namespace SpaceShip.Entities.DefenseDetails;

public class PhotonModification
{
    private const int MaxHits = 3;
    private int _hitsLeft = MaxHits;

    public void ReflectFlashes(Flash flash)
    {
        if (flash == null)
        {
            throw new ArgumentNullException(nameof(flash));
        }

        int reflectedCount = _hitsLeft > flash.Number ? flash.Number : _hitsLeft;
        _hitsLeft -= reflectedCount;
        flash.DecreaseNumber(reflectedCount);
    }
}