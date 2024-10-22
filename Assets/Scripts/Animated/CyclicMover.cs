using UnityEngine;

public class CyclicMover : BasicCyclic
{
    private Transform _transform;
    
    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        _transform.Translate(Direction * DirectionMultiplier * Time.deltaTime);
        UpdateTimer();
    }
}
