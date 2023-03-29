using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_TowerControls : MonoBehaviour
{
    public bool isShootingPhase;
    bool isAiming;
    Transform canon;
    S_Shooting ShootScr;
    [SerializeField]GameObject ChargeBar;
    [SerializeField]S_UiController uiController;
    Slider ChargeSlider;
    public float towerSpeed;
    public float canonRotation;
    float minRotation = -15.0f;
    float maxRotation = 40.0f;

    bool shootStart;
    bool isCharging;
    float chargeMax = 100;
    float charge;
    [SerializeField] float chargeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        ShootScr = GetComponent<S_Shooting>();
        ChargeSlider = ChargeBar.GetComponent<Slider>();
        ChargeBar.SetActive(false);
        canon = transform.GetChild(0);
        //isShootingPhase = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            isAiming = true;
        }
        else
        {
            isAiming = false;
        }

        if (Input.GetMouseButtonDown(0) && isShootingPhase)
        {
                shootStart = true;
                ChargeBar.SetActive(true);

        }
        if (Input.GetMouseButtonUp(0) && isShootingPhase)
        {

            ShootScr.Shoot(charge,true);
            ChargeBar.SetActive(false);
            isShootingPhase = false;
            uiController.HideTips();


            shootStart = false;
            charge = 0;

        }

        if (shootStart)
        {
            if (isCharging)
            {
                charge+=chargeSpeed;
                if (charge >= chargeMax) isCharging = false; 
            }
            else
            {
                charge-=chargeSpeed;
                if (charge <= 0) isCharging = true;
            }
            ChargeSlider.value = charge;
        }
        if (isShootingPhase &&  isAiming)
        {
            towerSpeed = Input.GetAxis("Mouse X");
            canonRotation += Input.GetAxis("Mouse Y");
            canonRotation = Mathf.Clamp(canonRotation, minRotation, maxRotation);
            if(PlayerPrefs.GetInt("Hardcore") == 0)
            GetComponent<S_Shooting>().DrawTrajectory();

            transform.Rotate(new Vector3(0, 0, towerSpeed), Space.Self);
            canon.transform.localEulerAngles = new Vector3(canonRotation, 0, 0);
        }
        else
        {
            GetComponent<S_Shooting>().Trajectory.enabled = false;
        }
        if (isShootingPhase)
        {
            uiController.showTips();
        }
        
        
    }
}
