using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelNext : MonoBehaviour
{
    public GameManager gameMngr;
    public string directionTrigger;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            gameMngr.NextLevel(directionTrigger);

            Debug.Log("Player Has Entered an Arrow");
        }

        Debug.Log("STOP TOUCHING ME");
    }
}
