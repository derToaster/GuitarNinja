using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionEffect : MonoBehaviour {
    private ParticleSystem sparkle;

    // Start is called before the first frame update
    void Start() {
        sparkle = GetComponent<ParticleSystem>();
    }


    public void LetItSparkle(Vector3 position, int emissions) {
        transform.position = position;
        sparkle.Emit(emissions);
    }
}