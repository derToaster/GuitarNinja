using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{

    public float raycastDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position, Vector3.forward * raycastDistance);

        if (Physics.Raycast(transform.position,transform.TransformDirection( Vector3.forward), out hit, raycastDistance)) {            Debug.Log("i see a " + hit.collider.tag);



        }

    }
}
