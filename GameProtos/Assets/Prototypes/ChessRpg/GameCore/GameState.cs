using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState 
{
    public GameState parent;
    public GameMain Game;
    protected Ray ray;
    protected RaycastHit hit;
    protected int click_col = -1;
    protected int click_row = -1;
    public GameState(GameMain game)
    {
        this.Game = game;
    }
    public virtual void update() {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
               // Debug.DrawLine(Camera.main.transform.position, hit.point, Color.red);
                click_row = -Mathf.RoundToInt(hit.point.z);
                click_col = Mathf.RoundToInt(hit.point.x);
            }
            else
            {
                click_row = -1;
                click_col = -1;
            }

        }
       
    }
    public virtual void enter() { }
    public virtual void exit() { }

    public virtual void popSelf() { }

    public virtual void popChild() { }
}

public class StateStack
{
    Stack<GameState> states = new Stack<GameState>();

    public bool IsEmpty {get => states.Count == 0; }
    public void push(GameState state)
    {
        states.Push(state);
        state.enter();
    }

    public void pop()
    {
        states.Peek().exit();
        states.Pop();
    }

    public void update()
    {
        states.Peek().update();
    }

   
}
