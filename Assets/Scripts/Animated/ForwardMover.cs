using UnityEngine;

public class ForwardMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Transform _transform;
    
    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        _transform.Translate(_transform.forward * _speed * Time.deltaTime);
    }
}
