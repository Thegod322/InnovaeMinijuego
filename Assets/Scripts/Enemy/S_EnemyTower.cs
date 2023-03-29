using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EnemyTower : MonoBehaviour
{

    
    public Transform player;
    public S_EnemyController EnemyRef;
    public float rotationSpeed = 5f;
    float maxDelayBeforseShot = 1f;
    float delay;
    public Transform Canon;
    S_Shooting ShootingScr;
    float aimCanon;
    float aimCharge;
    public bool isShootingPhase;

    private void Awake()
    {
        delay = maxDelayBeforseShot;
        ShootingScr = GetComponent<S_Shooting>();
    }
    private void Update()
    {

        if (isShootingPhase && EnemyRef.isGameOn)
        {
            Aim();
        }
    }
    public void Aim()
    {
        transform.LookAt(player);
        delay -= Time.deltaTime;
        if (delay<=0)
        {
            aimCanon = Random.Range(0,10);
            aimCharge = Random.Range(70,100);
            Canon.localEulerAngles = new Vector3(aimCanon, 0, 0);
            ShootingScr.Shoot(aimCharge,false);
            delay = maxDelayBeforseShot;
            isShootingPhase = false;
        }
    }
}

