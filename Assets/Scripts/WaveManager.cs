using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public bool waveOnGoing, waveFinished;
    public int waveNumber;

    public int spawnIntervalMin, spawnIntervalMax;
    private float spawnInterval, timePassed;
    public List<Transform> spawnLocations;
    public List<GameObject> spawnTypes;

    private GameManager gameManager;

    public TextMeshProUGUI waveText;

    [Space]
    [HideInInspector]
    public int spwnCntHvy, spwnCntBrt, spwnCntSpd, spwnCntGrnt, spwnCntBss;

    public int totalSpawnCount, rnd;

    [Space]
    [Header("Spawn Multipliers")]
    public float spwnMltHvy, spwnMltBrt, spwnMltSpd, spwnMltGrnt;
    void Start()
    {
        gameManager = this.GetComponentInParent<GameManager>();
    }

    void Update()
    {
        waveText.text = "Wave " + (waveNumber + 1);

        if (waveFinished)
            waveOnGoing = false;

        if (waveOnGoing && totalSpawnCount == 0 && !waveFinished)
        {
            EndOfWave();
        }


        //This should never be enabled, if you have to enable this then something is going horribly wrong.
        //The totalSpawnCount should not be capable of being lower than 0, as 1 is deducted from a total that is set right at the start of a wave.
        //The amount of deductions should therefore be the exact same as the amount determined at the start of a wave.
        /*
        if (totalSpawnCount < 0)
            totalSpawnCount = 0;
        */

        if (waveOnGoing && totalSpawnCount > 0 && !waveFinished)
        {

            if (timePassed >= spawnInterval * 60f)
            {
                SpawnNextEnemy();
            }

            timePassed++;
        }

    }

    public void SetSpawnCounts()
    {
        waveNumber++;

        spwnCntHvy = (int)(1 * spwnMltHvy * waveNumber);
        spwnCntBrt = (int)(1 * spwnMltBrt * waveNumber);
        spwnCntGrnt = (int)(1 * spwnMltGrnt * waveNumber) + 1;
        spwnCntSpd = (int)(1 * spwnMltSpd * waveNumber) + 2;
        spwnCntBss = (int)waveNumber / 5;

        totalSpawnCount = spwnCntHvy + spwnCntBrt + spwnCntGrnt + spwnCntSpd + spwnCntBss;
    }

    public void SpawnNextEnemy()
    {

        rnd = Mathf.Clamp((int)Random.Range(0f, 5f), 0, 3);

        if (rnd == 0 && spwnCntHvy > 0)
        {
            Instantiate(spawnTypes[0], spawnLocations[(int)Random.Range(0, 4)]);
            spwnCntHvy--;

        }
        else
        if (rnd == 1 && spwnCntBrt > 0)
        {
            Instantiate(spawnTypes[1], spawnLocations[(int)Random.Range(0, 3)]);
            spwnCntBrt--;

        }
        else
        if (rnd == 2 && spwnCntGrnt > 0)
        {
            Instantiate(spawnTypes[2], spawnLocations[(int)Random.Range(0, 3)]);
            spwnCntGrnt--;

        }
        else
        if (rnd == 3 && spwnCntSpd > 0)
        {
            Instantiate(spawnTypes[3], spawnLocations[(int)Random.Range(0, 3)]);
            spwnCntSpd--;

        }
        else
        if (rnd == 4 && spwnCntBss > 0)
        {
            Instantiate(spawnTypes[4], spawnLocations[(int)Random.Range(0, 3)]);
            spwnCntBss--;
        }


        timePassed = 0f;
        spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
    }

    public void EndOfWave()
    {
        if (waveNumber % 2 == 0)
            gameManager.TriggerShop();

        waveFinished = true;
        gameManager.lvlNextArrows.SetActive(true);
    }

    public void StartWave()
    {
        SetSpawnCounts();

        waveFinished = false;
        waveOnGoing = true;
    }
}
