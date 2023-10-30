using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TestScript : MonoBehaviour
{

    public int width = 8;
    public int height = 8;

    public GameObject prefab;

    public GameObject marker;
    void Start()
    {
       


        createWall();


    }

   
    void createWall() {


        for (int z = 0; z < height; z++)
        {
            for (int x = 0; x < width; x++)
            {
                GameObject go = Instantiate(prefab);
                go.transform.position = new Vector3(x, 0, -z);
                go.name = "clicker(" + z + "," + x + ")";
                go.transform.parent = transform;

            }
        }

        for (int z = 0; z < height; z++)
        {
            for (int x = 0; x < width; x++)
            {

                GameObject go2 = Instantiate(marker);
                go2.transform.position = new Vector3(x, 0, -z);
                go2.name = "marker(" + z + "," + x + ")";
                go2.transform.parent = transform;
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
        
    }
}
