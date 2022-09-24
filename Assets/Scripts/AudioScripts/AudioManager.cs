using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Avoids setup errors by requiring an audio source
[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioClip introMusic;
    public AudioClip levelMusic;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        StartCoroutine(playGameSound(audio));
    }

    IEnumerator playGameSound(AudioSource audio){
        audio.clip = introMusic;
        float waitTime = audio.clip.length - (float)0.5;
        audio.Play();
        yield return new WaitForSeconds(waitTime);
        audio.clip = levelMusic;
        audio.loop = true;
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
