using UnityEngine;

public abstract class BasicCyclic : MonoBehaviour
{
    [SerializeField] protected Vector3 Direction;
    
    [SerializeField] private float _cycleTime;
    
    protected int DirectionMultiplier = 1;
    
    private float _timeHasPassed;

    protected void UpdateTimer()
    {
        _timeHasPassed += Time.deltaTime;

        if (_timeHasPassed >= _cycleTime)
        {
            DirectionMultiplier *= -1;
            _timeHasPassed = 0;
        }
        
        if (NeedToChangeDirection())
        {
            DirectionMultiplier *= -1;
        }
    }

    private bool NeedToChangeDirection()
    {
        return (_timeHasPassed >= _cycleTime / 2) && (DirectionMultiplier == 1);
    }
}
