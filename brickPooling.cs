using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickPooling : MonoBehaviour

{
    public GameObject brickPrefab;                                    //The column game object.
    public int brickPoolSize = 5;                                    //How many bricks to keep on standby.
    public float spawnRate = 3f;                                    //How quickly bricks spawn.
    public float brickMin = -1f;                                    //Minimum y value of the brick position.
    public float brickMax = 3.5f;                                    //Maximum y value of the brick position.

    private GameObject[] brick;                                    //Collection of pooled columns.
    private int currentbrick = 0;                                    //Index of the current column in the collection.

    private Vector2 objectPoolPosition = new Vector2(-15, -25);        //A holding position for our unused bricks offscreen.
    private float spawnXPosition = 10f;

    private float timeSinceLastSpawned;


    void Start()
    {
        timeSinceLastSpawned = 0f;

        //Initialize the columns collection.
        brick = new GameObject[brickPoolSize];
        //Loop through the collection... 
        for (int i = 0; i < brickPoolSize; i++)
        {
            //...and create the individual columns.
            brick[i] = (GameObject)Instantiate(brickPrefab, objectPoolPosition, Quaternion.identity);
        }
    }


    //This spawns columns as long as the game is not over.
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;

            //Set a random y position for the column
            float spawnYPosition = Random.Range(brickMin, brickMax);

            //...then set the current column to that position.
            brick[currentbrick].transform.position = new Vector2(spawnXPosition, spawnYPosition);

            //Increase the value of currentColumn. If the new size is too big, set it back to zero
            currentbrick++;

            if (currentbrick >= brickPoolSize)
            {
                currentbrick = 0;
            }
        }
    }
}