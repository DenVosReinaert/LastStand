using UnityEngine;

public class Player : MonoBehaviour, IDirectioning, IMobile, IKillable
{
    public float speed { get; set; }
    public float speed_;

    public Animator anim;
    public Rigidbody2D rb;

    public int health { get; set; }
    public int health_;
    public int shields;

    public UI ui;

    void Start()
    {
        SetContractFields();

        ui.AdjustHealthBar(health, shields);
    }

    // Update is called once per frame
    void Update()
    {
        SetContractFields();

        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed;

        PositionAnimation();

        if (health <= 0)
        {
            Die();
        }
    }

    public void PositionAnimation()
    {
        anim.SetFloat("AnimMoveX", rb.velocity.x);
        anim.SetFloat("AnimMoveY", rb.velocity.y);
    }

    public void SetContractFields()
    {
        speed = speed_;
        health = health_;
    }

    public void Die()
    {

    }

    public void Damage(int incomingDamage)
    {
        int remainingDamage = new int();

        remainingDamage = incomingDamage - shields;

        shields = (int)Mathf.Clamp(shields - incomingDamage, 0f, 2f);
        health = (int)Mathf.Clamp(health - remainingDamage, 0f, 5f);

        health_ = health;
        Debug.Log("Health: " + health + " Shields: " + shields);

        ui.AdjustHealthBar(health, shields);
    }
}
