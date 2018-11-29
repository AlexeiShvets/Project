using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class FigureController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private Transform canvas;

    public bool IsMove;

    public event EventHandler EndDragEvent;

    public void OnDrag(PointerEventData eventData)
    {
        if (!IsMove)
            return;
        transform.SetParent(canvas);
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (EndDragEvent != null)
            EndDragEvent.Invoke(this,null);

        


    }

    private void Select()
    {
        //foreach (var cell in Global.Cells.FindAll(c => c.IsSelect))
        //{
        //    cell.IsSelect = false;
        //}

        //if (figure.UserColorType == UserColorType.Black)
        //    SelectBlack();
        //else
        //    SelectWhite();
    }
    
    private void SelectBlack()
    {
        //int x = cell.X;
        //int y = cell.Y;
        //try
        //{
        //    while (x - 1 > 0 && y + 1 < 9)
        //    {
        //        x--;
        //        y++;
        //        var cell = Global.Cells.Find(c => c.X == x && c.Y == y);
        //        if (cell.Figure != null)
        //            break;

        //        cell.IsSelect = true;
        //    }

        //    x = Cell.X;
        //    y = Cell.Y;

        //    while (x + 1 < 9 && y + 1 < 9)
        //    {
        //        x++;
        //        y++;
        //        var cell = Global.Cells.Find(c => c.X == x && c.Y == y);
        //        if (cell.Figure != null)
        //            break;

        //        cell.IsSelect = true;

        //    }

        //    x = Cell.X;
        //    y = Cell.Y;

        //    while (y + 1 < 9)
        //    {
        //        y++;
        //        var cell = Global.Cells.Find(c => c.X == x && c.Y == y);
        //        if (cell.Figure != null)
        //            break;

        //        cell.IsSelect = true;
        //    }

        //    var ss = Global.Cells.FindAll(a => a.IsSelect).Count;
        //    if (Global.Cells.FindAll(a => a.IsSelect).Count == 0)
        //    {
        //        IsFocus = false;
        //        var figure = Global.Figures.Find(f => f.UserType != UserType && f.Color == Cell.Color);

        //        if (figure != null)
        //        {
        //            figure.IsFocus = true;
        //            Global.UserType = figure.UserType;
        //            Global.ColorType = figure.Color;
        //        }
        //    }
        //}
        //catch (Exception exc)
        //{
        //    Debug.LogError(string.Format("x:{0} y:{1}", x, y));
        //}
    }

    private void SelectWhite()
    {
        //int x = Cell.X;
        //int y = Cell.Y;
        //try
        //{
        //    while (x - 1 > 0 && y - 1 > 0)
        //    {
        //        x--;
        //        y--;
        //        var cell = Global.Cells.Find(c => c.X == x && c.Y == y);
        //        if (cell.Figure != null)
        //            break;

        //        cell.IsSelect = true;
        //    }

        //    x = Cell.X;
        //    y = Cell.Y;

        //    while (x + 1 < 9 && y - 1 > 0)
        //    {
        //        x++;
        //        y--;
        //        var cell = Global.Cells.Find(c => c.X == x && c.Y == y);
        //        if (cell.Figure != null)
        //            break;

        //        cell.IsSelect = true;
        //    }

        //    x = Cell.X;
        //    y = Cell.Y;

        //    while (y - 1 > 0)
        //    {
        //        y--;
        //        var cell = Global.Cells.Find(c => c.X == x && c.Y == y);
        //        if (cell.Figure != null)
        //            break;

        //        cell.IsSelect = true;
        //    }
        //    var ss = Global.Cells.FindAll(a => a.IsSelect).Count;
        //    if (Global.Cells.FindAll(a => a.IsSelect).Count == 0)
        //    {
        //        IsFocus = false;
        //        var figure = Global.Figures.Find(f => f.UserType != UserType && f.Color == Cell.Color);

        //        if (figure != null)
        //        {
        //            figure.IsFocus = true;
        //            Global.UserType = figure.UserType;
        //            Global.ColorType = figure.Color;
        //        }
        //    }
        //}
        //catch (Exception exc)
        //{
        //    Debug.LogError(string.Format("x:{0} y:{1}", x, y));
        //}
    }

    private float speed = 4.5F;

    // Use this for initialization
    void Start()
    {
        //Cell.Figure = this;
    }

    // Update is called once per frame
    void Update()
    {
       // if (Math.Abs(Cell.transform.position.x - transform.position.x) == 0)
       // {
       //     if (UserType == UserType.White && Cell.Y == 1)
       //     {
       //         Debug.Log("Win W");
       //         return;
       //     }
       //     else if (UserType == UserType.Black && Cell.Y == 8)
       //     {
       //         Debug.Log("Win B");
       //         return;
       //     }
       // }

       // if (Cell == null)
       //     return;

       //// if (Math.Abs(Cell.transform.position.x - transform.position.x) != 0)
       // {
            
       //     transform.position = Vector2.MoveTowards(transform.position, Cell.transform.position, speed * Time.deltaTime);
       // }       
    }

    void OnMouseDown() //функция клика мышью
    {
        //if (Global.IsStart || UserType == UserType.Black)
        //    return;

        //foreach (var f in Global.Figures)
        //{
        //    f.IsFocus = false;
        //}

        //IsFocus = true;
    }


}
