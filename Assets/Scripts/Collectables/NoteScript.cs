using UnityEngine;

public class NoteScript : MonoBehaviour {
    private Animator noteAnim, playerAnim;
    public bool canPressNote;
    public int notePoints;
    private PointSystem points;

    public KeyCode kickKey;


    // Start is called before the first frame update
    void Start() {
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
                noteAnim.SetBool(Tags.ANIMATION_CONDITION_BOOL_NOTE_ROTATION, true);
                points.addPoints(notePoints);
            }
        }
    }


    private void OnTriggerEnter(Collider target) {
        if (target.CompareTag(Tags.PLAYER)) {
            canPressNote = true;
        }
    }

    private void OnTriggerExit(Collider target) {
        if (target.CompareTag(Tags.PLAYER)) {
            canPressNote = false;

            playerAnim.SetBool(Tags.ANIMATION_CONDITION_BOOL_KICK, false);
        }

        if (target.CompareTag(Tags.NOTE_CATCHER)) {
            playerAnim.SetBool(Tags.ANIMATION_CONDITION_BOOL_NOTE_ROTATION, false);
            gameObject.SetActive(false);
        }
    }
}