using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeFactory : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    private void Awake()
    {
        _cubePrefab = _cubePrefab ?? throw new NullReferenceException(nameof(_cubePrefab));
    }

    public Cube Create(Vector3 position, Vector3 scale, float splitChance, Color color, Transform parent)
    {
        Cube newCube = Instantiate(_cubePrefab, position, Quaternion.identity, parent);
        newCube.Init(scale, color, splitChance);
        
        return newCube;
    }

    public Cube Create(Vector3 position, Vector3 scale, float splitChance, Transform parent)
    {
        return Create(position, scale, splitChance, GetColor(), parent);
    }


    public Cube Create(Cube oldCube, Vector3 position, Transform parent)
    {
        Vector3 scale = oldCube.transform.localScale / 2;
        Color color = GetColor();
        float splitChance = oldCube.SplitChance / 2;

        Cube newCube = Create(position, scale, splitChance, color, parent);
        newCube.Rigidbody.AddExplosionForce(_explosionForce, oldCube.transform.position, _explosionRadius);
        return newCube;
    }

    private Color GetColor()
        => Random.ColorHSV(); //(0f, 1f, 1f, 1f, 0.5f, 1f);
}
