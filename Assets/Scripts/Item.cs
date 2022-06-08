using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
//TFG by Gerard Opazo
public class Item : ScriptableObject //This is a data container to define the data of each 3d object
{
    // Start is called before the first frame update
    public string ItemName;
    public Sprite ItemSprite;
    public string ItemDescription;
    public GameObject ItemModel;

}
