using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    Rigidbody _rigidbody;
    public float RollForce = 5;
    public float MaxForce = 500;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
       // transform.rotation = new Quaternion(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360),0);
    }


    public void Roll() {
        _rigidbody.isKinematic = false;
        var forceX = Random.Range(0,MaxForce);
        var forceY = Random.Range(0, MaxForce);
        var forceZ = Random.Range(0, MaxForce);

        _rigidbody.AddForce(Vector3.up * (RollForce+Random.Range(-1.0f,1.0f)),ForceMode.Impulse);
        _rigidbody.AddTorque(forceX, forceY, forceZ);
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Roll();
        }
    }
}
