using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour

{
    public GameObject road1;
    public GameObject road2;
    

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject == road1)
        {
            road2.transform.position = new Vector3(road2.transform.position.x, 
                road1.transform.position.y +31.79f ,road2.transform.position.z);
            
            Debug.Log(other.gameObject.name);
        }
        else if(other.gameObject == road2)

        {
            road1.transform.position = new Vector3(road2.transform.position.x, 
                road2.transform.position.y +31.79f ,road1.transform.position.z);

            
        }
    }
}
