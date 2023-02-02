using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    //fire gun animator
    public Animator laserGunFireAnimator;

    //raycast
    public GameObject raycastOrigin;
    private float raycastDistance;
    private RaycastHit hit;
    public LineRenderer lineRenderer;

    //asteroid explosion particle
    public GameObject asteroidExplosion;

    //game controller
    public GameController gameController;

    //menu
    public Canvas menu;

    public void LaserGunFired()
    {
        //animate fire
        laserGunFireAnimator.SetTrigger("Fire");

        //check raycast
        if (Physics.Raycast(raycastOrigin.transform.position, transform.forward, out hit, raycastDistance))
        {
            //if we hit asteroid create particle and destroy asteroid
            if (hit.collider.tag == "Asteroid")
            {
                //asteroid explosion
                Destroy(Instantiate(asteroidExplosion, hit.transform.position, hit.transform.rotation), 2f);

                //increase score and show popup
                gameController.increaseScore();
                gameController.showPopup(hit.transform.position);

                //destroy asteroid
                Destroy(hit.transform.gameObject);
            } else if(hit.collider.tag == "Start")
            {
                GameController.currentGameState = GameController.GameState.playing;
                menu.gameObject.SetActive(false);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        raycastDistance = 200f;
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, raycastOrigin.transform.position);
        lineRenderer.SetPosition(1, raycastOrigin.transform.forward * raycastDistance);
    }
}
