using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _cycleTime;

    private int _count;
    private bool _isRunning;

    public UnityAction<int> Changed;

    private int Count
    {
        get => _count;
        set
        {
            _count = value;
            Changed?.Invoke(_count);
        }
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) == false)
            return;

        _isRunning = !_isRunning;
        StartCoroutine(StartChanging());
    }

    private IEnumerator StartChanging()
    {
        var wait = new WaitForSeconds(_cycleTime);

        while (_isRunning)
        {
            Count++;
            yield return wait;
        }
    }
}
