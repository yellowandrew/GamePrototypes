using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using DG.Tweening;

public class GameMain : MonoBehaviour
{
    public Transform mapRoot;
    public TilePrefabs prefabs;
    public GameObject location;
    public GameObject[] markers;
    [SerializeField]
    public List<int> mapSlots = new List<int>();

    StateStack stack;
 

    public Text MapText;

    public Material maskMat;

    MapData _mapData;
    Dictionary<int, MapData> mapDatas = new Dictionary<int, MapData>();
    Dictionary<int, DungeonData> dungeonDatas = new Dictionary<int, DungeonData>();
    DungeonData _dungeonData;
    public Actor curActor;
    void Start()
    {
        HideMarkers();
        LoadData();
        stack = new StateStack();
        stack.push(new WorldMapState(this));
    }

   
    void LoadData()
    {
        string json_text = Resources.Load("maps").ToString();
        var map_datas = JsonConvert.DeserializeObject<List<MapData>>(json_text);
        foreach (var map in map_datas)
        {
            mapDatas.Add(map.id, map);
        }

        json_text = Resources.Load("dungeons").ToString();

        var dungeon_datas = JsonConvert.DeserializeObject<List<DungeonData>>(json_text);
        foreach (var d in dungeon_datas)
        {
            dungeonDatas.Add(d.id, d);
        }

    }

    public void LoadMap(int id) {
        maskMat.DOFade(1, 1).OnComplete(() =>
        {
            _mapData = mapDatas[id];
            MapText.text = _mapData.name;
            foreach (Transform t in mapRoot)
            {
                GameObject.Destroy(t.gameObject);
            }

            for (int i = 0; i < _mapData.tiles.Count; i++)
            {
                int r = i / 8;
                int c = i % 8;
                if (_mapData.tiles[i] >= 0)
                {
                    GameObject go = GameObject.Instantiate(prefabs.tiles[_mapData.tiles[i]]);
                    go.transform.position = new Vector3(c, 0, -r);
                    go.name = "tile(" + r + "," + c + ")";
                    go.transform.parent = mapRoot;
                }
            }

            foreach (var s in _mapData.objects)
            {
                var args = s.Split(',');
                int z = int.Parse(args[0]);
                int x = int.Parse(args[1]);
                int i = int.Parse(args[2]);
                GameObject go = GameObject.Instantiate(prefabs.items[i]);
                go.transform.position = new Vector3(x, 0, -z);
                go.name = "object(" + i + ")";
                go.transform.parent = mapRoot;

            }

            foreach (var s in _mapData.triggers)
            {
                var args = s.Split('#')[0].Split(',');
                int z = int.Parse(args[0]);
                int x = int.Parse(args[1]);
                int i = int.Parse(args[2]);
                GameObject go = GameObject.Instantiate(prefabs.items[i]);
                go.transform.position = new Vector3(x, 0, -z);
                go.name = "trigger(" + i + ")";
                go.transform.parent = mapRoot;

            }

            foreach (var a in _mapData.actors)
            {
                var args = a.Split(',');
                int z = int.Parse(args[0]);
                int x = int.Parse(args[1]);
                int i = int.Parse(args[2]);
                GameObject go = GameObject.Instantiate(prefabs.actors[i]);
                go.transform.position = new Vector3(x, 0, -z);
                go.name = "actor(" + i + ")";
                go.transform.parent = mapRoot;
            }


            maskMat.DOFade(0, 1).OnComplete(() => {});
        });
       
    }

    public int HasEntityAt(int row,int col) {

        for (int i = 0; i < _mapData.triggers.Count; i++)
        {
            var args = _mapData.triggers[i].Split('#')[1].Split(',');
            int z = int.Parse(args[0]);
            int x = int.Parse(args[1]);
            if (row == z && col == x) {
                return i;
            }
        }
        return -1;
    }



    public void LoadDungeon(int id) {
        //_dungeonData = dungeonDatas[id];
        
        stack.push(new DungeonState(this));
        LoadMap(id);

    }

    public void EmptySlot(int row, int col) {
        int idx = Utils.CoordToIndex(row, col);
        mapSlots[idx] = 0;
    }
    public void DirtySlot(int row, int col,int id)
    {
        int idx = Utils.CoordToIndex(row, col);
        mapSlots[idx] = id;
    }

    public int SelectActorAt(int row, int col) {
        int idx = Utils.CoordToIndex(row, col);
        return mapSlots[idx];
    }

    public void MoveActorTo(int row, int col)
    {
        EmptySlot(row, col);
        curActor.transform.position = new Vector3(col, 0, -row);
        DirtySlot(row, col, curActor.id);
    }

    List<Vector2> footSteps = new List<Vector2>();
    public void ShowFootStep(int row, int col, MOV_TYPE type) {
        footSteps =  Utils.GetStep(row, col, type);
        foreach (Vector2 v2 in footSteps)
        {
            markers[Utils.CoordToIndex((int)v2.x,(int)v2.y)].gameObject.SetActive(true);
        }
    }

    public void ClickFootStep(int row, int col) {
        HideMarkers();
        foreach (var v2 in footSteps)
        {
            if (v2.x == row && v2.y == col)
            {       
                MoveActorTo(row, col);
            }
        }

       
    }
    public void TriggerEventAt(int row, int col)
    {

        foreach (var item in _mapData.triggers)
        {
            var args = item.Split('#')[0].Split(',');
            int z = int.Parse(args[0]);
            int x = int.Parse(args[1]);
            if (row == z && col == x)
            {
                var cmd = item.Split('#')[1].Split(',');
                int id = int.Parse(cmd[1]);
                if (cmd[0] == "map")
                {
                    LoadMap(id);
                }
                else if (cmd[0] == "dungeon")
                {
                    LoadDungeon(id);
                }
                else if (cmd[0] == "exit")
                {
                    stack.pop();
                    LoadMap(id);
                }
                return ;
            }
        }

    }
    public void HideMarkers()
    {
        foreach (GameObject m in markers) m.SetActive(false);
    }
    public void ShowMarker(int idx)
    {
        markers[idx].SetActive(true);
    }
    void Update()
    {
        stack.update();
    }
}
