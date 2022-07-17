using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance { get; private set; }
    [SerializeField] private bool _soundActive;
    public bool SoundActive { get { return _soundActive; } private set { } }
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
    }

    private void OnDestroy()
    {
        ManagerEvents.SoundConfig.onSound -= SetSound;

    }
    private void SetSound(bool value)
    {
        _soundActive = value;
    }
}
