using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    private AudioSource audio;

    public List<AudioClip> pentatonicClips, bassClips, harmonicsClips,highNoteClips, rightFootstepClips, leftFootstepClips,sdRightFootstepClips,sdLeftFootstepClips, wrongClips;

    public AudioClip deathSound;
    // Start is called before the first frame update
    void Start() {
        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame

    public void PlayPentatonicNote() {

        audio.clip = pentatonicClips[Random.Range(0, pentatonicClips.Count)];
        audio.PlayOneShot(audio.clip);


    }


    public void RightFootstepSound() {
        
        audio.clip = rightFootstepClips[Random.Range(0, rightFootstepClips.Count)];
        audio.PlayOneShot(audio.clip);
        
    }
    public void LeftFootstepSound() {
        
        audio.clip = leftFootstepClips[Random.Range(0, leftFootstepClips.Count)];
        audio.PlayOneShot(audio.clip);
        
    }

    public void PlayBassNote() {
        
        audio.clip = bassClips[Random.Range(0, bassClips.Count)];
        audio.PlayOneShot(audio.clip);
    }
    public void PlayHarmonicNote() {
        
        audio.clip = harmonicsClips[Random.Range(0, harmonicsClips.Count)];
        audio.PlayOneShot(audio.clip);
    }

    public void PlayWrongNote() {
        audio.clip = wrongClips[Random.Range(0, wrongClips.Count)];
        audio.PlayOneShot(audio.clip);
    }
    public void PlayHighNote() {
        audio.clip = highNoteClips[Random.Range(0, highNoteClips.Count)];
        audio.PlayOneShot(audio.clip);
    }

    public void PlayDeathSound() {

        audio.clip = deathSound;
        audio.PlayOneShot(audio.clip);
    }
    public void SdLeftFootstepSound() {
        
        audio.clip = sdLeftFootstepClips[Random.Range(0, sdLeftFootstepClips.Count)];
        audio.PlayOneShot(audio.clip);
        
    }
    public void SdRightFootstepSound() {
        
        audio.clip = sdRightFootstepClips[Random.Range(0, sdRightFootstepClips.Count)];
        audio.PlayOneShot(audio.clip);
        
    }

}
