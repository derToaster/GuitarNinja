using UnityEngine;

public class GameManager : MonoBehaviour {
    bool gameHasEnded = false;
    public float delay;
    private Transition transition;

    private void Start() {
        transition = GameObject.FindWithTag(Tags.TRANSITION).GetComponent<Transition>();
    }


    public void GameOver() {
        if (gameHasEnded == false) {
            gameHasEnded = true;
          
        }
        transition.FadeToLevel(0);
    }

    public void Restart() {
        transition.FadeToLevel(1);
    }
   
    
   
}