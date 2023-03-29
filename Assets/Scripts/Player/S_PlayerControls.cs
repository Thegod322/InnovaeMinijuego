using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class S_PlayerControls : MonoBehaviour
{

    public Camera cam;
    public NavMeshAgent agent;
    float maxDistance = 10f;
    public bool isTurn;
    bool isMoving;
    bool isMovingPhase = true;
    public bool isGameOn = true;
    public GameObject TowerCam;
    public S_TowerControls towerScr;
    public GameObject Body;
    // Start is called before the first frame update
    void Start()
    {
       // agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTurn && isGameOn)
        {
            if (Input.GetMouseButtonDown(0) && isMovingPhase)
            {
                isMoving = true;
            }

            if (isMoving )
            {
                Body.GetComponent<LineRenderer>().enabled = false;
                agent.speed = 3.5f;
                agent.angularSpeed = 50;
                if (agent.remainingDistance < 0.1f && isMovingPhase)
                {
                    // The agent has arrived at the destination
                    ShootingPhase();
                    Body.GetComponent<LineRenderer>().enabled = false;

                    agent.destination = Vector3.zero;
                }
            }
            else
            {
                if (isMovingPhase)
                {
                    Body.GetComponent<LineRenderer>().enabled = true;

                    Ray MouseCast = cam.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(MouseCast, out hit))
                    {
                        Vector3 direction = hit.point - transform.position;
                        if (direction.magnitude <= maxDistance)
                        {
                            agent.SetDestination(hit.point);
                        }
                    }
                    agent.speed = 0;
                    agent.angularSpeed = 0;

                    // Check if the distance is within the maximum limit
                    
                }

            }
            GetComponent<S_PathVisuals>().UpdateVisuals();
        }
        
        

    }

    public void TurnStarted()
    {
        isMoving = false;
    }
    void ShootingPhase()
    {
        TowerCam.SetActive(true);
        towerScr.isShootingPhase = true;
        isMovingPhase = false;
        isMoving = false;
    }
    public void MovingPhase()
    {
        TowerCam.SetActive(false);
        towerScr.isShootingPhase = false;
        isMovingPhase = true;

    }
}
