﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour {
    public AudioMixer audioMixer;
    // Start is called before the first frame update

    public void Volume(float volume) {
        audioMixer.SetFloat("volume", volume);

    }
}
