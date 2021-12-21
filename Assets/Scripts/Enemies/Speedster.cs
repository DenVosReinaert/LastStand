using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedster : MonoBehaviour, IDirectioning, IEnemy, IMobile, IKillable
{
    public float speed { get; set; }
    public float speed_;

    public Animator anim;
    public Rigidbody2D rb;

    public Transform target { get; set; }
    public Transform target_;

    public Vector2 direction { get; set; }

    public int health { get; set; }
    public int health_;

    public int damage { get; set; }
    public int damage_;
    public WaveManager waveManager { get; set; }
    public WaveManager waveManager_;

    public GameManager gameManager;
    public int scoreValue;

    void Awake()
    {
        target_ = GameObject.Find("Player").transform;
        waveManager_ = GameObject.Find("GameManager").transform.Find("WaveManager").GetComponent<WaveManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }
    void Update()
    {
        SetContractFields();

        Chase();
        PositionAnimation();

        if (health <= 0)
            Kill();
    }

    public void PositionAnimation()
    {
        anim.SetFloat("AnimMoveX", rb.velocity.x);
        anim.SetFloat("AnimMoveY", rb.velocity.y);
    }

    public void Chase()
    {
        direction = (target.position - this.transform.position).normalized;

        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }

    public void SetContractFields()
    {
        target = target_;
        speed = speed_;
        health = health_;
        damage = damage_;
        waveManager = waveManager_;

    }

    public void Die()
    {
        waveManager.totalSpawnCount--;

        Destroy(this.gameObject);
    }
    public void Kill()
    {
        gameManager.UpdateScore(scoreValue);
        Die();
    }

    public void Damage(int incomingDamage)
    {
        health -= incomingDamage;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<IKillable>().Damage(damage);

            Die();
        }
    }
}