using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_RtsCamera : MonoBehaviour
{
    float cameraSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            cameraSpeed = Input.GetAxis("Mouse X");
            transform.Rotate(0,cameraSpeed,0,Space.World);
        }


    }

    public void iniCamera()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
    }
}
