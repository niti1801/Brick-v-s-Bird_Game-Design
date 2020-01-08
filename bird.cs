using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{
    public float upForce = 200f;        //Upward force of the flap

    public bool isDead = false;        //has the player collided with a wall?
    private Rigidbody2D rb2d;           //holds a reference to the Rigidbody component of the bird
    private Animator anim;              //reference to the animator component
    public int healthVal = 1;
    public GameObject Sound;
    public AudioSource Sound2;
    public AudioSource Sound3;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();     //get and store a reference to the rigidbody2d attched to this GameObject
        anim = GetComponent<Animator>();        //get reference to the animator component attached to this GameObject
        Sound2.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)       //don't allow control if the bird has died
        {   
            if (Input.GetKeyDown("space"))    //look for an input to trigger a "flap"
            {
                anim.SetTrigger("Flap"); //tell the animator about it and then...
                rb2d.velocity = Vector2.zero;   //...zero out the birds current y velocity before...
                rb2d.AddForce(new Vector2(0, upForce));  //...giving the bird some upward force ////new vector2(rb2d.velocity.x, 0);
                Sound3.Pause();

            }


        }
    }

    void OnCollisionEnter2D()
    {
        rb2d.velocity = Vector2.zero;     //...zero out the birds velocity
        isDead = true;                    //if the bird collides with something set it to dead
        anim.SetTrigger("Die");           //tell the animator about it
        GameControl.instance.BirdDied();
        Sound2.Pause();
        Sound3.Play(0);
    }

    //OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "Collect", if it is...
        if (other.gameObject.CompareTag("Collect"))
        {
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Collect")
        {
            PlayerHealth.health += healthVal;
            Instantiate(Sound);
        }

    }
}
