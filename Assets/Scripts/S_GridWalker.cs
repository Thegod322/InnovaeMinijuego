using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GridWalker : MonoBehaviour
{
    [SerializeField]int startX;
    [SerializeField] int startY;
    [SerializeField] int EndX;
    [SerializeField] int EndY;
    S_Grid myGrid;
    
    // Start is called before the first frame update
    void Start()
    {
        myGrid = GameObject.FindGameObjectWithTag("Grid").GetComponent<S_Grid>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
