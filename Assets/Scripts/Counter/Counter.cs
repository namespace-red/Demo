using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _cycleTime;

    private int _count;
    private Coroutine _activeCoroutine;

    public event Action<int> Changed;

    private int Count
    {
        get => _count;
        set
        {
            _count = value;
            Changed?.Invoke(_count);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == false)
            return;

        if (_activeCoroutine == null)
        {
            Restart();
        }
        else
        {
            Stop();
        }
    }

    private void Restart()
    {
        Stop();
        
        _activeCoroutine = StartCoroutine(RunChanging());
    }

    private void Stop()
    {
        if (_activeCoroutine == null)
            return;
        
        StopCoroutine(_activeCoroutine);
        _activeCoroutine = null;
    }
    
    private IEnumerator RunChanging()
    {
        var wait = new WaitForSeconds(_cycleTime);

        while (enabled)
        {
            Count++;
            yield return wait;
        }
    }
}
