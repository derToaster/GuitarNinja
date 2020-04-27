using UnityEngine;

public class NoteScript : MonoBehaviour {

    private GameObject player;
    private Cooldown QTE;


    // Start is called before the first frame update
    void Start() {


        player = GameObject.FindGameObjectWithTag(Tags.PLAYER); 

        QTE = FindObjectOfType<Cooldown>();
    }

    // Update is called once per frame

    private void Update() {
        this.transform.position = new Vector3(player.transform.position.x, this.transform.position.y, this.transform.position.z);
    }

    private void OnTriggerEnter(Collider target) {
        if (target.CompareTag(Tags.PLAYER)) {
            StartCoroutine(QTE.TimerKick(0.08f, 0.02f,transform.position,gameObject));
            
        }
        
    }
}