using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHelper : MonoBehaviour
{
    /// <summary>
    /// Клетки поля
    /// </summary>
    public static List<SquareController> Squares { private set; get; }

    /// <summary>
    /// Фигуры белого игрока
    /// </summary>
    public static List<FigureController> WhiteFigures { private set; get; }

    /// <summary>
    /// Фигуры ченого игрока
    /// </summary>
    public static List<FigureController> BlackFigures { private set; get; }

    /// <summary>
    /// Количество цветов
    /// </summary>
    public const int ColorCount = 8;

    /// <summary>
    /// Ослеиванеи тупекового хода
    /// </summary>
    public static int CountStop = 0;

    /// <summary>
    /// Пауза
    /// </summary>
    public static bool IsPause = false;
    
    /// <summary>
    /// Первый ход
    /// </summary>
    public static bool IsFirstСourse = true;

    /// <summary>
    /// Статус побезителя
    /// </summary>
    public static int WinStatus;

    [SerializeField]
    private Text _text;
    [SerializeField]
    private GameObject _panel;
    [SerializeField]
    private GameObject _panelInfo;

    
    
    // Use this for initialization
    void Start()
    {
        WinStatus = -1;
        IsPause = false;
        IsFirstСourse = true;
        _panel.SetActive(false);
        _panelInfo.SetActive(false);
        
        WhiteFigures = new List<FigureController>();
        BlackFigures = new List<FigureController>();
        var figures = FindObjectsOfType(typeof(FigureController)) as FigureController[];
        foreach (var figure in figures)
        {
            switch (figure.UserColor)
            {
                case UserColorEnum.Black:
                    BlackFigures.Add(figure);
                    break;
                case UserColorEnum.White:
                    WhiteFigures.Add(figure);
                    break;
            }
        }
        
        Squares = new List<SquareController>();
        var squares = FindObjectsOfType(typeof(SquareController)) as SquareController[];
        foreach (var square in squares)
        {
            Squares.Add(square);
        }
    }

    void Update()
    {
        if (WinStatus == (int)UserColorEnum.White)
        {
            IsPause = true;
            _text.text = "Win P2";
           _panel.SetActive(true);
        }
        else if (WinStatus == (int)UserColorEnum.Black)
        {
            IsPause = true;
            _text.text = "Win P1";
            _panel.SetActive(true);
        }        
    }   

    /// <summary>
    /// Открыть правила игры
    /// </summary>
    public void OpenInfo()
    {
        IsPause = true;
        _panel.SetActive(false);
        _panelInfo.SetActive(!_panelInfo.activeSelf);
        IsPause = _panelInfo.activeSelf;
    }

    /// <summary>
    /// Пауза
    /// </summary>
    public void Pause()
    {        
        _panelInfo.SetActive(false);
        _panel.SetActive(!_panel.activeSelf);
        _text.text = "Pause";
        IsPause = _panel.activeSelf;
    }

    /// <summary>
    /// ВЫход
    /// </summary>
    public void Exit()
    {
        _panelInfo.SetActive(false);
        _panel.SetActive(false);
        Application.Quit();
    }

    /// <summary>
    /// Переиграть
    /// </summary>
    public void Reset()
    {
        _panelInfo.SetActive(false);
        _panel.SetActive(false);
        Application.LoadLevel(Application.loadedLevel);
    }
}

