using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpScript : MonoBehaviour
{

    private Animator sharpAnim, playerAnim;
    public bool canPressSharp;
    public int sharpPoints;
    private PointSystem points;

    public KeyCode jumpKey;
    


    // Start is called before the first frame update
    void Start()
    {
        sharpAnim = GetComponent<Animator>();
        playerAnim = GameObject.FindGameObjectWithTag(Tags.PLAYER).GetComponent<Animator>();
        points = FindObjectOfType<PointSystem>();    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(jumpKey)) {

            if (canPressSharp) {
                Debug.Log("Sharp Hit");
                playerAnim.SetBool(Tags.ANIMATION_CONDITION_BOOL_JUMP, true);
                points.addPoints(sharpPoints);


            }

        }


        
    }



    private void OnTriggerEnter(Collider target) {        if (target.CompareTag(Tags.PLAYER)) {            canPressSharp = true;            sharpAnim.SetBool(Tags.ANIMATION_CONDITION_BOOL_SHARP_ROTATION, true);                   }            }
    private void OnTriggerExit(Collider target) {        if (target.CompareTag(Tags.PLAYER)) {            canPressSharp = false;            playerAnim.SetBool(Tags.ANIMATION_CONDITION_BOOL_JUMP, false);
            sharpAnim.SetBool(Tags.ANIMATION_CONDITION_BOOL_SHARP_ROTATION, false);        }    }
    

}
