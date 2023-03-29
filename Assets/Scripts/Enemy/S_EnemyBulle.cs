using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EnemyBulle : MonoBehaviour
{
    S_EnemyController EnemyRef;
    S_PlayerControls PlayerRef;
    public GameObject explosionVFX;
    public GameObject explosionSFX;

    private void Start()
    {
        EnemyRef = GameObject.FindGameObjectWithTag("Enemy").GetComponent<S_EnemyController>();
        PlayerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<S_PlayerControls>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<S_Armor>())
        {
            collision.gameObject.GetComponent<S_Armor>().DealDamage();
        }
        Explode();
    }

    void Explode()
    {
        Instantiate(explosionVFX, transform.position, transform.rotation).transform.localScale = transform.localScale;
        Instantiate(explosionSFX, transform.position, transform.rotation).transform.localScale = transform.localScale;
        PlayerRef.MovingPhase();
        EnemyRef.isTurn = true;
        GameObject.FindGameObjectWithTag("GC").GetComponent<S_GameController>().TurnFinished(true);
        Destroy(this.gameObject);
    }
}
