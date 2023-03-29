using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Bullet : MonoBehaviour
{
    bool damageDone;
    S_EnemyTower EnemyRef;
    public GameObject explosionVFX;
    public GameObject explosionSFX;

    // Start is called before the first frame update

    private void Start()
    {
        EnemyRef = GameObject.FindGameObjectWithTag("EnemyTower").GetComponent<S_EnemyTower>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<S_Armor>() && damageDone)
        {
            other.GetComponent<S_Armor>().DealDamage();
            damageDone = true;
        }
        Explode();
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
        EnemyRef.isShootingPhase = true;
        Destroy(this.gameObject);
    }
}
