using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//TFG By Gerard Opazo
public class ButtonManager : MonoBehaviour
{
    private string itemName;
    private string itemDescription;
    private Sprite itemSprite;
    private GameObject itemModel;
    public string ItemName { set => itemName = value;}
    public string ItemDescription { set => itemDescription = value;}
    public Sprite ItemSprite { set => itemSprite = value; }
    public GameObject ItemModel { set => itemModel = value; }
    private ARManager aRManager;


    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = itemName;
        transform.GetChild(1).GetComponent<RawImage>().texture = itemSprite.texture;
        transform.GetChild(2).GetComponent<TMPro.TextMeshProUGUI>().text = itemDescription;
        var but = GetComponent<Button>();
        but.onClick.AddListener(GameManager.instance.ARPositionMenu);
        but.onClick.AddListener(CreateObject);

        aRManager = FindObjectOfType<ARManager>();
    }

    private void CreateObject()
    {
        aRManager.ItemModel = Instantiate(itemModel);
    }

}
