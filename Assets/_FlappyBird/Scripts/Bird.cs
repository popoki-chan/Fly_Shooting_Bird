using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;

public class Bird : MonoBehaviour
{
    // private void Awake()
    // {
    //     Debug.Log("Awake");
    // }
    //
    // private void OnEnable()
    // {
    //     Debug.Log("OnEnable");
    // }
    //
    private float jumpForce = 10f;
    [SerializeField]private Rigidbody2D rb;
    private float cooldown = 0.5f;
    private float spawnDelay = 0.5f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnDelay = cooldown;

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //cho chim nhay len
            // rb.AddForce(new Vector2(0f, 300f));              //bị ảnh hưởng bởi trọng lượng
            rb.velocity = new Vector2(0f, jumpForce);       //ko bị ảnh hưởng bởi trọng lượng
        }

        if (spawnDelay <= 0)
        {
            spawnDelay = cooldown;
            PoolingManager.Instance.GetObject(NamePrefabPool.Bullet, null, transform.position);
        }
        else
        {
            spawnDelay -= Time.deltaTime;
        }
    }

    
}
