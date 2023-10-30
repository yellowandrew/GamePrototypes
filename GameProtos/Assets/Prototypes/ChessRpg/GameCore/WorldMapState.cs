using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapState : GameState
{
    public WorldMapState(GameMain game):base(game)
    {
        
    }

    public override void enter()
    {
        base.enter();
       
        Game.LoadMap(1);
    }

    public override void update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                click_row = -Mathf.RoundToInt(hit.point.z);
                click_col = Mathf.RoundToInt(hit.point.x);
                Game.TriggerEventAt(click_row, click_col);
               
            }
            else
            {
                click_row = -1;
                click_col = -1;
            }

        }

    }

}
