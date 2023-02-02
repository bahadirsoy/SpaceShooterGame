using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ReturnGuns : MonoBehaviour
{
    //initial pose
    private Pose pose;

    //xrgrabinteractable
    private XRGrabInteractable xrgrabinteractable;

    //pick up UI
    public Canvas pickUpUI;
    
    // Start is called before the first frame update
    void Start()
    {
        pose.position = transform.position;
        pose.rotation = transform.rotation;

        xrgrabinteractable = GetComponent<XRGrabInteractable>();

        //return guns to the initial pose
        xrgrabinteractable.selectExited.AddListener(ReturnGunToOriginalPose);

        //enable/disable pick up UI
        xrgrabinteractable.selectEntered.AddListener(DisablePickUpUI);
        xrgrabinteractable.selectExited.AddListener(EnablePickUpUI);
    }

    private void EnablePickUpUI(SelectExitEventArgs arg0)
    {
        pickUpUI.gameObject.SetActive(true);
    }

    private void DisablePickUpUI(SelectEnterEventArgs arg0)
    {
        pickUpUI.gameObject.SetActive(false);
    }

    private void ReturnGunToOriginalPose(SelectExitEventArgs arg0)
    {
        transform.position = pose.position;
        transform.rotation = pose.rotation;
    }
}
