using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Suicider : MonoBehaviour
{
    // Start is called before the first frame update
    public float delay = 2f;

    private void Start()
    {
        Destroy(this.gameObject, delay);
    }
}
