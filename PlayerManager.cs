using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

    public static int scoreValue = 10;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ReduceHealth", 1, 1);
    }

    // Update is called once per frame
    void ReduceHealth()
    {
        scoreValue = scoreValue - 2;
        if (scoreValue <= 0)
        {
            Player.GetComponent<Animator>().SetTrigger("die");
        }
    }

    void Update()
    {

    }
}
