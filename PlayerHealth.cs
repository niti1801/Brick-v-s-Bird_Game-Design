using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{

	public static int health;
    //public GameObject particle;
    private GameObject player;

    Slider mainSlider;

	void Awake()
	{
		mainSlider = GetComponent<Slider>();
		health = 0;
	}

	void Start()
	{

        player = GameObject.FindWithTag("bird");

    }


    void Update()

    {

        mainSlider.value = health;

        if (health == 100)
        {
            StartCoroutine(Dead());
        }
            
    }


    IEnumerator Dead()
    {
            //Debug.Log("started");
        //Instantiate(particle, player.transform.position, player.transform.rotation);
        player.SetActive(false);
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(0);
        
       
    }

}

