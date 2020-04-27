using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour {
    private AudioSource audio;
    private bool rightFoot, subDominant, isAlive;
    private Cooldown QTE;
    public float timeBetweenSteps = 0.3f;
    private playerMovement move;
    private IEnumerator backgroundMusic;





    public List<AudioClip> pentatonicClips,
        bassClips,
        harmonicsClips,
        highNoteClips,
        rightFootstepClips,
        leftFootstepClips,
        sdRightFootstepClips,
        sdLeftFootstepClips,
        wrongClips;

    public AudioClip deathSound;
    [Range(0f,1f)] public float footstepVolume;
    [Range(0f,1f)] public float pentatonicsVolume;
    [Range(0f,1f)] public float bassVolume;
    [Range(0f,1f)] public float harmonicsVolume;
    [Range(0f,1f)] public float wrongNoteVolume;
    [Range(0f,1f)] public float highNoteVolume;
    // Start is called before the first frame update
    void Start() {
        audio = GetComponent<AudioSource>();

        QTE = FindObjectOfType<Cooldown>();
        move = FindObjectOfType<playerMovement>();
        move.isAlive = true;
        backgroundMusic = PlayFootstepSounds();
        StartCoroutine(backgroundMusic);
    }

    // Update is called once per frame
    private void Update() {
        if (!move.isAlive) {
            StopCoroutine(backgroundMusic);
            
        }
    }

    public void PlayPentatonicNote() {
        audio.clip = pentatonicClips[Random.Range(0, pentatonicClips.Count)];

        audio.PlayOneShot(audio.clip, pentatonicsVolume);
    }

    public void PlayBassNote() {
        audio.clip = bassClips[Random.Range(0, bassClips.Count)];
        audio.PlayOneShot(audio.clip, bassVolume);
    }

    public void PlayHarmonicNote() {
        audio.clip = harmonicsClips[Random.Range(0, harmonicsClips.Count)];
        audio.PlayOneShot(audio.clip, harmonicsVolume);
    }

    public void PlayWrongNote() {
        audio.clip = wrongClips[Random.Range(0, wrongClips.Count)];
        audio.PlayOneShot(audio.clip, wrongNoteVolume);
    }

    public void PlayHighNote() {
        audio.clip = highNoteClips[Random.Range(0, highNoteClips.Count)];
        audio.PlayOneShot(audio.clip, highNoteVolume);
    }

    public void PlayDeathSound() {
        audio.clip = deathSound;
        audio.PlayOneShot(audio.clip);
    }
    
    public void RightFootstepSound() {
        audio.clip = rightFootstepClips[Random.Range(0, rightFootstepClips.Count)];
        audio.PlayOneShot(audio.clip, footstepVolume);
    }

    public void LeftFootstepSound() {
        audio.clip = leftFootstepClips[Random.Range(0, leftFootstepClips.Count)];
        audio.PlayOneShot(audio.clip, footstepVolume);
    }

    public void SdLeftFootstepSound() {
        audio.clip = sdLeftFootstepClips[Random.Range(0, sdLeftFootstepClips.Count)];
        audio.PlayOneShot(audio.clip, footstepVolume);
    }

    public void SdRightFootstepSound() {
        audio.clip = sdRightFootstepClips[Random.Range(0, sdRightFootstepClips.Count)];
        audio.PlayOneShot(audio.clip, footstepVolume);
    }
    private IEnumerator PlayFootstepSounds() { // continuously playing the footsteprhythm while player is alive
        while (true) {
            rightFoot = !rightFoot;
            if (QTE.counter == Random.Range(3, 15)) {
                subDominant = true;
                QTE.counter = 0;
            }

            if (subDominant) {
                if (rightFoot) {
                    SdRightFootstepSound();
                }
                else {
                    SdLeftFootstepSound();
                }
            }
            else {
                if (rightFoot) {
                    RightFootstepSound();
                }
                else {
                    LeftFootstepSound();
                }
            }

            yield return new WaitForSeconds(timeBetweenSteps);
        }
    }
}

   
