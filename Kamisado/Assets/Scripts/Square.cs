using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Square : MonoBehaviour
{
    /// <summary>
    /// Цвет поля
    /// </summary>
    [SerializeField]
    private ColorEnum _color;

    /// <summary>
    /// Место по оси Х
    /// </summary>
    [SerializeField]
    private int _x;

    /// <summary>
    /// Место по оси Y
    /// </summary>
    [SerializeField]
    private int _y;

    public ColorEnum Color { get { return _color; } }

    public int X
    {
        get { return _x; }
        set { _x = value; }
    }

    public int Y
    {
        get { return _y; }
        set { _y = value; }
    }
}
