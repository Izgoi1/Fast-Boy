using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnBarriers : MonoBehaviour
{
    [SerializeField] GameObject[] prefabBarriers;
    [SerializeField] List<Transform> spawnPoints;
    [SerializeField] private int numberOfBarriers;

    private int randomBarrier;

    private void Start()
    {
        spawnPoints = new List<Transform>(spawnPoints);
        spawnBarriers();
    }

    private void spawnBarriers()
    {
        for (int i = 0; i < numberOfBarriers; i++)
        {
            var spawn = Random.Range(0, spawnPoints.Count);
            randomBarrier = Random.Range(0, prefabBarriers.Length);
            Instantiate(prefabBarriers[randomBarrier], spawnPoints[spawn].transform.position, Quaternion.identity, transform);
            spawnPoints.RemoveAt(spawn);
        }
    }


}
