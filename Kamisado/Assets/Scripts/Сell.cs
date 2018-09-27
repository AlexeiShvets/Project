using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Сell : MonoBehaviour
{
    public ColorType Color;

    public int X;

    public int Y;

    public Figure Figure;

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
        Debug.Log(string.Format("{0} {1}",X,Y));
    }
}
