using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float movSpeed;
    public GameObject GameObject;
    float speedX, speedZ;
    Rigidbody rb;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //find Z inputs
        if (Input.GetKey(KeyCode.UpArrow))
        {
            speedZ = 1;
            print("SpeedZ = 1");

            //rotate
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            speedZ = -1;
            print("SpeedZ = -1");

            //rotate
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            speedZ = 0;
        }

        //find X inputs
        if (Input.GetKey(KeyCode.RightArrow))
        {
            speedX = 1;
            print("SpeedX = 1");

            //rotate
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            speedX = -1;
            print("SpeedX = -1");

            //rotate
            transform.rotation = Quaternion.Euler(0f, 270f, 0f);
        }
        else
        {
            speedX = 0;
        }

        //when speedx/z is not 0, the player will move accordingly
        rb.velocity = new Vector3 (speedX * movSpeed, rb.velocity.y, rb.velocity.z);
        rb.velocity = new Vector3 (rb.velocity.x, rb.velocity.y, speedZ * movSpeed);


        //set animation
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            anim.Play("Slow Run");
        }
        else
        {
            anim.Play("Idle");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
