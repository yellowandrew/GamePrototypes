using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceDetetor : MonoBehaviour
{
    Dice dice;
    void Start()
    {
        dice = FindObjectOfType<Dice>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (dice.GetComponent<Rigidbody>().velocity == Vector3.zero)
        {
            Debug.Log(other.name);
        }
    }
}
