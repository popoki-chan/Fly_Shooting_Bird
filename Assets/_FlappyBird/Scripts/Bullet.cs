using System;
using GameTool;
using UnityEngine;

public class Bullet : BasePooling
{
    [SerializeField] private Rigidbody2D rb;
    private float speed = 10f;
    private void OnEnable()
    {
        transform.localScale = 2 * Vector3.one;
        rb.velocity = new Vector2(speed, 0f);
    }

    private void Start()
    {
        transform.localScale = 2 * Vector3.one;
    }
}
