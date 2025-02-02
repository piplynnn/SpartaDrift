using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point_System : MonoBehaviour
{
    
    public int displayScore;
    public Text scoreUI;
    public bool waiter;
    public int multi;
    
    public PlayerController player;
    
   


    // Start is called before the first frame update
    void Start()
    {
        waiter = true;
        multi = 1;
     
        
    }

    public IEnumerator Addpoint()
   
    {
        if (waiter == true && player.done)
        {
            displayScore += multi;
            scoreUI.text = "Score: " + displayScore.ToString();
            waiter = false;
            yield return new WaitForSeconds(0.5f);
            waiter = true;
        }
     
    }


    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Addpoint());

    }
}
