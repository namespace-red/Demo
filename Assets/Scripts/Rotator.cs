using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector3 _speed;
    
    private Transform _transform;
    
    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        _transform.Rotate(_speed * Time.deltaTime);
    }
}
