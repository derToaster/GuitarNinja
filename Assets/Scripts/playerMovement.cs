﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    private Vector3 moveVector;
    private CharacterController controller;
    [SerializeField]private float speed = 5.0f;
    private float verticalVelocity;
    private float gravity = 12.0f;

    private float camAnimationDuration;
    
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        camAnimationDuration = GameObject.Find("Main Camera").GetComponent<cameraMovement>().animationDuration;

    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time < camAnimationDuration) {
            return;
        }
        if (controller.isGrounded) {

        moveVector = Vector3.zero;
    
   

}