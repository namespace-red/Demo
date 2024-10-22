using UnityEngine;

public class CyclicScaler : BasicCyclic
{
    private Transform _transform;
    
    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        _transform.localScale += Direction * DirectionMultiplier * Time.deltaTime;
        UpdateTimer();
    }
}
