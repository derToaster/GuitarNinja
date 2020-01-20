using UnityEngine;

public class MoveWithPlayer : MonoBehaviour {
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        
        
    }
}
