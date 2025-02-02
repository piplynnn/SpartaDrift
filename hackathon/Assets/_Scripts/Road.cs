using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Road : MonoBehaviour
{

    [SerializeField] private GameObject[] obstacles = new GameObject[8];
    static private int numberOfObstaclesOnRoad = 3;
    private int[] lanePositions = {-6, -3, 0, 3, 6};
    private GameObject[] generatedObstacles = new GameObject[numberOfObstaclesOnRoad];
    private Vector3[] generatedObstaclePositions = new Vector3[numberOfObstaclesOnRoad];
    public GameObject road1;
    public GameObject road2;

    int getRandomNumber(double start, double end) {
        return (int) Random.Range((int)start, (int)end);
    }
    GameObject getRandomObstacle() {
        return obstacles[(int)getRandomNumber(0, obstacles.Length - 1)];
    }

    bool verifyObstaclePositions() {
        for (int i = 0; i < generatedObstaclePositions.Length; i++) {
            for (int j = 0; j < generatedObstaclePositions.Length; j++) {
                if (j == i) { continue; }
                if ((generatedObstaclePositions[i] - generatedObstaclePositions[j]).magnitude <= 3) {
                    return false;
                }
            }
        }

        return true;
    } 

    void GenerateObstacles(GameObject road) {
        for (int i = 0; i < numberOfObstaclesOnRoad; i++) {
            GameObject randomObstacle = Instantiate(getRandomObstacle());
            generatedObstacles[i] = randomObstacle;
            do {
                randomObstacle.transform.position = new Vector3(lanePositions[getRandomNumber(0, lanePositions.Length - 1)], getRandomNumber(road.transform.position.y - (31.79 / 2), road.transform.position.y + (31.79 / 2)), transform.position.z);
                generatedObstaclePositions[i] = randomObstacle.transform.position;
                print((generatedObstaclePositions[i] - transform.position).magnitude);
            } while ((generatedObstaclePositions[i] - transform.position).magnitude < 10 && !verifyObstaclePositions());
        }
    }

    void DestroyObstacles(GameObject[] generatedObstacles) {
        foreach (GameObject obstacle in generatedObstacles) {
            Destroy(obstacle);
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

            //DestroyObstacles(generatedObstacles);
            GenerateObstacles(road1);    
        }
    }
}
