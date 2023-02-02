using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    //spawn boundaries
    public Vector3 spawnBoundaries;

    //spawn time and counter
    private float spawnTime;
    private float spawnTimeCounter;

    //asteroid prefabs
    public GameObject asteroid;

    //draw it for debug
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.2f);
        Gizmos.DrawCube(transform.position, spawnBoundaries);
    }

    // Start is called before the first frame update
    void Start()
    {
        //init spawn time and counter
        spawnTime = 2f;
        spawnTimeCounter = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.currentGameState == GameController.GameState.playing)
        {
            //spawn asteroids
            spawnTimeCounter += Time.deltaTime;
            if (spawnTimeCounter >= spawnTime)
            {
                SpawnAsteroid();
                spawnTimeCounter = 0;
            }
        }
    }

    void SpawnAsteroid()
    {
        //create random position for asteroid within the boundaries
        float posX = Random.Range(transform.position.x - (spawnBoundaries.x / 2), transform.position.x + (spawnBoundaries.x / 2));
        float posY = Random.Range(transform.position.y - (spawnBoundaries.y / 2), transform.position.y + (spawnBoundaries.y / 2));
        float posZ = Random.Range(transform.position.z - (spawnBoundaries.z / 2), transform.position.z + (spawnBoundaries.z / 2));

        //create position vector
        Vector3 position = new Vector3(posX, posY, posZ);

        //spawn it
        Instantiate(asteroid, position, Quaternion.identity, this.transform);
    }
}
