using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TestScript : MonoBehaviour
{

    public int row = 6;
    public int col = 6;

    public GameObject prefab;

    public GameObject marker;
    void Start()
    {
        Messanger.Bind(1, OnMSG);


        createWall();


    }

   
    void createWall() {


        for (int x = 0; x < col; x++)
        {
               
                for (int z = 0; z < row; z++)
                {
                    var go = Instantiate(prefab);
                    go.name = "Tile(" + x + "," + z+ ")";
                    go.transform.parent = transform;
                    go.transform.position = new Vector3(x, 0, z);
                    go.transform.localScale = Vector3.one * 0.98f;
            }
               
            }

        for (int x = 0; x < col; x++)
           
        {
            for (int z = 0; z < row; z++)
            {
                var go = Instantiate(marker);
                go.name = "marker(" + x + "," + z + ")";
                go.transform.parent = transform;
                go.transform.position = new Vector3(x, 0, z);
                go.transform.localScale = Vector3.one * 0.98f;
            }

        }

    }
    void OnMSG(object sender, object msg)
    {
        Debug.Log(sender.ToString() + "->" + msg.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Messanger.Emit(1, "Hello!", this);
            createWall();
        }
    }
}
