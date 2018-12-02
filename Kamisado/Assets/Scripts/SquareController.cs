using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareController : Square
{
    private GameObject _wayTo;
    public bool IsFigure;
    
    public bool IsMoveTo
    {
        get { return _wayTo.activeSelf; }
        set
        {            
            _wayTo.SetActive(value);
        }
    }

    void Start()
    {
        _wayTo = Instantiate(Resources.Load("WayTo")) as GameObject;
        _wayTo.SetActive(false);
        _wayTo.transform.SetParent(transform);
        _wayTo.transform.position = transform.position;
        _wayTo.transform.localScale = Vector2.one;
    }
}
