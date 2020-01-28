using UnityEngine;

public class FlatScript : MonoBehaviour {
    private Animator flatAnim;



    private Cooldown QTE;




    // Start is called before the first frame update
    void Start() {
        QTE = FindObjectOfType<Cooldown>();
        flatAnim = GetComponent<Animator>();
    }
    
    
    private void OnTriggerEnter(Collider target) {
        if (target.CompareTag(Tags.PLAYER)) {
            StartCoroutine(QTE.TimerDown(0.08f, 0.02f, flatAnim, Tags.ANIMATION_CONDITION_BOOL_FLAT_ROTATION));

            
        }
    }

    private void OnTriggerExit(Collider target) {
        if (target.CompareTag(Tags.PLAYER)) {
            gameObject.SetActive(false);
        }
    }
}