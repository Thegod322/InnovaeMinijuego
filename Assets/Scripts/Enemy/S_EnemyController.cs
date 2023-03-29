using UnityEngine;
using UnityEngine.AI;

public class S_EnemyController : MonoBehaviour
{
    S_GameController gameController;
    public GameObject objectToSpawn;
    public bool isGameOn = true;
    public float maxSpawnRadius;
    GameObject DestinationRef;
    NavMeshAgent agent;
    public bool isTurn;
    bool didMoved;

    // Start is called before the first frame update
    void Start()
    {
        isTurn = true;
        gameController = GameObject.FindGameObjectWithTag("GC").GetComponent<S_GameController>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOn)
        {
            if (isTurn && !didMoved)
            {
                ChoseLocation();
                didMoved = true;
            }
            if (didMoved && !agent.pathPending && agent.remainingDistance < 0.5f)
            {
                gameController.TurnFinished(false);
                didMoved = false;
            }
        }
        
    }


    public void ChoseLocation()
    {
        /*Vector3 spawnLocation = transform.position + Random.insideUnitSphere * maxSpawnRadius;
        spawnLocation.y = 0; // set y to 0 to spawn on ground level
        DestinationRef = Instantiate(objectToSpawn, spawnLocation, Quaternion.identity);
        agent.SetDestination(DestinationRef.transform.position);*/


        NavMeshHit hit;
        Vector3 randomDirection = Random.insideUnitSphere * maxSpawnRadius;
        randomDirection += transform.position;
        NavMesh.SamplePosition(randomDirection, out hit, maxSpawnRadius, NavMesh.AllAreas);
        DestinationRef = Instantiate(objectToSpawn, hit.position, Quaternion.identity);
        agent.SetDestination(hit.position);
    }
}
