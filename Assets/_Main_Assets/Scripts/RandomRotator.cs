using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {
    public float speed;

    // Use this for initialization
    void Start()
    {
       // GetComponent<Rigidbody>().angularVelocity = Random.insideUnitCircle * speed;
    }

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 1 * speed, 0), Space.Self);
    }
	

}
