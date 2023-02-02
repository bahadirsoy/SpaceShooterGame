using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{
    //speed of asteroid
    private float speed;

    //move vector
    private Vector3 moveVector;

    //player instance
    private GameObject player;

    //rotate vector
    private Vector3 rotateVector;

    //rigidbody
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        //get player
        player = GameObject.FindWithTag("Player");

        //init speed
        speed = 5f;

        //create random rotateVector
        float rotateX = Random.Range(0, 80);
        float rotateY = Random.Range(0, 80);
        float rotateZ = Random.Range(0, 80);
        rotateVector = new Vector3(rotateX, rotateY, rotateZ);

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //calculate moveVector
        moveVector = (player.transform.position - transform.position).normalized;

        //move and rotate
        rb.velocity = moveVector * speed;
        transform.Rotate(rotateVector * Time.deltaTime);
    }
}
