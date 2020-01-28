using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpScript : MonoBehaviour {
    private Animator sharpAnim;


    private Cooldown QTE;


    // Start is called before the first frame update
    void Start() {
        sharpAnim = GetComponent<Animator>();
        QTE = FindObjectOfType<Cooldown>();
    }


    private void OnTriggerEnter(Collider target) {
        if (target.CompareTag(Tags.PLAYER)) {
            StartCoroutine(QTE.TimerUp(0.06f, 0.02f, sharpAnim, Tags.ANIMATION_CONDITION_BOOL_SHARP_ROTATION));
        }
    }

    private void OnTriggerExit(Collider target) {
        if (target.CompareTag(Tags.PLAYER)) {
            gameObject.SetActive(false);
            sharpAnim.SetBool(Tags.ANIMATION_CONDITION_BOOL_SHARP_ROTATION, false);
        }
    }
}