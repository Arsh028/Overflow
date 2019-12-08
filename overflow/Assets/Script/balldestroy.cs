using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balldestroy : MonoBehaviour
{
    void Update()
    {
        if (gameObject.transform.position.y < -15f || gameObject.transform.position.x > 8f || gameObject.transform.position.x < -8f)
        {
            Debug.Log("game over");
            GameObject.Find("GameManager").GetComponent<GameManager>().GameHasEnded(); 
        }   
    }
   
    private void OnMouseDown()
    {
        Destroy(gameObject);
        GameObject.Find("GameManager").GetComponent<GameManager>().ScoreUp();
    }
}
