using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_HpSystem : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField]int Hp = 100;
    [SerializeField] Slider hpBar;
    public Material DestroyedMat;
    public MeshRenderer tower;
    public MeshRenderer body;
    public MeshRenderer canon;
    public GameObject FireVFX;
    S_GameController Gc;
    float damageDelayMax = 1f;
    float damageDelay;
    bool canBeDamaged;
    // Start is called before the first frame update
    void Start()
    {
        canBeDamaged = true;
        Gc = GameObject.FindGameObjectWithTag("GC").GetComponent<S_GameController>();
        hpBar.value = Hp;

    }

    // Update is called once per frame
    void Update()
    {
        if (!canBeDamaged)
        {
            damageDelay -= Time.deltaTime;
            if (damageDelay < 0)
            {
                canBeDamaged = true;
                damageDelay = damageDelayMax;
            }
        }
    }

    public void DamageRecieved(int Damage)
    {
        if (canBeDamaged) 
        {
            Hp -= Damage;
            canBeDamaged = false;
        }
        if (isPlayer )
        {
            if (Hp<=0)
            {
                Gc.GameEnded(false);
                ApplyDestruction();

            }
        }
        else
        {
            if (Hp<=0)
            {
                Gc.GameEnded(true);
                ApplyDestruction();
            }
        }
        hpBar.value = Hp;
       
    }

    void ApplyDestruction()
    {
        tower.material = DestroyedMat;
        body.material = DestroyedMat;
        canon.material = DestroyedMat;
        Instantiate(FireVFX,transform.position,transform.rotation);
    }
}
