using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{

    public int id;
    public int row;
    public int col;
    public MOV_TYPE move_type;
    public List<Vector2> stepList = new List<Vector2>();
    void Start()
    {
        
    }


    public void MoveTo(int row, int col) {
        transform.position = new Vector3(col, 0, -row);
    }

    void Update()
    {
        
    }
}
