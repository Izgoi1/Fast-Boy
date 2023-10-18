using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GenerateLevel : MonoBehaviour
{
    [SerializeField] private GameObject roadTemplate;
    [SerializeField] private float speed;
    [SerializeField] private int roadNumber;

    private List<GameObject> roads = new List<GameObject>();
    private int maxSpeed = 10;
    private GameObject road;

    private void Start()
    {
        Vector3 pos = Vector3.zero;

        for (int i = 0; i < roadNumber; i++)
        {
            road = Instantiate(roadTemplate, pos, Quaternion.identity, transform);
            roads.Add(road);
            if (i >= 0)
            {
                pos = new Vector3(0, 0, roads[i].transform.position.z + 16f);
            }
        } 
    }

    private void Update()
    {
        RoadMovement();
        DeleteRoad();
    }

    private void RoadMovement()
    {
        foreach(GameObject road in roads)
        {
            road.transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
        }
    }

    private void DeleteRoad()
    {
        if (roads[0].transform.position.z < -14f)
        {
            Destroy(roads[0]);
            roads.RemoveAt(0);
            AddNewRoad();
        }
    }

    private void AddNewRoad()
    {
        Vector3 pos = new Vector3(0, 0, roads[roads.Count-1].transform.position.z + 16f);
        road = Instantiate(roadTemplate, pos, Quaternion.identity, transform);
        roads.Add(road);
    }

}
