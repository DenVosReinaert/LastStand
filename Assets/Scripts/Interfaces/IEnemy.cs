using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    public void Chase();
    public Transform target { get; set; }
    public Vector2 direction { get; set; }
    public int damage { get; set; }

    public WaveManager waveManager { get; set; }
}
