using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{

    public float speed;
    public ParticleSystem explosionParticles;
    public AudioSource explosionAudio; 

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        //explosionParticles = GetComponent<ParticleSystem>(); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //explosionParticles.transform.parent = null;
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Particles");
            explosionParticles.transform.parent = null;

            explosionParticles.Play();

            explosionAudio.Play();

            Destroy(explosionParticles.gameObject, explosionParticles.duration);
            Destroy(gameObject);

            if (other.gameObject.GetComponent<EnemyHealth>() != null)
            {
                other.gameObject.GetComponent<EnemyHealth>().TakeDamage(10); 
            }
        }
        
        //m_ExplosionAudio.Play();

        //Destroy(explosionParticles.gameObject, explosionParticles.duration);
        //Destroy(gameObject);
    }
}
