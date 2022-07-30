using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance { get; private set; }
    [SerializeField] private bool _soundActive;
    [SerializeField] private bool _pauseActive;
    public bool SoundActive { get { return _soundActive; } private set { } }
    public bool PauseActive { get { return _pauseActive; } private set { } }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            _soundActive = true;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(this.gameObject);
    }

    private void Start()
    {
        ManagerEvents.SoundConfig.onSound += SetSound;
        ManagerEvents.GamePlay.onPause += SetPause;
    }

    private void OnDestroy()
    {
        ManagerEvents.SoundConfig.onSound -= SetSound;
        ManagerEvents.GamePlay.onPause -= SetPause;

    }
    private void SetSound(bool value)
    {
        _soundActive = value;
    }

    private void SetPause(bool value)
    {
        _pauseActive = value;
    }
}
