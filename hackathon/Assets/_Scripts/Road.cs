using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{

    [SerializeField] private GameObject[] obstacles = new GameObject[8];
    [SerializeField] private int numberOfObstaclesOnRoad = 2;
    private int[] lanePositions = {-6, -3, 0, 3, 6};
    public GameObject road1;
    public GameObject road2;

    int getRandomNumber(double start, double end) {
        return (int) Random.Range((int)start, (int)end);
    }
    GameObject getRandomObstacle() {
        return obstacles[(int)getRandomNumber(0, obstacles.Length - 1)];
    }

    void GenerateObstacles(GameObject road) {
        for (int i = 0; i < numberOfObstaclesOnRoad; i++) {
            GameObject randomObstacle = Instantiate(getRandomObstacle());

            randomObstacle.transform.position = new Vector3(lanePositions[getRandomNumber(0, lanePositions.Length - 1)], getRandomNumber(road.transform.position.y - (31.79 / 2), road.transform.position.y + (31.79 / 2)), transform.position.z); 
        }
    }

    void Start() {
        GenerateObstacles(road1);
    }
   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == road1)
        {
            road2.transform.position = new Vector3(road2.transform.position.x, 
                road1.transform.position.y +31.79f ,road2.transform.position.z);
            
            GenerateObstacles(road2);
            Debug.Log(other.gameObject.name);
        }
        else if(other.gameObject == road2)
        {
            road1.transform.position = new Vector3(road2.transform.position.x, 
                road2.transform.position.y +31.79f ,road1.transform.position.z);

            GenerateObstacles(road1);    
        }
    }
}
