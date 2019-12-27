﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    public bool canPressNote;
    public int notePoints;
    private PointSystem points;

    public KeyCode kickKey;
        noteAnim = GetComponent<Animator>();
        playerAnim = GameObject.FindGameObjectWithTag(Tags.PLAYER).GetComponent<Animator>();
        points = FindObjectOfType<PointSystem>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(kickKey)) {

            if (canPressNote) {
                Debug.Log("Note Hit");
                playerAnim.SetBool(Tags.ANIMATION_CONDITION_BOOL_KICK, true);
                points.addPoints(notePoints);


            }

        }



    private void OnTriggerEnter(Collider target) {
    private void OnTriggerExit(Collider target) {

    private void OnDisable() {

}