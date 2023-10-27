using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{


    int WIDTH = Def.WIDTH;

    public Transform[,] tiles = new Transform[Def.WIDTH, Def.WIDTH];
    public Transform[,] markers = new Transform[Def.WIDTH, Def.WIDTH];
    public int[,] slots = new int[Def.WIDTH, Def.WIDTH];
    void Start()
    {

        setupBard();
        Messanger.Bind(Def.MSG_Click_Character, OnCharacterClick);
    }

    void OnCharacterClick(object sender, object msg) {
        hideMarkers();
        Character cha = sender as Character;

        foreach (Vector2 v2 in cha.stepList)
        {
            markers[(int)v2.x, (int)v2.y].gameObject.SetActive(true);
        }
        
    }

    void hideMarkers() {
        foreach (Transform item in markers) item.gameObject.SetActive(false);
    }

    void setupBard() {
        List<Transform> list = new List<Transform>();
        Transform t = transform.GetChild(0);
        foreach (Transform item in t) list.Add(item);

        for (int i = 0; i < list.Count; i++)
        {
            int c = i / WIDTH;
            int r = i % WIDTH;
            tiles[c, r] = list[i];
        }
        list.Clear();
        t = transform.GetChild(1);
        foreach (Transform item in t) list.Add(item);
        for (int i = 0; i < list.Count; i++)
        {
            int c = i / WIDTH;
            int r = i % WIDTH;
            markers[c, r] = list[i];
        }

        hideMarkers();
    }
    
    void Update()
    {
        
    }
}
