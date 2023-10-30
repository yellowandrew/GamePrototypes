using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MOV_TYPE
{

    MOV_I=0,
    MOV_X,
    MOV_L,
    MOV_XI,

    Length
}

public enum CHA_TYPE { 
    HERO,
    ENEMY,
}
public class Character : MonoBehaviour
{


    public CHA_TYPE type;
    public MOV_TYPE move_type;

    public List<Vector2> stepList = new List<Vector2>();
    public int x, y;
    void Start()
    {
        x = (int)transform.position.x;
        y = (int)transform.position.z;
    }

   
    void Update()
    {
        
    }

    public void MoveTo(int _x, int _y) {
        transform.position = new Vector3(_x, 0, _y);
        SetPosition(_x, _y);
    }

    public void SetPosition(int _x, int _y) {
        x = _x;
        y = _y;
    }

    private void OnMouseUpAsButton()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.z);
       // stepList = Utils.GetStep(pos, move_type);
        Messanger.Emit(Def.MSG_Click_Character, "",this);
    }
}
