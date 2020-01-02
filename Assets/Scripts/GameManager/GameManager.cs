
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float delay;


    public void GameOver() {

        if (gameHasEnded == false) {

            gameHasEnded = true;
            Debug.Log("Game Over");
            Invoke("Restart", delay);

        }

    }

    void Restart() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}

