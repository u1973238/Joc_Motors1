using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetingsMenu : MonoBehaviour
{
    public AudioMixer mixer;
    public void SetVolume (float volume)
    {
        float res = (volume / 100) * 80 - 80;
        mixer.SetFloat("Volume", res);
    }
}
