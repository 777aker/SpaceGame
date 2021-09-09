using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(UnityEngine.Collision other) {
        Debug.Log("Entered");
    }

    private void OnTriggerEnter(Collider other) {
        throw new NotImplementedException();
    }

    private void OnTriggerExit(Collider other) {
        throw new NotImplementedException();
    }

    private void OnCollisionExit(UnityEngine.Collision other) {
        throw new NotImplementedException();
    }

    private void OnCollisionStay(UnityEngine.Collision other) {
        throw new NotImplementedException();
    }

    private void OnTriggerStay(Collider other) {
        throw new NotImplementedException();
    }
}
