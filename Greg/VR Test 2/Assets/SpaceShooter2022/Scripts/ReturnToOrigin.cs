using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ReturnToOrigin : MonoBehaviour
{
    [SerializeField] private Pose originPose;
    [SerializeField] private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        originPose.position = transform.position;
        originPose.rotation = transform.rotation;
    }
    /*
    private void OnEnable()
    {
        // You can connect to any event 
        grabInteractable.selectExited.AddListener(LaserGunReleased);
    }
    private void OnDisable()
    {
        grabInteractable.selectExited.RemoveListener(LaserGunReleased);
    }
    */

    public void LaserGunReleased(SelectExitEventArgs arg0)
    {
        transform.position = originPose.position;
        transform.rotation = originPose.rotation;
    }
}
