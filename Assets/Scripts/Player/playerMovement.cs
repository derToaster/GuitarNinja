﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {


    private Vector3 moveVector;

    [SerializeField] private float speed = 5;
    private float verticalVelocity;

    private Rigidbody body;    private float camAnimationDuration;    private Animator anim;    public float knockbackForce, knockbackTime;    private float knockbackCounter;        // Start is called before the first frame update    void Start() {
        body = GetComponent<Rigidbody>();        camAnimationDuration = GameObject.Find("Main Camera").GetComponent<cameraMovement>().animationDuration;        anim = GetComponent<Animator>();        anim.SetFloat(Tags.ANIMATION_CONDITION_FLOAT_SPEED, speed / 10);    }

    // Update is called once per frame
    void Update() {        if (Time.time < camAnimationDuration) {            body.velocity = Vector3.forward * speed;            return;        }        if (knockbackCounter <= 0) {            verticalVelocity = -0.5f;            moveVector = Vector3.zero;            // X - Moving left or right            moveVector.x = Input.GetAxisRaw("Horizontal") * speed;            //Y - Up and Down            moveVector.y = verticalVelocity;            // Z- Forwart or Backward            moveVector.z = speed;            body.velocity = moveVector;        } else {            knockbackCounter -= Time.deltaTime;        }            }    public void IncreaseSpeed(int increment) {        speed += increment;        anim.SetFloat(Tags.ANIMATION_CONDITION_FLOAT_SPEED, speed / 10);    }    public void Knockback(Vector3 direction) {        knockbackCounter = knockbackTime;         body.velocity = direction * knockbackForce;    }    public void Death() {        speed = 0;    }    private void OnTriggerEnter(Collider target) {        if (target.CompareTag(Tags.HITBOX)) {            Vector3 hitDirection = target.transform.position - transform.position;            hitDirection = hitDirection.normalized;            Knockback(hitDirection);            FindObjectOfType<HealthManager>().StartCoroutine(Tags.GETTING_HURT_ROUTINE, hitDirection);        }    }}