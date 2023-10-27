using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{


    int WIDTH = Def.WIDTH;

   // public Transform[,] tiles ;
   // public Transform[,] markers;

    public GameObject[] tiles;
    public GameObject[] markers;
    public int[,] slots ;
    void Start()
    {
        slots = new int[Def.WIDTH, Def.WIDTH];
        // tiles = new Transform[Def.WIDTH, Def.WIDTH];
        //  markers = new Transform[Def.WIDTH, Def.WIDTH];
        //  setupBard();
        hideMarkers();
        Messanger.Bind(Def.MSG_Click_Character, OnCharacterClick);
    }
    private void OnDisable()
    {
      
    }
    void OnCharacterClick(object sender, object msg) {
        hideMarkers();
        Character cha = sender as Character;
        if (cha.type == CHA_TYPE.HERO)
        {
            foreach (Vector2 v2 in cha.stepList)
            {
               markers[getIndex(v2)].gameObject.SetActive(true);
            }
        }
    }

    int getIndex(Vector2 v2) {
        return (int)v2.x * WIDTH + (int)v2.y;
    }

    public void hideMarkers() {

        foreach (GameObject item in markers) {
           
            item.gameObject.SetActive(false); 
        }
    }

    void setupBard() {
       
        List<Transform> list = new List<Transform>();
        Transform t = transform.GetChild(0);
        foreach (Transform item in t) list.Add(item);

        for (int i = 0; i < list.Count; i++)
        {
            int c = i / WIDTH;
            int r = i % WIDTH;
           // tiles[c, r] = list[i];
        }
        list.Clear();
        t = transform.GetChild(1);
        foreach (Transform item in t) list.Add(item);
        for (int i = 0; i < list.Count; i++)
        {
            int c = i / WIDTH;
            int r = i % WIDTH;
           // markers[c, r] = list[i];
        }

        foreach (var item in markers)
        {
            Debug.Log(item.name);
        }
        hideMarkers();
    }
    
    void Update()
    {
        
    }
}
