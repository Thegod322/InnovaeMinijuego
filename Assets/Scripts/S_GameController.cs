using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class S_GameController : MonoBehaviour
{
    public CinemachineVirtualCamera RTSCam;
    public GameObject VcamRef;
    public GameObject Player;
    public GameObject Enemy;
    public S_UiController uiController;
    float maxDelay = 2f;
    float delay;
    bool gameEnded;
    bool PlayerWin;
    // Start is called before the first frame update
    void Start()
    {
        delay = maxDelay;
        RTSCam.Follow = Enemy.transform;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TurnFinished(bool isPlayer)
    {
        Enemy.GetComponent<S_EnemyController>().isTurn = isPlayer;
        Player.GetComponent<S_PlayerControls>().isTurn = !isPlayer;
        VcamRef.GetComponent<S_RtsCamera>().iniCamera();
        if (isPlayer) RTSCam.Follow = Enemy.transform;
        else RTSCam.Follow = Player.transform;
    }


    public void GameEnded(bool isPlayerWin) 
    {
        Player.GetComponent<S_PlayerControls>().isGameOn = false;
        Enemy.GetComponent<S_EnemyController>().isGameOn = false;
        PlayerWin = isPlayerWin;
        uiController.ShowMenu(PlayerWin);
        if(isPlayerWin) Player.GetComponent<S_PlayerControls>().MovingPhase();
    }
}
