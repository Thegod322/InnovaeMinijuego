using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Shooting : MonoBehaviour
{
    public Transform BulletSpawn;
    public GameObject ShootVFX;
    public GameObject Bullet;
    public GameObject EnemyBullet;
    public Vector3 bulletImpulse;
    public LineRenderer Trajectory;
    public int linePoints;
    public float timeBetweenPoints;
    public AudioClip ShootSfx;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
           // Shoot();
        }
    }


    public void Shoot(float charge, bool isPlayer) 
    {
        charge = charge / 100f;
        Vector3 chargedBulletImpulse = bulletImpulse * charge;
        //Instantiate(Bullet,BulletSpawn.position,BulletSpawn.rotation).GetComponent<Rigidbody>().AddRelativeForce(bulletImpulse);
        if(isPlayer)Instantiate(Bullet,BulletSpawn.position,BulletSpawn.rotation).GetComponent<Rigidbody>().AddRelativeForce(chargedBulletImpulse,ForceMode.Impulse);
        else Instantiate(EnemyBullet,BulletSpawn.position,BulletSpawn.rotation).GetComponent<Rigidbody>().AddRelativeForce(chargedBulletImpulse,ForceMode.Impulse);
        Instantiate(ShootVFX, BulletSpawn.position, BulletSpawn.rotation).transform.localScale = new Vector3(0.15f,0.15f,0.15f);
        audioSource.clip = ShootSfx;
        audioSource.Play();

    }

    public void DrawTrajectory()
    {
        Trajectory.enabled = true;
        Trajectory.positionCount = linePoints;
        Vector3 initialVelocity = BulletSpawn.TransformDirection(bulletImpulse);

        for (int i = 0; i < linePoints; i++)
        {
            float time = i * timeBetweenPoints;
            Vector3 point = BulletSpawn.position + initialVelocity * time + 0.5f * Physics.gravity * time * time;
            Trajectory.SetPosition(i, point);
        }
    }
}
