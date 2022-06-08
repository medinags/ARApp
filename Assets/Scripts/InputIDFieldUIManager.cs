using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class InputIDFieldUIManager : MonoBehaviour
{
    public static InputIDFieldUIManager instance;
    public TMP_InputField inputField;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    
    public void ShowIDField() 
    {
        this.transform.DOScale(Vector3.one, 0.3f);
    }

    public void HideIDField()
    {
        this.transform.DOScale(Vector3.zero, 0.3f);
        inputField.text = "Introduce ID...";
    }

    public void ErrorInput(string error) 
    {
        inputField.text = error;
    }
}
