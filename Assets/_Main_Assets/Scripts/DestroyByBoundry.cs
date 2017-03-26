using UnityEngine;
using System.Collections;

public class DestroyByBoundry : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Projectile")
        {
            Destroy(other.gameObject);
        }
        
    }
	
}
