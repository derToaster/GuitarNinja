using UnityEngine;

public class cameraMovement : MonoBehaviour {
    private Transform playerTransform;

    private Vector3 startOffset;
    private Vector3 camMoveVector;

    private float transition;
    public float animationDuration = 2.0f;
    private Vector3 animationCamOffset = new Vector3(0f, 9f, 9f);


    // Start is called before the first frame update
    void Start() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        startOffset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    private void Update() {
        camMoveVector = playerTransform.position + startOffset;

        // X

        camMoveVector.x = 0;

        // Y

        camMoveVector.y = Mathf.Clamp(camMoveVector.y, 3, 5);
        // Camera will only be able to follow the player on the Y axis between 3 and 5

        if (transition > 1.0f) {
            transform.position = camMoveVector;
        }
        else {
            //Animation at the Start of the game

            transform.position = Vector3.Lerp(camMoveVector + animationCamOffset, camMoveVector, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(playerTransform.position + Vector3.up);
        }
    }
}