using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowData : MonoBehaviour
{
    [SerializeField] private GraphViewer graph;
    [SerializeField] private NewRequest newRequest;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    private void Initialize() 
    {
        newRequest = GameObject.Find("RestFulApiController").GetComponent<NewRequest>();
        graph = GetComponentInChildren<GraphViewer>();
        newRequest.graphs.Add(graph);
    }
}
