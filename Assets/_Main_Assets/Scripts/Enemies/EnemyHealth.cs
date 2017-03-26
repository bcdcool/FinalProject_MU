using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    //public AudioClip deathClip;


    //Animator anim;
    //AudioSource enemyAudio;
    //ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;

    //public GameObject explosion;
    //public GameObject playerExplosion;
    //public int scoreValue;
    private GameController gameController;

    void Awake ()
    {
        //anim = GetComponent <Animator> ();
        //enemyAudio = GetComponent <AudioSource> ();
        //hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

        currentHealth = startingHealth;
    }


    void Update ()
    {
        if(isSinking)
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage (int amount)
    {
        if(isDead)
            return;

        //enemyAudio.Play ();

        currentHealth -= amount;
            
        //hitParticles.transform.position = hitPoint;
        //hitParticles.Play();

        if(currentHealth <= 0)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        gameController.AddScore(scoreValue);

        Destroy(gameObject);

        //anim.SetTrigger ("Dead");

        //enemyAudio.clip = deathClip;
        //enemyAudio.Play ();
    }


    public void StartSinking ()
    {
        GetComponent <NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
        isSinking = true;
        gameController.AddScore(scoreValue);
        Destroy (gameObject, 2f);
    }

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            //return;
            Debug.Log(other.name); 
            //gameController.AddScore(scoreValue);
            //Destroy(other.gameObject);
            TakeDamage(10);
            //Destroy(gameObject);

        }
        /*
        if (other.tag == "Boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        //Debug.Log(other.name); 
        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
        */
    }
}
