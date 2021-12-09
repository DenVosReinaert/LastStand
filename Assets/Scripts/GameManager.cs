using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Animator gridAnim;
    public GameObject lvlNextArrows;
    public List<GameObject> lvlNextArrowsList;

    public Rigidbody2D playerRb;

    private string dirTrigger;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void NextLevel(string directionTrigger)
    {
        dirTrigger = directionTrigger;

        gridAnim.SetTrigger(directionTrigger);
        gridAnim.SetTrigger("Next Level");

        lvlNextArrows.SetActive(false);
    }

    public void SetPlayerPos()
    {
        switch(dirTrigger)
        {
            case ("Level Up"):
                playerRb.MovePosition(lvlNextArrowsList[1].transform.position);
                break;

            case ("Level Down"):
                playerRb.MovePosition(lvlNextArrowsList[0].transform.position);
                break;

            case ("Level Left"):
                playerRb.MovePosition(lvlNextArrowsList[3].transform.position);
                break;

            case ("Level Right"):
                playerRb.MovePosition(lvlNextArrowsList[2].transform.position);
                break;

        }
    }

    public void TriggerShop()
    {

    }
}
