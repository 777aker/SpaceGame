using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shmupMovement : MonoBehaviour {
    private Rigidbody2D body;
    [SerializeField] private float speed;
    
    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody2D>();
    }
    
    // fixed update woo
    private void FixedUpdate() {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        body.MovePosition(transform.position + dir * Time.fixedDeltaTime * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
