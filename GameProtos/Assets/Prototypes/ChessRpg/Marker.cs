using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{

    public int x, y;
    void Start()
    {
        x =(int) transform.position.x;
        y = (int)transform.position.z;
    }

    private void OnMouseUpAsButton()
    {
        Messanger.Emit(Def.MSG_Click_Marker, "", this);
    }
}
