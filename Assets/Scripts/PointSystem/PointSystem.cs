﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    public Text text;
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