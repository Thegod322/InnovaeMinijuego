using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Armor : MonoBehaviour
{
    public int Damage;
    public S_HpSystem ownerHP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void DealDamage() 
    {
        ownerHP.DamageRecieved(Damage);
    }
}
