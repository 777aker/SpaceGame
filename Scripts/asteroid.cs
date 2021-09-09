using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour
{
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody2D>();
        body.AddTorque(Random.Range(-30, 30));
        body.rotation = Random.Range(0, 360);
        
        switch (Random.Range(1,4)) {
            case 1:
                body.AddRelativeForce(Vector3.left * Random.Range(0, 5) * 10);
                break;
            case 2:
                body.AddRelativeForce(Vector3.right * Random.Range(0, 5) * 10);
                break;
            case 3:
                body.AddRelativeForce(Vector3.up * Random.Range(0, 5) * 10);
                break;
            case 4:
                body.AddRelativeForce(Vector3.down * Random.Range(0, 5) * 10);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
