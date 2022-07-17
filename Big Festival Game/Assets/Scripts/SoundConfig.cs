using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundConfig : MonoBehaviour
{
    AudioSource _audio;
    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        ConfigAudioVolume(GameManager._instance.SoundActive);
        ManagerEvents.SoundConfig.onSound += ConfigAudioVolume;

    }

    private void OnDestroy()
    {
        ManagerEvents.SoundConfig.onSound -= ConfigAudioVolume;

    }

    private void ConfigAudioVolume(bool value)
    {
        _audio.volume = value ? 100 : 0;
    }
}
