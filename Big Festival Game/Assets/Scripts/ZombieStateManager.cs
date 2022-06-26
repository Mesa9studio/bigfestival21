using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ZombieStateManager : MonoBehaviour
{
    ZombieBaseState _currentState;
    public ZombieBaseState auxState;
    public ZombieWorkState _workState = new ZombieWorkState();
    public ZombieWalkState _walkState = new ZombieWalkState();
    public ZombieAttackState _attackState = new ZombieAttackState();
    public ZombieDieState _dieState = new ZombieDieState();
    [SerializeField]bool _zombieDie;
    public bool ZombieDie { get { return _zombieDie; } set { _zombieDie = value; } }
    [SerializeField] string _currentStateName;
    [SerializeField] string _auxStateName;
    [SerializeField] Transform _defaultPositionSpawn;
    public Transform DefaultPositionSpawn { get { return _defaultPositionSpawn; } set { _defaultPositionSpawn = value; } }

    [SerializeField] Transform _defaultPositionLook;
    public Transform DefaultPositionLook { get { return _defaultPositionLook; } set { _defaultPositionLook = value; }}

    [HideInInspector]public GameObject bruxinha;

    public NavMeshAgent _agent;
    // Start is called before the first frame update
    void Start()
    {
        SwitchState(_workState);
        bruxinha = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateState(this);
        if (_zombieDie && _currentStateName!= _dieState.GetCurrentState(this)) 
        {
            auxState = _currentState;
            _auxStateName = auxState.GetCurrentState(this);
            SwitchState(_dieState);
        }
    }


    public void SwitchState(ZombieBaseState state)
    {
        _currentState = state;
        _currentState.EnterState(this);
        _currentStateName = _currentState.GetCurrentState(this);

    }
}