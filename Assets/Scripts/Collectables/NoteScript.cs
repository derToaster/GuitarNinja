using UnityEngine;

public class NoteScript : MonoBehaviour {
    private Animator noteAnim, playerAnim;
    public bool canPressNote;
    public int notePoints;
    private PointSystem points;
    private GameObject player;
    public KeyCode kickKey;
    private Cooldown QTE;


    // Start is called before the first frame update
    void Start() {
        noteAnim = GetComponent<Animator>();
        playerAnim = GameObject.FindGameObjectWithTag(Tags.PLAYER).GetComponent<Animator>();
        points = FindObjectOfType<PointSystem>();
        player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
        QTE = FindObjectOfType<Cooldown>();
    }

    // Update is called once per frame
    void Update() {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        
        

    }


    private void OnTriggerEnter(Collider target) {
        if (target.CompareTag(Tags.PLAYER)) {
            StartCoroutine(QTE.TimerKick(0.08f, 0.02f,noteAnim,Tags.ANIMATION_CONDITION_BOOL_NOTE_ROTATION));
            
        }
        
    }

    private void OnTriggerExit(Collider target) {
        if (target.CompareTag(Tags.PLAYER)) {
            


        }

        if (target.CompareTag(Tags.NOTE_CATCHER)) {
            playerAnim.SetBool(Tags.ANIMATION_CONDITION_BOOL_NOTE_ROTATION, false);
            gameObject.SetActive(false);
        }
    }

  
}