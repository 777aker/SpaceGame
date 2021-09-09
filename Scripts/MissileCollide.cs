using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileCollide : MonoBehaviour {
    private Rigidbody2D body;
    [SerializeField] private float speed = 200;
    [SerializeField] private Transform target;

    private void Start() {
        body = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }

    private void FixedUpdate() {
        //transform.LookAt(target.position);
        Vector2 forceDirection = target.position - transform.position;
        body.AddForce(forceDirection * Time.fixedDeltaTime * speed);
    }
}
