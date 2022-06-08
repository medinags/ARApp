using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//TFG By Gerard Opazo
public class GameManager : MonoBehaviour
{
    public event Action OnMainMenu;
    public event Action OnSelectorMenu;
    public event Action OnARPosition;
    public event Action OnInputID;

    //We use a singleton pattern to call and subscribe to events, una sola instancia y globalmente accesible

    public static GameManager instance;

    private void Awake()
    {
        if (instance!=null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        MainMenu();
    }

    public void MainMenu()
    {
        OnMainMenu?.Invoke();
        Debug.Log("Main Menu is activated");

    }
    public void SelectorMenu()
    {
        OnSelectorMenu?.Invoke();
        Debug.Log("Selector Menu is activated");
    }
    public void ARPositionMenu()
    {
        OnARPosition?.Invoke();
        Debug.Log("ARPosition is activated");
    }
    public void InputId()
    {
        OnInputID?.Invoke();
        Debug.Log("InputID is activated");
    }
    public void CloseAPP()       
    {
        Application.Quit();
    }
}
