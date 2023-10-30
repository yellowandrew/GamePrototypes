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
    public List<int> tiles = new List<int>();//�����ؿ�
    public List<int> blocks = new List<int>();//�����߶��ؿ�
    public List<string> objects = new List<string>();//װ�εؿ�
    public List<string> triggers = new List<string>();//�������ؿ�
    public List<string> actors = new List<string>();//��ɫ

   
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

