using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MOV_TYPE
{

    MOV_I,
    MOV_X,
    MOV_L,
    MOV_XI,
}
public class Character : MonoBehaviour
{
   


    public MOV_TYPE move_type;

    public List<Vector2> stepList = new List<Vector2>();
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    private void OnMouseUpAsButton()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.z);
        stepList = Utils.GetStep(pos, move_type);
        Messanger.Emit(Def.MSG_Click_Character, "",this);
    }
}
