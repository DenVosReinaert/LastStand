using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Animator gridAnim;
    public GameObject lvlNextArrows;
    public List<GameObject> lvlNextArrowsList;

    public Rigidbody2D playerRb;

    public WaveManager waveManager;

    public double score;
    public int scoreDefault;
    public float scoreMult, scoreMultIncrease;
    public float scoreMultDefault;

    public TextMeshProUGUI scoreText, scoreMultText;

    private string dirTrigger;
    void Start()
    {
        score = scoreDefault;
        ResetScoreMult();
    }

    void Update()
    {
        scoreText.text = "Score: " + score;
        scoreMultText.text = "x" + scoreMult;
    }

    public void NextLevel(string directionTrigger)
    {
        dirTrigger = directionTrigger;

        gridAnim.SetTrigger(directionTrigger);
        gridAnim.SetTrigger("Next Level");

        lvlNextArrows.SetActive(false);
    }

    public void UpdateScore(int incomingScore)
    {
        score += incomingScore * scoreMult;
    }

    public void UpdateScoreMult()
    {
        scoreMult += scoreMultIncrease;
    }

    public void ResetScoreMult()
    {
        scoreMult = scoreMultDefault;
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

    public void StartNewWave()
    {
        waveManager.StartWave();
    }

    public void TriggerShop()
    {

    }
}
