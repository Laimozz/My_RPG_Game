using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] AudioSource footStep;
    [SerializeField] AudioSource attackSource;

    public void PlayFootStep() 
    { 
        if(!footStep.isPlaying) 
        { 
            footStep.Play();
        }
    }
    public void StopFootStep()
    {
        if(footStep.isPlaying)
        {
            footStep.Stop();
        }
    }

    public void PlayAttackSound()
    {
        attackSource.Play();
    }
}
