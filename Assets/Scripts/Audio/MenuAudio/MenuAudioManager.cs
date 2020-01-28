using System.Collections.Generic;
using UnityEngine;

public class MenuAudioManager : MonoBehaviour {
    public List<AudioClip> buttonSounds;

    private AudioSource audio;
    // Start is called before the first frame update
    void Start() {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame


    public void PlayMenuButtonSounds() { 

        audio.clip = buttonSounds[Random.Range(0, buttonSounds.Count)];
        audio.PlayOneShot(audio.clip);


    }
}
