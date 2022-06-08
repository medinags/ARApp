using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
//TFG By Gerard Opazo
public class ARManager : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> casthits = new List<ARRaycastHit>();

    private GameObject pointer;
    private GameObject itemModel;
    private GameObject selectedItem;

    private bool isModelTouched;
    private bool isInitPos;
    private bool isUITouched;

    private Vector2 initTouchPos;
    public GameObject ItemModel {
        set
        {
            itemModel = value;
            itemModel.transform.position = pointer.transform.position;
            itemModel.transform.parent = pointer.transform;
            isInitPos = true;
        }
    
    
    }
    // Start is called before the first frame update
    void Start()
    {
        pointer = transform.GetChild(0).gameObject;
        raycastManager = FindObjectOfType<ARRaycastManager>();
        GameManager.instance.OnMainMenu += SetPosition;
    }


    // Update is called once per frame
    void Update()
    {
        if (isInitPos)
        {
            Vector2 middlePoint = new Vector2(Screen.width / 2, Screen.height / 2);
            raycastManager.Raycast(middlePoint, casthits, TrackableType.Planes);
            if (casthits.Count > 0)
            {
                transform.position = casthits[0].pose.position;
                transform.rotation = casthits[0].pose.rotation;
                pointer.SetActive(true);
                isInitPos = false;

            }
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                var touchPos = touch.position;
                isUITouched = isTapOverUI(touchPos);
                isModelTouched = isTapOverModel(touchPos);
            }
            if (touch.phase == TouchPhase.Moved)
            {
                if (raycastManager.Raycast(touch.position, casthits, TrackableType.Planes))
                {
                    Pose hitPose = casthits[0].pose;
                    if (!isUITouched && isModelTouched)
                    {
                        transform.position = hitPose.position;
                    }
                }
            }
            //Rotate with 2 fingers
            if (Input.touchCount == 2)
            {
                Touch touch2 = Input.GetTouch(1);
                if (touch.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
                {
                    initTouchPos = touch2.position - touch.position;
                }
                if (touch.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
                {
                    Vector2 currentTouch = touch2.position - touch.position;
                    float angle = Vector2.SignedAngle(initTouchPos, currentTouch);
                    itemModel.transform.rotation = Quaternion.Euler(0,itemModel.transform.eulerAngles.y -angle, 0);
                    initTouchPos = currentTouch;
                }
                
            }
            if (isModelTouched && itemModel == null && !isUITouched)
            {
                GameManager.instance.ARPositionMenu();
                itemModel = selectedItem;
                selectedItem = null;
                pointer.SetActive(true);
                transform.position = itemModel.transform.position;
                itemModel.transform.parent = pointer.transform;

            }
        }
    }

    private bool isTapOverModel(Vector2 touchPos)
    {
        Ray ray = cam.ScreenPointToRay(touchPos);
        if (Physics.Raycast(ray, out RaycastHit hitModel))
        {
            if(hitModel.collider.CompareTag("object"))
            {
                selectedItem = hitModel.transform.gameObject;
                return true;
            }
        }
        return false;
    }

    private bool isTapOverUI(Vector2 touchPos)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touchPos.x,touchPos.y);
        List<RaycastResult> res = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, res);
        return res.Count > 0;
    }
    private void SetPosition()
    {
        if (itemModel != null)
        {
            itemModel.transform.parent = null;
            pointer.SetActive(false);
            itemModel = null;
        }
    }
    public void DeleteObject()
    {
        Destroy(itemModel);
        pointer.SetActive(false);
        GameManager.instance.MainMenu();
    }
}
