using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class S_UiController : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Tips;
    public TextMeshProUGUI WinLoseText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("TankBattle");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void ShowMenu(bool isPlayerWin)
    {
        print(isPlayerWin);
        Menu.SetActive(true);
        if (isPlayerWin) WinLoseText.text = "You Win";
        else WinLoseText.text = "You Lose";
    }
    public void showTips()
    {
        Tips.SetActive(true);
    }
    public void HideTips()
    {
        Tips.SetActive(false);

    }
}
