using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImgTargetsManager : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager aRTrackedImageManager;
    [SerializeField] private NewRequest request;
    [SerializeField] private bool IsImgRecognitionEnabled;
    private string LastID;
    private void OnEnable()
    {
        aRTrackedImageManager.trackedImagesChanged += ImageFound;

    }

    private void Start()
    {
        GameManager.instance.OnMainMenu += DisableRecognition;
    }

    private void OnDisable()
    {
        aRTrackedImageManager.trackedImagesChanged -= ImageFound;
    }

    private void ImageFound(ARTrackedImagesChangedEventArgs eventData)
    {
        if (IsImgRecognitionEnabled)
        {
            foreach (var trackedImage in eventData.added)
            {
                SendIDReq(trackedImage);
            }
            foreach (var trackedImage in eventData.updated)
            {
                if (trackedImage.trackingState == TrackingState.Tracking)
                {
                    SendIDReq(trackedImage);
                }
            }
        }
    }

    private void SendIDReq(ARTrackedImage trackedImage) 
    {
        string ID = trackedImage.referenceImage.name;

        if (LastID != ID)
        {
            request.Start_RestfulCall(ID);
            Debug.Log("---------" + ID);
        }

        LastID = ID;
    }

    public void EnableRecognition() 
    {
        IsImgRecognitionEnabled = true;
    }

    public void DisableRecognition()
    {
        IsImgRecognitionEnabled = false;
    }

    
}
