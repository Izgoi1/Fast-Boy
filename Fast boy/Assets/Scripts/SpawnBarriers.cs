using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnBarriers : MonoBehaviour
{
    [SerializeField] GameObject[] prefabBarriers;
    [SerializeField] List<Transform> spawnPoints;
    [SerializeField] private int numberOfBarriers;

    private int countingBarriers;
    private int randomBarrier;
    private int index;

    private void Start()
    {
        spawnPoints = new List<Transform>(spawnPoints);
        spawnBarriers();
    }

    private void spawnBarriers()
    {
        for (int i = 0; i < numberOfBarriers; i++)
        {
            var spawn = UnityEngine.Random.Range(0, spawnPoints.Count);
            randomBarrier = UnityEngine.Random.Range(0, prefabBarriers.Length);
            Instantiate(prefabBarriers[randomBarrier], spawnPoints[spawn].transform.position, Quaternion.identity, transform);
            spawnPoints.RemoveAt(spawn);

            if (randomBarrier == prefabBarriers.Length - 1)
            {
                countingBarriers++;
            }

            if (countingBarriers >= 2)
            {
                index = prefabBarriers.Length - 1;
                RemoveElement(ref prefabBarriers, index);
            }
        }
    }

    private void RemoveElement<L>(ref L[] arr, int index)
    {
        for (int i = index; i < arr.Length - 1; i++)
        {
            arr[i] = arr[i + 1];
        }

        Array.Resize(ref arr, arr.Length - 1);  
    }

}
