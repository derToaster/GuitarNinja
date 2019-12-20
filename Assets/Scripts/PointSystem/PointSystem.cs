using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    public Text text;    private int finalScore;    public int scoreToNextLevel, maxDifficultyLevel, speedIncrease;    private int difficultyLevel = 1;    private playerMovement movement;    // Start is called before the first frame update    private void Start() {        movement = FindObjectOfType<playerMovement>();                              }    private void Update() {        if (finalScore >= scoreToNextLevel) {            LevelUp();        }                              }    public void addPoints(int points) {
        finalScore += points;

        text.text = "Score: " + finalScore;

    }


    public void LevelUp() {


        if (difficultyLevel == maxDifficultyLevel) {
            return;
        }
        scoreToNextLevel *= 2;
        difficultyLevel++;
        movement.IncreaseSpeed(speedIncrease);

    }



}
