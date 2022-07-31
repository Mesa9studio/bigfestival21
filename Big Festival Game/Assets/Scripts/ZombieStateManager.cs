using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ZombieStateManager : MonoBehaviour
{
    public AudioSource audio;
    ZombieBaseState _currentState;
    public ZombieBaseState auxState;
    public ZombieWorkState _workState = new ZombieWorkState();
    public ZombieWalkState _walkState = new ZombieWalkState();
    public ZombieAttackState _attackState = new ZombieAttackState();
    public ZombieDieState _dieState = new ZombieDieState();
    public ZombiePauseState _pauseState = new ZombiePauseState();
    [SerializeField]bool _zombieDie;
    public bool ZombieDie { get { return _zombieDie; } set { _zombieDie = value; } }
    [SerializeField] string _currentStateName;
    [SerializeField] protected string _auxStateName;
    [SerializeField] Transform _defaultPositionSpawn;
    [SerializeField] public Animator zombieAnimator;
    public GameObject AttackPoint;

    public Transform DefaultPositionSpawn { get { return _defaultPositionSpawn; } set { _defaultPositionSpawn = value; } }

    [SerializeField] Transform _defaultPositionLook;
    public Transform DefaultPositionLook { get { return _defaultPositionLook; } set { _defaultPositionLook = value; }}

    public GameObject bruxinha;

    public NavMeshAgent _agent;
    // Start is called before the first frame update
    void Start()
    {
        SwitchState(_workState);
        bruxinha = GameObject.FindGameObjectWithTag("Player");
        ManagerEvents.GamePlay.onPause += PauseZombie;
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateState(this);
    }


    public void SwitchState(ZombieBaseState state)
    {
        _currentState = state;
        _currentState.EnterState(this);
        _currentStateName = _currentState.GetCurrentState(this);

    }

    public void ZombieReceiveDamage()
    {
        Debug.Log("Current state:" + _currentStateName);
        auxState = _currentState;
        _auxStateName = auxState.GetCurrentState(this);
        SwitchState(_dieState);
    }


    public void PauseZombie(bool value)
    {
        if (value)
        {
            auxState = _currentState;
            zombieAnimator.speed = 0;
            SwitchState(_pauseState);
        }
        else
        {
            zombieAnimator.speed = 1;
            SwitchState(auxState);
            auxState = null;
        }
    }


    public void PlayAudio(AudioClip audioClip)
    {
        audio.clip = audioClip;
        audio.Play();
    }
}
