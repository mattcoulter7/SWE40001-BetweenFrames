using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    private bool startedPlaying = false;

    public void Play(string name)
    {

        AM.Instance.PlaySFX(name);
    }

    public void PlayLooped(string name)
    {
        if (!startedPlaying)
        {
            AM.Instance.PlaySFX(name);
            startedPlaying = true;
        }
        else
        {
            return;
        }
       
    }

    public void StopLooped(string name)
    {
        startedPlaying = false;
        AM.Instance.StopSFX(name);

    }

}