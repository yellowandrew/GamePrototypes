using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonState : GameState
{

    Actor hero;

    StateStack _subStack;

    SelectActorState selectActorState;
    public DungeonState(GameMain game) : base(game)
    {
        _subStack = new StateStack();
    }

    public override void enter()
    {
        base.enter();
        GameObject  go = GameObject.Instantiate(Game.prefabs.actors[0]);
        go.transform.position = new Vector3(1, 0, -1);
        go.name = "hero";
        hero = go.GetComponent<Actor>();
        hero.row = 1;
        hero.col = 1;
        Game.DirtySlot(1, 1, hero.id);
        // hero.transform.parent = Game.mapRoot;
    }

    public override void exit()
    {
        base.exit();
        GameObject.DestroyImmediate(hero.gameObject);
    }

    public void MoveActorTo(int row, int col)
    {
        Game.EmptySlot(row, col);
        hero.transform.position = new Vector3(col, 0, -row);
        Game.DirtySlot(row, col, hero.id);
    }
    public override void popChild()
    {
        _subStack.pop();
    }

    public override void update()
    {

        if (!_subStack.IsEmpty)
        {
            _subStack.update();
        }
        else {
            if (Input.GetMouseButtonDown(0))
            {

                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    click_row = -Mathf.RoundToInt(hit.point.z);
                    click_col = Mathf.RoundToInt(hit.point.x);
                    Game.TriggerEventAt(click_row, click_col);
                    int id =   Game.SelectActorAt(click_row, click_col);
                    if (id == hero.id)
                    {
                        Game.curActor = hero;
                        Game.ShowFootStep(click_row, click_col, hero.move_type);
                        selectActorState = new SelectActorState(Game);
                        selectActorState.parent = this;
                        _subStack.push(selectActorState);
                    }
                }
              
            }
        }

    }
}

public class SelectActorState : GameState
{
    public SelectActorState(GameMain game) : base(game)
    {

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
                Game.ClickFootStep(click_row, click_col);
                parent.popChild();
            
               
            }
          
        }
    }
}
