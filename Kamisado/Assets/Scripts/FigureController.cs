using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public abstract class FigureController : Figure, IEndDragHandler
{
    private bool _isActive;   

    [SerializeField]
    protected Transform canvas;

    protected int distanceMin = 30;

    [SerializeField]
    private SquareController _square;

    public bool IsActive
    {
        get { return _isActive; }
        set
        {
            _isActive = value;
            UpdateWay(_isActive);
        }
    }

    public SquareController Square
    {
        get { return _square; }
        set
        {
            if (value != null)
            {
                _square.IsFigure = false;                
                _square = value;
                _square.IsFigure = true;
            }

            UpdateTransform();
        }
    }

    private void UpdateTransform()
    {
        transform.SetParent(Square.transform);
        transform.position = Square.transform.position;
        transform.localScale = Vector2.one;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!IsActive || GameHelper.IsPause)
            return;

        float distance = float.MaxValue;
        SquareController squareTo = null;
        foreach (var square in GameHelper.Squares.FindAll(s => s.IsMoveTo))
        {
            float d = Vector2.Distance(transform.position, square.transform.position);
            if (d < distance && d < distanceMin)
            {
                distance = d;
                squareTo = square;
            }
        }

        if (squareTo != null)
        {
            IsActive = false;            
        }

        Square = squareTo;

        if (WinСheck())
        {
            GameHelper.WinStatus = (int)UserColor;
            return;
        }

        if (squareTo != null)
        {            
            NextFigure();
        }
    }

    public void CheckWay()
    {
        if (IsActive && GameHelper.Squares.Find(s => s.IsMoveTo) == null)
        {
            if (GameHelper.CountStop >= 3)
            {
                GameHelper.WinStatus = (int)UserColor;
                return;
            }
            GameHelper.CountStop++;
            IsActive = false;
            NextFigure();
        }
    }

    public abstract void UpdateWay(bool moveTo);

    public abstract void NextFigure();

    public abstract bool WinСheck();

}
