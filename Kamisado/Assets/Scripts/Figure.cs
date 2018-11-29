using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour
{
    /// <summary>
    /// Цвет фигуры
    /// </summary>
    [SerializeField]
    private ColorEnum _color;    

    /// <summary>
    /// Цвет игрока
    /// </summary>
    [SerializeField]
    private UserColorEnum _userColor;

    public ColorEnum Color { get { return _color; } }

    public UserColorEnum UserColot { get { return _userColor; } }   

}
