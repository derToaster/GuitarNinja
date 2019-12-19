using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour {

    private void OnTriggerEnter(Collider target) {        if (target.CompareTag(Tags.PLYER)) {            gameObject.SetActive(false);        }    }}
