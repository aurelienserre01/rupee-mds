using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _movement;
    private Rigidbody2D _rigidbody2D;
    public float speed = 10f;
    private void Awake()
    {
        Debug.Log("Awake");
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Start");
    }



    // Update is called once per frame
    private void Update()
    {
        // Compute the movement vector
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        _movement = new Vector2(horizontal, vertical).normalized;
        Debug.Log(_movement);

    }

    private void FixedUpdate()
    {
        // 
        _rigidbody2D.velocity = _movement * speed;
    }
}
