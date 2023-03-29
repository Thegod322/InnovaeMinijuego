using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_TowerFollower : MonoBehaviour
{
    public Transform Socket;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Socket.position;
    }
}
