using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    //_PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
    NavMeshAgent nav;
    //private float height; 


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        //playerHealth = player.GetComponent <_PlayerHealth> ();
        //enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <NavMeshAgent> ();
        //height = GetComponent<Transform>().position.y;

        //Face player on spawn
        GetComponent<Transform>().LookAt(player.GetComponent<Transform>());
    }


    void Update ()
    {
        //Vector3 newPosition = new Vector3(player.position.x, GetComponent<Transform>().position.y, player.position.z);
        
        nav.SetDestination(player.position);
        //GetComponent<Transform>().position.Set(GetComponent<Transform>().position.x, height, GetComponent<Transform>().position.z);
        /*
        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            nav.SetDestination (player.position);
        }
        else
        {
            nav.enabled = false;
        }
        */
    }
}
