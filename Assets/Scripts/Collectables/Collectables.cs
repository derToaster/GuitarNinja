using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour {
    private PointSystem _pointSystem;
    public int pointValue;
    private Animator anim;
    private CollectionEffect sparkle;
    public int emissions;


    private void OnEnable() {
        _pointSystem = FindObjectOfType<PointSystem>();
        anim = GetComponent<Animator>();
        sparkle = FindObjectOfType<CollectionEffect>();
    }

    private void OnTriggerEnter(Collider target) {
        if (target.CompareTag(Tags.PLAYER)) {
            _pointSystem.addPoints(pointValue);
            gameObject.SetActive(false);
            sparkle.LetItSparkle(transform.position, emissions);
        }
    }

    private void OnDisable() {
    }
}