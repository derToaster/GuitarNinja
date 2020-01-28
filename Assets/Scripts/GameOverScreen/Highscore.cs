using TMPro;
using UnityEngine;

public class Highscore : MonoBehaviour {
    private int sessionScores, highScores;


    public TextMeshProUGUI  highscore, congratulations, newHighscore;

    private Transform gameOver;

    private GameObject highScorePanel;
    

    // Start is called before the first frame update
    void Start() {

        gameOver = GameObject.Find("GameOver").transform;
        sessionScores = PlayerPrefs.GetInt(Tags.SESSIONSCORES);
        
        if (!PlayerPrefs.HasKey(Tags.HIGHSCORES)) {// if Highscore does not exist
            PlayerPrefs.SetInt(Tags.HIGHSCORES, 0);
        }
        else {
            highScores = PlayerPrefs.GetInt(Tags.HIGHSCORES);




        }





        if (sessionScores > highScores) {
            PlayerPrefs.SetInt(Tags.HIGHSCORES, sessionScores);
            gameOver.position = new Vector3(gameOver.position.x, gameOver.position.y - 90, gameOver.position.z);
            congratulations.enabled = true;
            newHighscore.enabled = true;
        }
        else {
            PlayerPrefs.DeleteKey(Tags.SESSIONSCORES);
            gameOver.position = new Vector3(gameOver.position.x, gameOver.position.y , gameOver.position.z);
            congratulations.enabled = false;
            newHighscore.enabled = false;

        }


        highscore.SetText("Highscore: " + PlayerPrefs.GetInt(Tags.HIGHSCORES) + " pts");
    }
}