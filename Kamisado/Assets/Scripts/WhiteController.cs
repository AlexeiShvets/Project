using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class WhiteController : FigureController, IDragHandler
{
    private int yWin = 1;

    // Use this for initialization
    void Start()
    {
        UserColor = UserColorEnum.White;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDrag(PointerEventData eventData)
    {        
        if (!IsActive || GameHelper.IsPause)
            return;

        transform.SetParent(canvas);
        transform.position = eventData.position;
    }

    public override void UpdateWay( bool moveTo)
    {
        int x = Square.X;
        int y = Square.Y;
        int colorCount = GameHelper.ColorCount;
       

        try
        {
            while (x - 1 > 0 && y - 1 > 0)
            {
                x--;
                y--;
                var square = GameHelper.Squares.Find(c => c.X == x && c.Y == y);
                if (square.IsFigure)
                    break;
                square.IsMoveTo = moveTo;
            }

            x = Square.X;
            y = Square.Y;

            while (x + 1 <= colorCount && y - 1 > 0)
            {
                x++;
                y--;

                var square = GameHelper.Squares.Find(c => c.X == x && c.Y == y);
                if (square.IsFigure)
                    break;

                square.IsMoveTo = moveTo;
            }

            x = Square.X;
            y = Square.Y;

            while (y - 1 > 0)
            {
                y--;
                var square = GameHelper.Squares.Find(c => c.X == x && c.Y == y);
                if (square.IsFigure)
                    break;

                square.IsMoveTo = moveTo;
            }

            CheckWay();
         
        }
        catch (Exception ex)
        {
            Debug.LogError(string.Format("{2}  x:{0} y:{1}", x, y, ex));
        }
    }       

    public override void NextFigure()
    {
        GameHelper.BlackFigures.Find(w => w.Color == Square.Color).IsActive = true;
    }
    
    public override bool WinСheck()
    {
        return Square.Y == yWin;
    }
}
