﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{

    private Transform playerTransform;
    private Vector3 camMoveVector;

    private float transition = 0.0f;
    public float animationDuration = 2.0f;
    private Vector3 animationCamOffset = new Vector3(0f, 9f, 9f);


    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        startOffset = transform.position - playerTransform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}