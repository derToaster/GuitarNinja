using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour {
    public float raycastDistance;

    public Animator sharpAnim, flatAnim;

    private Cooldown QTE;

    // Start is called before the first frame update
    void Start() {
        QTE = FindObjectOfType<Cooldown>();
    }

    // Update is called once per frame
    void Update() {
        RaycastHit hit;

        Debug.DrawRay(transform.position, Vector3.forward * raycastDistance,Color.green);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,
            raycastDistance)) {

                
            
        }
    }
}

