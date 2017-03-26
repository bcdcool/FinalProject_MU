using UnityEngine;
using System.Collections;

public class _PlayerShoot : MonoBehaviour {

    //public int damagePerShot = 20;
    //public float timeBetweenBullets = 0.15f;
    //public float range = 100f;

    /*
    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    //AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;
    */


    //public float speed;
    //public float tilt;
    //public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate;
    private float nextFire;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //GameObject clone = 
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);// as GameObject; 

            //GetComponent<AudioSource>().Play();
        }
    }
}
