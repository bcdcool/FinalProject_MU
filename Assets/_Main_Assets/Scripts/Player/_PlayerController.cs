using UnityEngine;
using System.Collections;

public class _PlayerController : MonoBehaviour {

    public float speed = 6f;
    public float tilt;

    Vector3 movement;
    //Animator anim;
    //Rigidbody playerRigidbody;
    Rigidbody baseRigidbody;
    Rigidbody turrentRigidbody;
    GameObject turrent; 
    int floorMask;
    float camRayLength = 100f;

    

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        //anim = GetComponent<Animator>();
        //playerRigidbody = GetComponent<Rigidbody>();
        baseRigidbody = GameObject.FindGameObjectWithTag("Base").GetComponent<Rigidbody>();
        turrentRigidbody = GameObject.FindGameObjectWithTag("Turrent").GetComponent<Rigidbody>();
        //turrent = GameObject.FindGameObjectWithTag("Turrent");
       
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        TurningTurrent();
        //Animating(h, v);
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);

        movement = movement.normalized * speed * Time.deltaTime;

        //playerRigidbody.MovePosition(transform.position + movement);
        GetComponent<Transform>().position += movement;  // MovePosition(transform.position + movement);
        //turrentRigidbody.MovePosition(transform.position + movement);


        //turrentRigidbody.MovePosition(transform.position + movement);
        baseRigidbody.velocity = movement * speed;
        //Debug.Log(baseRigidbody.velocity.x + " " + baseRigidbody.velocity.y);
        baseRigidbody.rotation = Quaternion.Euler(baseRigidbody.velocity.z * tilt, 0f, baseRigidbody.velocity.x * -tilt);
    }
    /*
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;



        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0f, 0f, GetComponent<Rigidbody>().velocity.x * -tilt);

    }
    */
    void TurningTurrent()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            turrentRigidbody.MoveRotation(newRotation);
            //turrent.GetComponent<Transform>().Rotate(playerToMouse); 
        }
    }

    /*
    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }
    */
}
