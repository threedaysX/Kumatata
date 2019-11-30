using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour
{
    public AudioSource beatSound;
    void Start()
    {
        //AudioProcessor processor = FindObjectOfType<AudioProcessor>();
        //processor.onBeat.AddListener(BeatSound);   
    }

    void Update()
    {
        //if (beatSound.isPlaying)
        //{
        //    if (beatSound.time > 0.8f)
        //    {
        //        beatSound.Stop();
        //    }
        //}
    }

    public void BeatSound()
    {
        beatSound.Play();
        print("BBBBBBBBBBB");
    }
}
