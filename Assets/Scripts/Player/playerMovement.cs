using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    private Vector3 moveVector;
    private CharacterController controller;
    [SerializeField] private float speed = 5.0f;
    private float verticalVelocity;
    private float gravity = 12.0f;

    private float camAnimationDuration;    // Start is called before the first frame update    void Start() {
        controller = GetComponent<CharacterController>();

        camAnimationDuration = GameObject.Find("Main Camera").GetComponent<cameraMovement>().animationDuration;

    }

    // Update is called once per frame
    void Update() {

        if (Time.time < camAnimationDuration) {            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }
        if (controller.isGrounded) {            verticalVelocity = -0.5f;        } else {            verticalVelocity -= gravity * Time.deltaTime;        }

        moveVector = Vector3.zero;        // X - Left or Right        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;        // Y - Up or Down        moveVector.y = verticalVelocity;        // Z - Forward or Backward        moveVector.z = speed;        controller.Move(moveVector * Time.deltaTime);    }                  
}
   