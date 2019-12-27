using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {


    private Vector3 moveVector;

    [SerializeField] private float speed = 5;
    private float verticalVelocity;

    private Rigidbody body;    private float camAnimationDuration;    private Animator anim;    // Start is called before the first frame update    void Start() {
        body = GetComponent<Rigidbody>();        camAnimationDuration = GameObject.Find("Main Camera").GetComponent<cameraMovement>().animationDuration;        anim = GetComponent<Animator>();        anim.SetFloat(Tags.ANIMATION_CONDITION_FLOAT_SPEED, speed / 10);    }

    // Update is called once per frame
    void Update() {        if (Time.time < camAnimationDuration) {            body.velocity = Vector3.forward * speed;            return;        }        verticalVelocity = -0.5f;        moveVector = Vector3.zero;        // X - Moving left or right                moveVector.x = Input.GetAxisRaw("Horizontal") * speed;        //Y - Up and Down        moveVector.y = verticalVelocity;        // Z- Forwart or Backward        moveVector.z = speed;        body.velocity = moveVector;            }    public void IncreaseSpeed(int increment) {        speed += increment;        anim.SetFloat(Tags.ANIMATION_CONDITION_FLOAT_SPEED, speed / 10);    }}