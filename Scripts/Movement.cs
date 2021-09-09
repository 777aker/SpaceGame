using System;
using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using Unity.Mathematics;
using UnityEditor.UIElements;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class Movement : MonoBehaviour {
    // get the ship
    [SerializeField] private GameObject ship;
    // get the rigid body
    private Rigidbody2D body;
    // speed stuff and top speed stuffs
    [SerializeField] private float speed = 40;
    [SerializeField] private float TopSpeed = 2;
    [SerializeField] private float turnSpeed = 1;
    // the particle systems
    [SerializeField] private ParticleSystem moving1, moving2;
    // the sprite which is easy way to see if ship activated
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start() {
        // initialize the rigidbody
        body = ship.GetComponent<Rigidbody2D>();
        // intialize the sprite so when ship is destroyed we don't display particle systems
        sprite = ship.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate() {
        // direction we are moving in
        Vector2 direction = Vector2.zero;
        // direction we are turning
        float turn = 0;
        // get user input and make direction vector the direction of the input and turning
        if (Input.GetKey(KeyCode.W))
            direction += Vector2.up;
        if (Input.GetKey(KeyCode.A))
            turn = 1;
        if (Input.GetKey(KeyCode.D))
            turn = -1;
        if (Input.GetKey(KeyCode.S))
            direction += Vector2.down;
        // so if we aren't moving pause the moving particle system for cool effects
        if (direction == Vector2.zero) {
            moving1.Pause();
            moving2.Pause();
        } else {
            // whelp, we are moving so gotta do a lot of stuff
            // first, we gotta handle going way too fast, so we do that by
            // taking the way we want to move and subtract the way we are moving
            // this way they only move in directions against the speed we are going
            // so they can still move as long as it's in another direction
            if (body.velocity.magnitude >= TopSpeed)
                // ok, I don't think subtracting is the move here, ask Julien
                direction -= body.velocity.normalized;
            // apply the direction
            body.AddRelativeForce(direction * speed * Time.fixedDeltaTime);
            // so, this is me trying to get cool effects
            if (sprite.enabled) {
                //Debug.Log("Enabled!");
                moving1.Play();
                moving2.Play();
            }
        } 
        // so now we gotta do rotation
        if (turn != 0) {
            // get the current velocity so we can do the same thing as moving which is top speed
            // but if too fast only turn in direction we aren't going
            var vel = body.angularVelocity;
            if (math.abs(vel) >= 30)
                // the division is for normalizing the velocity
                turn = turn - vel/math.abs(vel);
            // finally apply the torque
            body.AddTorque(turn * turnSpeed * body.inertia * Time.deltaTime, ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    // also, physics should be moved to a fixed update function
    void Update() {
        /* redoing this since it needs to be in fixed update anyway
        // the direction we are moving in
        Vector2 direction = Vector2.zero;
        // the direction we are turning
        float turn = 0;
        Vector3 updir = transform.up;
        // get user input and make direction vector the direction of the input and turning
        if (Input.GetKey(KeyCode.W))
            direction += new Vector2(updir.x, updir.y);
        if (Input.GetKey(KeyCode.A))
            turn = 1;
        if (Input.GetKey(KeyCode.D))
            turn = -1;
        if (Input.GetKey(KeyCode.S))
            direction -= new Vector2(updir.x, updir.y);
        // so if we aren't moving pause the moving particle system for cool effects
        if (direction == Vector2.zero) {
            moving1.Pause();
            moving2.Pause();
        } else {
            // whelp, we are moving so gotta do a lot of stuff
            // first, we gotta handle going way too fast, so we do that by
            // taking the way we want to move and subtract the way we are moving
            // this way they only move in directions against the speed we are going
            // so they can still move as long as it's in another direction
            if (body.velocity.magnitude >= TopSpeed)
                // this was backwards oof
                direction = body.velocity.normalized - direction;
            // apply the direction
            body.AddForce(direction * speed * Time.deltaTime);
            // so, this is me trying to get cool effects
            if (sprite.enabled) {
                //Debug.Log("Enabled!");
                moving1.Play();
                moving2.Play();
            }
        } 
        // so now we gotta do rotation
        if (turn != 0) {
            // get the current velocity so we can do the same thing as moving which is top speed
            // but if too fast only turn in direction we aren't going
            var vel = body.angularVelocity;
            if (math.abs(vel) >= 30)
                // the division is for normalizing the velocity
                turn = turn - vel/math.abs(vel);
            // finally apply the torque
            body.AddTorque(turn * turnSpeed * body.inertia * Time.deltaTime, ForceMode2D.Impulse);
        } */
    }
}
