using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class restartLevel : MonoBehaviour{
    //public GameObject particle;
    //private GameObject player;
    //public Rigidbody2D PlayerRigid;

    void Start()
    {
        //player = GameObject.FindWithTag("Player");
        //PlayerRigid = player.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
	{
        if (other.gameObject.tag == "bird" )
            //StartCoroutine(RestartLevel());
            SceneManager.LoadScene(0);
    }

    

}




