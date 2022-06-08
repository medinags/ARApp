using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject selectorMenuCanvas;
    [SerializeField] private GameObject ARPositionMenuCanvas;    
    [SerializeField] private GameObject InputIDCanvas;

    private bool toggleUIIDs;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.OnMainMenu += ActivateMainMenu;
        GameManager.instance.OnSelectorMenu += ActivateSelectorMenu;
        GameManager.instance.OnARPosition += ActivateARPositionMenu;
        GameManager.instance.OnInputID += ActivateInputIDMenu;
    }

    private void ActivateInputIDMenu()
    {
        mainMenuCanvas.transform.GetChild(0).transform.DOScale(new Vector3(1, 1, 1), 0.3f);
        mainMenuCanvas.transform.GetChild(1).transform.DOScale(new Vector3(1, 1, 1), 0.3f);
        mainMenuCanvas.transform.GetChild(2).transform.DOScale(new Vector3(1, 1, 1), 0.3f);

        selectorMenuCanvas.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        selectorMenuCanvas.transform.GetChild(1).transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        selectorMenuCanvas.transform.GetChild(1).transform.DOMoveY(180, 0.3f);

        ARPositionMenuCanvas.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        ARPositionMenuCanvas.transform.GetChild(1).transform.DOScale(new Vector3(0, 0, 0), 0.3f);

        toggleUIIDs = !toggleUIIDs;
        if (toggleUIIDs)
        {
            InputIDCanvas.transform.GetChild(0).transform.DOScale(new Vector3(1, 1, 1), 0.3f);
            InputIDCanvas.transform.GetChild(1).transform.DOScale(new Vector3(1, 1, 1), 0.3f);
        }
        else
        {
            InputIDCanvas.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.3f);
            InputIDCanvas.transform.GetChild(1).transform.DOScale(new Vector3(0, 0, 0), 0.3f);
            InputIDFieldUIManager.instance.HideIDField();
            ImgRecognitionUIManager.instance.HideUIImageRecognition();
        }



    }

    private void ActivateMainMenu()
    {
        mainMenuCanvas.transform.GetChild(0).transform.DOScale(new Vector3 (1,1,1), 0.3f);
        mainMenuCanvas.transform.GetChild(1).transform.DOScale(new Vector3 (1,1,1), 0.3f);
        mainMenuCanvas.transform.GetChild(2).transform.DOScale(new Vector3 (1,1,1), 0.3f);

        selectorMenuCanvas.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        selectorMenuCanvas.transform.GetChild(1).transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        selectorMenuCanvas.transform.GetChild(1).transform.DOMoveY(180, 0.3f);

        ARPositionMenuCanvas.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        ARPositionMenuCanvas.transform.GetChild(1).transform.DOScale(new Vector3(0, 0, 0), 0.3f);


        InputIDCanvas.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        InputIDCanvas.transform.GetChild(1).transform.DOScale(new Vector3(0, 0, 0), 0.3f);

    }

    private void ActivateARPositionMenu()
    {
        mainMenuCanvas.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        mainMenuCanvas.transform.GetChild(1).transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        mainMenuCanvas.transform.GetChild(2).transform.DOScale(new Vector3(0, 0, 0), 0.3f);

        selectorMenuCanvas.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        selectorMenuCanvas.transform.GetChild(1).transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        selectorMenuCanvas.transform.GetChild(1).transform.DOMoveY(180, 0.3f);

        ARPositionMenuCanvas.transform.GetChild(0).transform.DOScale(new Vector3(1, 1, 1), 0.3f);
        ARPositionMenuCanvas.transform.GetChild(1).transform.DOScale(new Vector3(1, 1, 1), 0.3f);
    }

    private void ActivateSelectorMenu()
    {
        mainMenuCanvas.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        mainMenuCanvas.transform.GetChild(1).transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        mainMenuCanvas.transform.GetChild(2).transform.DOScale(new Vector3(0, 0, 0), 0.3f);

        selectorMenuCanvas.transform.GetChild(0).transform.DOScale(new Vector3(1, 1, 1), 0.5f);
        selectorMenuCanvas.transform.GetChild(1).transform.DOScale(new Vector3(1, 1, 1), 0.3f);
        selectorMenuCanvas.transform.GetChild(1).transform.DOMoveY(300, 0.3f);
    }

    public void OnImageRecognition() 
    {
        InputIDCanvas.transform.GetChild(1).transform.DOScale(new Vector3(0, 0, 0), 0.3f);
    }

    public void OnInputField() 
    {
        InputIDCanvas.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.3f);
    }
}
