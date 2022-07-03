using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    private SpawnPoint[] _spawnPoints;

    private void Awake()
    {
        _spawnPoints = FindObjectsOfType<SpawnPoint>();
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var delay = new WaitForSeconds(2);
        int index = 0;

        while (true)
        {
            Instantiate(_enemy, _spawnPoints[index].transform);
            index++;

            if (index == _spawnPoints.Length)
            {
                index = 0;
            }

            yield return delay;
        }  
    }
}
