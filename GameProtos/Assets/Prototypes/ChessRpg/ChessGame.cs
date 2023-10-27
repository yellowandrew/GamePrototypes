using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChessGame : MonoBehaviour
{

    public Board board;
    public GameObject hero_prefab;
    public GameObject enemy_prefab;
    public GameObject sel_icon;

    Character sel_character;

    public List<Character> heros = new List<Character>();
    public List<Character> enemies = new List<Character>();
    void Start()
    {
        loadLevel();
        Messanger.Bind(Def.MSG_Click_Character, OnCharacterClick);
        Messanger.Bind(Def.MSG_Click_Marker, OnMarkerClick);
        sel_icon.SetActive(false);
    }



    private void OnDisable()
    {
      
    }
    void loadLevel() {

        for (int i = 0; i < 3; i++)
        {
            int x = Random.Range(0, Def.WIDTH);
            int y = Random.Range(0, Def.WIDTH);
            if (board.slots[x,y] ==0)
            {
                board.slots[x, y] = 1;
                GameObject go = Instantiate(hero_prefab);
                go.transform.position = new Vector3(x,0,y);
                Character ch = go.GetComponent<Character>();
                ch.type = CHA_TYPE.HERO;
                ch.SetPosition(x, y);
                ch.move_type =(MOV_TYPE) Random.Range(0, (int)MOV_TYPE.Length);
                heros.Add(go.GetComponent<Character>());
            }
        }
        for (int i = 0; i < 3; i++)
        {
          
            int x = Random.Range(0, Def.WIDTH);
            int y = Random.Range(0, Def.WIDTH);
            if (board.slots[x, y] == 0)
            {
                board.slots[x, y] = 2;
                GameObject go = Instantiate(enemy_prefab);
                go.transform.position = new Vector3(x, 0, y);
                Character ch = go.GetComponent<Character>();
                ch.type = CHA_TYPE.ENEMY;
                ch.SetPosition(x, y);
                ch.move_type = (MOV_TYPE)Random.Range(0, (int)MOV_TYPE.Length);
                enemies.Add(go.GetComponent<Character>());
            }
        }
        
    }

    void OnCharacterClick(object sender, object msg)
    {
        sel_character = sender as Character;
        if (sel_character.type == CHA_TYPE.HERO)
        {
            sel_icon.SetActive(true);
            sel_icon.transform.position = new Vector3(sel_character.x, 1.5f, sel_character.y);
        }
        else if (sel_character.type == CHA_TYPE.ENEMY)
        {
            Debug.Log("Attack!!");
        }
       
       
    }

    void OnMarkerClick(object sender, object msg)
    {
        Marker mk = sender as Marker;
        if (board.slots[mk.x, mk.y] == 0)
        {
            board.slots[sel_character.x, sel_character.y] = 0;   
            sel_character.MoveTo(mk.x, mk.y);
            board.slots[mk.x, mk.y] = 1;
            board.hideMarkers();
            sel_icon.SetActive(false);
        }
        else
        {
            Debug.Log("slot is not empty");
        }
       
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var pos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            
        }
    }

    public void reload() {
        SceneManager.LoadScene(0);
    }
}
