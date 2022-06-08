using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Video;
using UnityEngine.UI;

public class ImgRecognitionUIManager : MonoBehaviour
{
    public static ImgRecognitionUIManager instance;
    [SerializeField] private VideoPlayer videoUI;
    
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

    public void ShowUIImageRecognition()
    {
        this.transform.DOScale(Vector3.one, 0.5f);
        videoUI.Play();
    }

    public void HideUIImageRecognition()
    {
        this.transform.DOScale(Vector3.zero, 0.3f);
        videoUI.Stop();
    }


}
