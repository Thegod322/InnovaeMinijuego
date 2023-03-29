using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_Settings : MonoBehaviour
{
    public static bool isHardcore;
    public static bool isCheat;
    public Toggle Hardcore;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Hardcore") == 1) Hardcore.isOn = true;
        else Hardcore.isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        isHardcore = Hardcore.isOn;
        if (isHardcore) PlayerPrefs.SetInt("Hardcore", 1);
        else PlayerPrefs.SetInt("Hardcore", 0);
    }
}
