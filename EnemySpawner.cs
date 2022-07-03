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
        int i = 0;
        while (true)
        {
            Instantiate(_enemy, _spawnPoints[i].transform);
            i++;

            if (i == _spawnPoints.Length)
            {
                i = 0;
            }

            yield return new WaitForSeconds(2);
        }  
    }
}
