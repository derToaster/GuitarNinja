using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{    private bool canPressFlat, canPressSharp, canPressNote;    public KeyCode keyForFlat, keyForSharp, keyForNote;
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
    void Update() {        #region/////////////////////////////Interaction with Hurdles////////////////////////////////        if (Input.GetKeyDown(keyForFlat)) {            if (canPressFlat) {                /// Action for hitting flat                Debug.Log("Flat: Hit");                mainCharAnim.SetBool(Tags.ANIMATION_CONDITION_BOOL_SLIDE, true);                points.addPoints(flatPoints);            }        } else if (Input.GetKeyDown(keyForNote)) {            if (canPressNote) { // Action for hitting Note                Debug.Log("Note: Hit");                mainCharAnim.SetBool(Tags.ANIMATION_CONDITION_BOOL_KICK, true);                points.addPoints(notePoints);            }                } else if (Input.GetKeyDown(keyForSharp)) {            if (canPressSharp) {                     Debug.Log("Sharp: Hit");                    mainCharAnim.SetBool(Tags.ANIMATION_CONDITION_BOOL_JUMP, true);                    points.addPoints(sharpPoints);            }                #endregion
                    }    }     void OnTriggerEnter(Collider target) {        if (target.CompareTag(Tags.FLAT)) {            canPressFlat = true;            flatAnim.SetBool(Tags.ANIMATION_CONDITION_BOOL_FLAT_ROTATION, true);        } else if (target.CompareTag(Tags.NOTE)) {            canPressNote = true;        } else if (target.CompareTag(Tags.SHARP))            { canPressSharp = true; }    }     void OnTriggerExit(Collider target) {        if (target.CompareTag(Tags.FLAT)) {            canPressFlat = false;            mainCharAnim.SetBool(Tags.ANIMATION_CONDITION_BOOL_SLIDE, false);        } else if (target.CompareTag(Tags.NOTE)) {            canPressNote = false;            mainCharAnim.SetBool(Tags.ANIMATION_CONDITION_BOOL_KICK, false);        } else if (target.CompareTag(Tags.SHARP)) {            canPressSharp = false;            mainCharAnim.SetBool(Tags.ANIMATION_CONDITION_BOOL_JUMP, false);        }    }
}
