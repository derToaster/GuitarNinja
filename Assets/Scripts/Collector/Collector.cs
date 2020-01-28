using UnityEngine;

public class Collector : MonoBehaviour {
    private ObjectSpawner objectSpawner;

    // Start is called before the first frame update
    void Start() {
        objectSpawner = FindObjectOfType<ObjectSpawner>();
    }

    private void OnTriggerEnter(Collider target) {   // Collector deactivates the gameobjects and initiates the objectSpawner
        if (target.CompareTag(Tags.EMPTY_PLATFORM) ||
            target.CompareTag(Tags.NOTE_PLATFORM) ||
            target.CompareTag(Tags.COL_PLAT_MID) ||
            target.CompareTag(Tags.COL_PLAT_RIGHT) ||
            target.CompareTag(Tags.COL_PLAT_LEFT) ||
            target.CompareTag(Tags.B_PLATFORM) ||
            target.CompareTag(Tags.SHARP_PLATFORM) ||
            target.CompareTag(Tags.PICK)) {
            target.gameObject.SetActive(false);
            objectSpawner.RecycleObjects();
        }
    }
}