using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GenerateLevel : MonoBehaviour
{

    [SerializeField] private GameObject[] roadTemplate;
    [SerializeField] private float speed;
    [SerializeField] private int roadNumber;

    private List<GameObject> roads = new List<GameObject>();
    private GameObject endRoad;
    private GameObject road;
    private int countEmptyRoad = 2;
    private int roadTemplateIndex;
    private void Start()
    {
        Vector3 pos = Vector3.zero;

        roadTemplateIndex = 0;

        for (int i = 0; i < roadNumber; i++)
        {
            road = Instantiate(roadTemplate[roadTemplateIndex], pos, Quaternion.identity, transform);
            roads.Add(road);

            endRoad = roads[roads.Count - 1].transform.Find("endRoad").gameObject;

            if (i >= 0)
            {
                pos = new Vector3(0, 0, endRoad.transform.position.z);
            }
            
            if (i >= countEmptyRoad-1)
            {
                roadTemplateIndex = Random.Range(1, roadTemplate.Length);
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
        if (roads[0].transform.position.z < -50f)
        {
            Destroy(roads[0]);
            roads.RemoveAt(0);
            AddNewRoad();
        }
    }

    private void AddNewRoad()
    {
        endRoad = roads[roads.Count - 1].transform.Find("endRoad").gameObject;

        Vector3 pos = new Vector3(0, 0, endRoad.transform.position.z);
        roadTemplateIndex = Random.Range(1, roadTemplate.Length);
        road = Instantiate(roadTemplate[roadTemplateIndex], pos, Quaternion.identity, transform);
        roads.Add(road);
    }

}
