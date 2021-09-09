using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MakeMissile : MonoBehaviour {
    [SerializeField] private GameObject missole;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        GameObject missiel = Instantiate(missole, transform.position + new Vector3(-3, Random.Range(-5, 5), 0), Quaternion.identity);
        missiel.SetActive(true);
    }
}
