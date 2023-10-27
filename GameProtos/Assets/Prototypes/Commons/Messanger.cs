using System;
using System.Collections.Generic;
using UnityEngine;

public class Messanger 
{
    static Dictionary<int, List<EventHandler<object>>> dicts = new Dictionary<int, List<EventHandler<object>>>();

    public static void Clear() {
        dicts.Clear();
    }
    
    public static void Emit(int mId, object msg, object sender = null) {
        foreach (var handler in dicts[mId])
        {
            handler.Invoke(sender, msg);
        }
    }

    public static void Bind(int mId, EventHandler<object> handler) {
        List<EventHandler<object>> list;
        if (dicts.ContainsKey(mId))
        {
            list = dicts[mId];
        }
        else
        {
            list = new List<EventHandler<object>>();
            dicts.Add(mId, list);
        }
        list.Add(handler);
    }

    public static void Delete(int mId, EventHandler<object> handler) {
        if (dicts.ContainsKey(mId))
        {
            foreach (var h in dicts[mId])
            {
                if (h == handler)
                {
                    dicts[mId].Remove(h);
                }
            }
        }
    }
   
}
