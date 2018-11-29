using System;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;

public class GameHelper : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private Transform canvas;

    public static List<Square> Squares { private set; get; }
    public static List<Figure> Figures { private set; get; }

    public static UserColorEnum User;
    public static ColorEnum Color;

    private Figure _curretFigure;
    public Dictionary<Figure, Square> Field;


    public Figure CurretFigure
    {
        get { return _curretFigure; }
        set
        {
            _curretFigure = value;
            foreach (var square in Squares)
            {
                square.IsMoveTo = false;
                if(square.Color == ColorEnum.Red)
                    square.IsMoveTo = true;


            }
        }
    }

    // Use this for initialization
    void Start()
    {
        Field = new Dictionary<Figure, Square>();
        var figures = FindObjectsOfType(typeof(Figure)) as Figure[];
        Figures = new List<Figure>();

        foreach (var figure in figures)
        {
            Figures.Add(figure);
            Field.Add(figure, null);
        }

        Squares = new List<Square>();
        var squares = FindObjectsOfType(typeof(Square)) as Square[];
        foreach (var square in squares)
        {

            Squares.Add(square);
        }

        CurretFigure = Figures[0];
    }

    public void OnDrag(PointerEventData eventData)
    {
        CurretFigure.transform.SetParent(canvas);
        CurretFigure.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        float distance = float.MaxValue;
        Square squareTo = null;
        foreach (var square in Squares.FindAll(s=>s.IsMoveTo))
        {
            float d = Vector2.Distance(CurretFigure.transform.position, square.transform.position);
            if (d < distance)
            {
                distance = d;
                squareTo = square;
            }

        }

        if (squareTo == null)
            return;

        CurretFigure.transform.SetParent(squareTo.transform);
        CurretFigure.transform.position = squareTo.transform.position;
        CurretFigure.transform.localScale = Vector2.one;

        CurretFigure = Figures.Find(f => f.UserColot != CurretFigure.UserColot && f.Color == squareTo.Color);

    }


    // Update is called once per frame
    void Update()
    {

    }
}

