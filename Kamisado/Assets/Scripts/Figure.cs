using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour
{
    public ColorType Color;

    public UserType UserType;

    public int IdUser;

    public Сell Cell;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() //функция клика мышью
    {
        if(Cell!=null)
            Debug.Log(string.Format("{0} {1}", Cell.X, Cell.Y));
        else
            Debug.Log("null");

        Cell = null;
    }
}
