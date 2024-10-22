using System;
using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;
    
    private void Awake()
    {
        _text = _text ?? throw new NullReferenceException(nameof(_text));
        _counter = _counter ?? throw new NullReferenceException(nameof(_counter));
    }

    private void OnEnable()
        => _counter.Changed += SetCount;

    private void OnDisable()
        => _counter.Changed -= SetCount;

    private void SetCount(int count)
        => _text.text = count.ToString();
}
