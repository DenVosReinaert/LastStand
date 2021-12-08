using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heavy : MonoBehaviour, IDirectioning, IEnemy, IMobile
{
    public float speed { get; set; }
    public float speed_;

    public Animator anim;
    public Rigidbody2D rb;

    public Transform target { get; set; }
    public Transform target_;

    public Vector2 direction { get; set; }

    void Update()
    {
        SetContractFields();

        Chase();
        PositionAnimation();
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
    }
}