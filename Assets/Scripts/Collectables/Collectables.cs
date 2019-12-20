using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour {
    private PointSystem _pointSystem;    public int pointValue;



    private void OnEnable() {        _pointSystem = FindObjectOfType<PointSystem>();                              }

    private void OnTriggerEnter(Collider target) {           if (target.CompareTag(Tags.PLYER)) {            _pointSystem.addPoints(pointValue);            gameObject.SetActive(false);        }    }}
