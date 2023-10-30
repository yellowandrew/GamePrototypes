using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;


public class Trigger
{
    public int row;
    public int col;
    public int value;

}

public class MapData
{
    public int id;
    public string name;
    public List<int> tiles = new List<int>();//基础地块
    public List<int> blocks = new List<int>();//不可走动地块
    public List<string> objects = new List<string>();//装饰地块
    public List<string> triggers = new List<string>();//触发器地块
    public List<string> actors = new List<string>();//角色

   
}



public class DungeonData
{
    public int id;
    public List<int> maps = new List<int>();
}

public class Entity
{
    public int id;
    public int row;
    public int col;
  
    public virtual void OnSelected() { 
        
    }
}

