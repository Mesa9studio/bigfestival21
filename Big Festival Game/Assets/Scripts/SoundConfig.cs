using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundConfig : MonoBehaviour
{
    AudioSource _audio;
    [SerializeField] float maxSound;
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
        _audio.volume = value ? maxSound : 0;
    }
}
