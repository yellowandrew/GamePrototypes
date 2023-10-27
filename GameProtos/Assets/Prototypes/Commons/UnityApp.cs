using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityApp 
{
    public MonoBehaviour Mono { get; set; }
    public virtual void Start()
    {
        Debug.Log(GetType() + "  start");
    }

    public virtual void Update() { }
    public virtual void FixedUpdate() { }
    public virtual void Exit(){ }
}
