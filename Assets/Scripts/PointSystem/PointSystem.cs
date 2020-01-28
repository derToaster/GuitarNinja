using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour {
    public Text text;
    private int finalScore;
    public int scoreToNextLevel, maxDifficultyLevel, speedIncrease;
    private int difficultyLevel = 1;
    private playerMovement movement;



    // Start is called before the first frame update

    private void Start() {
        movement = FindObjectOfType<playerMovement>();

    }

    private void Update() {
        if (finalScore >= scoreToNextLevel) { // after a certain amount of points is reached the speedlevel is increased
            LevelUp();
        }
        
        
        PlayerPrefs.SetInt(Tags.SESSIONSCORES,finalScore); // Score is saved Locally 
    }

    public void addPoints(int points) {
        finalScore += points;

        text.text = "Score: " + finalScore;
    }


    public void LevelUp() {
        if (difficultyLevel == maxDifficultyLevel) {
            return;
        }

        FindObjectOfType<AudioManager>().timeBetweenSteps -= 0.05f; // also speeds up the footstepsounds
        scoreToNextLevel *= 2;
        difficultyLevel++;
        movement.IncreaseSpeed(speedIncrease);
    }
}