using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;


    //Animator anim;
    GameObject player;
    _PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent<_PlayerHealth> ();
        //enemyHealth = GetComponent<EnemyHealth>();
        //anim = GetComponent <Animator> ();
        if (playerHealth == null) { Debug.Log("No Player"); }
        else { Debug.Log("Is Player"); }
    }


    void OnTriggerEnter (Collider other)
    {
        //Debug.Log("Enter" + other);
        if (other.gameObject == player)
        {
            //Debug.Log("Enter2");
            playerInRange = true;
        }
    }


    void OnTriggerExit (Collider other)
    {
        //Debug.Log("Leave"+other);
        if (other.gameObject == player)
        {
            //Debug.Log("Leave");
            playerInRange = false;
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks && playerInRange)// && enemyHealth.currentHealth > 0)
        {
            Debug.Log("Attack");
            Attack ();
        }

        /*
        if(playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger ("PlayerDead");
        }
        */
    }


    void Attack ()
    {
        timer = 0f;

        if(playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage (attackDamage);
        }
    }
}
