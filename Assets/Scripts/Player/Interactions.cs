﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    private Animator mainCharAnim, flatAnim, sharpAnim, noteAnim;
    private PointSystem points;
    public int flatPoints, notePoints, sharpPoints;
    // Start is called before the first frame update
    void Start() {
        mainCharAnim = GetComponent<Animator>();
        points = FindObjectOfType<PointSystem>();
        canPressFlat = FindObjectOfType<FlatScript>().canPressFlat;
            }

    // Update is called once per frame
    void Update() {

}