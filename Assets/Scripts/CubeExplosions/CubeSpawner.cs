using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Collider _spawnZone;
    [SerializeField] private Transform _cubeParent;
    [SerializeField] private int _minSpawnCubs;
    [SerializeField] private int _maxSpawnCubs;
    [SerializeField] private CubeFactory _cubeFactory;
    [SerializeField] private Vector3 _startScale;
    [SerializeField] private float _startSplitChance;

    private void Awake()
    {
        int spawnCubeNumber = GetSpawnNumber();
        
        for (int i = 0; i < spawnCubeNumber; i++)
        {
            Vector3 spawnPosition = GetSpawnPosition(_startScale);
            var newCube = _cubeFactory.Create(spawnPosition, _startScale, _startSplitChance, _cubeParent);
            newCube.Exploded += OnCubeExploded;
        }
    }

    private void OnCubeExploded(Cube explodedCube)
    {
        explodedCube.Exploded -= OnCubeExploded;
        
        int spawnCubeNumber = GetSpawnNumber();
        
        for (int i = 0; i < spawnCubeNumber; i++)
        {
            Vector3 spawnPosition = GetSpawnPosition(explodedCube.transform.localScale / 2);
            var newCube = _cubeFactory.Create(explodedCube, spawnPosition, _cubeParent);
            newCube.Exploded += OnCubeExploded;
        }
    }

    private Vector3 GetSpawnPosition(Vector3 scale)
    {
        Vector3 newPosition;
        bool isPositionTaken;
        
        do
        {
            newPosition = GetRandomPosition();
            isPositionTaken = Physics.BoxCast(newPosition, scale / 2, Vector3.zero);
        } while (isPositionTaken);

        return newPosition;
    }

    private int GetSpawnNumber()
        => Random.Range(_minSpawnCubs, _maxSpawnCubs);

    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(_spawnZone.bounds.min.x, _spawnZone.bounds.max.x);
        float z = Random.Range(_spawnZone.bounds.min.z, _spawnZone.bounds.max.z);
        float y = _spawnZone.bounds.center.y;
        
        return new Vector3(x, y, z);
    }
}
