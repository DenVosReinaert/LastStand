using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public List<GameObject> healthUnits, shieldUnits = new List<GameObject>();

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void AdjustHealthBar(int playerHealth, int playerShields)
    {
        for (int i = 0; i < healthUnits.Count; i++)
        {
            if(i + 1 <= playerHealth)
            {
                healthUnits[i].SetActive(true);
            }
            else
            {
                healthUnits[i].SetActive(false);
            }
        }

        for (int i = 0; i < shieldUnits.Count; i++)
        {
            if (i + 1 <= playerShields)
            {
                shieldUnits[i].SetActive(true);
            }
            else
            {
                shieldUnits[i].SetActive(false);
            }
        }
    }
}
