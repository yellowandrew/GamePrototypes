using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils 
{
   public static List<Vector2> GetStep(Vector2 start, MOV_TYPE type)
    {

        List<Vector2> list = new List<Vector2>();
        if (type== MOV_TYPE.MOV_I)
        {
            
            Vector2 v_up = new Vector2(start.x, start.y + 1);
            Vector2 v_down = new Vector2(start.x, start.y - 1);
            Vector2 v_left = new Vector2(start.x - 1, start.y);
            Vector2 v_right = new Vector2(start.x +1, start.y);

            if (is_in_board(v_up)) list.Add(v_up);
            if (is_in_board(v_down)) list.Add(v_down);
            if (is_in_board(v_left)) list.Add(v_left);
            if (is_in_board(v_right)) list.Add(v_right);

        }
        if (type == MOV_TYPE.MOV_X)
        {
            Vector2 left_top = new Vector2(start.x - 1, start.y + 1);
            Vector2 left_bot = new Vector2(start.x - 1, start.y - 1);
            Vector2 right_top = new Vector2(start.x + 1, start.y + 1);
            Vector2 right_bot = new Vector2(start.x + 1, start.y - 1);

            if (is_in_board(left_top)) list.Add(left_top);
            if (is_in_board(left_bot)) list.Add(left_bot);
            if (is_in_board(right_top)) list.Add(right_top);
            if (is_in_board(right_bot)) list.Add(right_bot);

        }
        if (type == MOV_TYPE.MOV_L)
        {
            Vector2 v_up_l = new Vector2(start.x-1, start.y + 2);
            Vector2 v_up_r = new Vector2(start.x + 1, start.y + 2);

            Vector2 v_down_l = new Vector2(start.x - 1, start.y - 2);
            Vector2 v_down_r = new Vector2(start.x + 1, start.y - 2);

            Vector2 v_left_u = new Vector2(start.x - 2, start.y +1);
            Vector2 v_left_d = new Vector2(start.x - 2, start.y - 1);

            Vector2 v_right_u = new Vector2(start.x + 2, start.y + 1);
            Vector2 v_right_d = new Vector2(start.x + 2, start.y - 1);


            if (is_in_board(v_up_l)) list.Add(v_up_l);
            if (is_in_board(v_up_r)) list.Add(v_up_r);
            if (is_in_board(v_down_l)) list.Add(v_down_l);
            if (is_in_board(v_down_r)) list.Add(v_down_r);
            if (is_in_board(v_left_u)) list.Add(v_left_u);
            if (is_in_board(v_left_d)) list.Add(v_left_d);
            if (is_in_board(v_right_u)) list.Add(v_right_u);
            if (is_in_board(v_right_d)) list.Add(v_right_d);

        }
        if (type == MOV_TYPE.MOV_XI)
        {
            Vector2 v_up = new Vector2(start.x, start.y + 1);
            Vector2 v_down = new Vector2(start.x, start.y - 1);
            Vector2 v_left = new Vector2(start.x - 1, start.y);
            Vector2 v_right = new Vector2(start.x + 1, start.y);

            if (is_in_board(v_up)) list.Add(v_up);
            if (is_in_board(v_down)) list.Add(v_down);
            if (is_in_board(v_left)) list.Add(v_left);
            if (is_in_board(v_right)) list.Add(v_right);

            Vector2 left_top = new Vector2(start.x - 1, start.y + 1);
            Vector2 left_bot = new Vector2(start.x - 1, start.y - 1);
            Vector2 right_top = new Vector2(start.x + 1, start.y + 1);
            Vector2 right_bot = new Vector2(start.x + 1, start.y - 1);

            if (is_in_board(left_top)) list.Add(left_top);
            if (is_in_board(left_bot)) list.Add(left_bot);
            if (is_in_board(right_top)) list.Add(right_top);
            if (is_in_board(right_bot)) list.Add(right_bot);


        }


        return list;
    }

    static bool is_in_board(Vector2 v ) {
        return v.x >= 0 && v.x < Def.WIDTH && v.y >= 0 && v.y < Def.WIDTH;
    }
}
