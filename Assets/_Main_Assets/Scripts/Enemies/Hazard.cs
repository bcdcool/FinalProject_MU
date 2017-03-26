using UnityEngine;
using System.Collections;

public class Hazard : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            //Destroy(other.gameObject);
        }
        /*
        if (other.gameObject.tag == "Player")
        {
            //player = GameObject.FindGameObjectWithTag("Player");
            _PlayerHealth playerHealth = other.gameObject.GetComponent<_PlayerHealth>();//player.GetComponent<_PlayerHealth>();

        }*/
    }
}
