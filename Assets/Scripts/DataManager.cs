using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TFG By Gerard Opazo
public class DataManager : MonoBehaviour
{
    [SerializeField] private List<Item> items = new List<Item>();
    [SerializeField] private GameObject buttonContainer;
    [SerializeField] private ButtonManager buttonManager;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.OnSelectorMenu += CreateButton;
    }

    private void CreateButton()
    {
        foreach (var x in items)
        {
            ButtonManager button;
            button = Instantiate(buttonManager, buttonContainer.transform);
            button.ItemName = x.ItemName;
            button.ItemDescription = x.ItemDescription;
            button.ItemSprite = x.ItemSprite;
            button.ItemModel = x.ItemModel;
            button.name = x.ItemName;
        }
        GameManager.instance.OnSelectorMenu -= CreateButton;
    }

}
