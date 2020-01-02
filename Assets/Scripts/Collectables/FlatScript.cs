using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatScript : MonoBehaviour
{

    private Animator flatAnim, playerAnim;
    public bool canPressFlat;
    public int flatPoints;
    private PointSystem points;

    public KeyCode slideKey;
    


    // Start is called before the first frame update
    void Start()
    {
        flatAnim = GetComponent<Animator>();
        playerAnim = GameObject.FindGameObjectWithTag(Tags.PLAYER).GetComponent<Animator>();
        points = FindObjectOfType<PointSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(slideKey)) {

            if (canPressFlat) {
                Debug.Log("Flat Hit");
                playerAnim.SetBool(Tags.ANIMATION_CONDITION_BOOL_SLIDE, true);
                points.addPoints(flatPoints);


            }

        }


        
    }



    private void OnTriggerEnter(Collider target) {        if (target.CompareTag(Tags.PLAYER)) {            canPressFlat = true;            flatAnim.SetBool(Tags.ANIMATION_CONDITION_BOOL_FLAT_ROTATION, true);        }            }
    private void OnTriggerExit(Collider target) {        if (target.CompareTag(Tags.PLAYER)) {            canPressFlat = false;                        playerAnim.SetBool(Tags.ANIMATION_CONDITION_BOOL_SLIDE, false);
            flatAnim.SetBool(Tags.ANIMATION_CONDITION_BOOL_FLAT_ROTATION, false);        }    }
       

}
