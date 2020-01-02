using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCatcher : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    private void OnTriggerEnter(Collider target) {
        if (target.CompareTag(Tags.NOTE)) {
            target.gameObject.SetActive(false);
        }
    }
}