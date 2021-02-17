using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private Enemy _enemyTemplate;
    [SerializeField] private float _timeBetweenSpawn;

    private int _indexLastSpawnPoint = 0;

    private void Start()
    {
        StartCoroutine(LogicSpawn());
    }

    private IEnumerator LogicSpawn()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(_timeBetweenSpawn);
        }
    }

    private void Spawn()
    {
        Instantiate(_enemyTemplate, _spawnPoints[_indexLastSpawnPoint].transform.position, Quaternion.identity);
        _indexLastSpawnPoint++;
        if (_indexLastSpawnPoint >= _spawnPoints.Count)
            _indexLastSpawnPoint = 0;
    }
}
