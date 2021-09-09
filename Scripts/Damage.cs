using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.Mathematics;
using UnityEngine;

public class Damage : MonoBehaviour {

    // the ship so we can set to invisible after destroyed
    [SerializeField] GameObject ship;
    // So we can edit our objects in game particle systems with the script
    // we put them here
    [SerializeField] ParticleSystem damagedParticleSystem;
    [SerializeField] ParticleSystem destroyParticleSystem;
    // this just seems like a good thing to go ahead and implement
    [SerializeField] float health = 100;
    // so we only do destroyed once I'm gonna do it this weird way just in case
    private bool destroyed = false;
    [SerializeField] private float impact = 5;
    [SerializeField] private float missile_damage = 20;
    [SerializeField] private AudioSource bump;
    [SerializeField] private AudioSource hit;
    
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        /*
        if (!destroyed) {
            if (Input.GetKeyDown(KeyCode.Minus)) {
                health--;
                Debug.Log("Ship health: " + health);
                if (damagedParticleSystem.isStopped) {
                    damagedParticleSystem.Play();
                }
                else {
                    damagedParticleSystem.Stop();
                    var emission = damagedParticleSystem.emission;
                    emission.rateOverTime = (10-health);
                    damagedParticleSystem.Play();
                }
            }

            if (health == 0) {
                destroyed = true;
                damagedParticleSystem.Stop();
                var sprite = ship.GetComponent<SpriteRenderer>();
                sprite.enabled = false;
                destroyParticleSystem.Play();
            }
        }
        */
    }

    private void OnCollisionEnter2D(Collision2D other) {
        //Debug.Log("Collision");
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("missile")) {
            health -= missile_damage;
            hit.Play();
        }
        else {
            health -= other.relativeVelocity.magnitude / impact;
            bump.Play();
        }
        Debug.Log(health);
        if (health <= 50)
            damagedParticleSystem.Play();
        if (health <= 0) {
            destroyed = true;
            damagedParticleSystem.Stop(false, ParticleSystemStopBehavior.StopEmitting);
            var sprite = ship.GetComponent<SpriteRenderer>();
            sprite.enabled = false;
            destroyParticleSystem.Play();
        }
    }
}
