using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public enum BruxaState{
//     Stop,
//     Move,
//     Attack,
//     Fly,
//     Damage,
//     FlyDamage,
//     Dead
// }

public class Bruxa : MonoBehaviour
{

           BruxaBaseState       currentState;
    public string               currentStateName;
    [Header("States")]
    public BruxaStoppedState        stoppedState        = new BruxaStoppedState();
    public BruxaMovementState       movementState       = new BruxaMovementState();
    public BruxaAttackState         attackState         = new BruxaAttackState();
    public BruxaFlyState            flyState            = new BruxaFlyState();
    public BruxaDamagedState        damagedState        = new BruxaDamagedState();
    public BruxaFlyingDamagedState  flyingDamagedState  = new BruxaFlyingDamagedState();
    public BruxaDeadState           deadState           = new BruxaDeadState();
    [Header ("Witch Data")]
    public Rigidbody                myRb;
    public int                      currenteLife         = 4;
    public Animator                 bruxaAnimator;
    [SerializeField]private Inventory InventoryWitch;
    public GameObject AttackPoint;
    private Dictionary<string, BruxaBaseState> statesFromString = new Dictionary<string, BruxaBaseState>();
    // Start is called before the first frame update
    void Start()
    {
        // fica fácil converter a partir de uma string
        // do que ficar usando if/switch para verificar cada um
        statesFromString.Add("Stop", stoppedState);
        statesFromString.Add("Move", movementState);
        statesFromString.Add("Attack", attackState);
        statesFromString.Add("Fly", flyState);
        statesFromString.Add("Damage", damagedState);
        statesFromString.Add("FlyDamage", flyingDamagedState);
        statesFromString.Add("Dead", deadState);


        // myRb.GetComponent<Rigidbody>();
        SwitchState(stoppedState);
        InventoryWitch = GetComponent<Inventory>();
        

    }


    // Update is called once per frame
    void Update()
    {
        UpdateState();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        FixedUpdateState();
    }

    public void SwitchStateWithEnum(States.Bruxa state)
    {
        SwitchState(statesFromString[state.ToString()]);
    }

    public void SwitchState(BruxaBaseState state, bool Switch = true)
    {
        if(!Switch)
            return;
        
        myRb.useGravity = true;
        // transform.rotation = Quaternion.LookRotation(Vector3.zero);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        myRb.velocity = Vector3.zero;
        currentState = state;
        currentState.EnterState(this);
        currentStateName = state.GetStateName();
    }

    // atualiza o update do estado atual
    void UpdateState()
    {
        if (currentState != null)
            currentState.UpdateState(this);
    }


    // atualiza o fixedUpdate do estado atual
    void FixedUpdateState()
    {
        if (currentState != null)
            currentState.FixedUpdateState(this);
    }

    public void TakeDamage()
    {
        currenteLife--;
        if (currenteLife > 0)
            currentState.TakeDamage(this);
        else
            SwitchState(deadState);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this,collision);
        if(collision.gameObject.tag == "Faca" || collision.gameObject.tag == "Abobora")
        {
            InventoryWitch.CollectItem(collision.gameObject.GetComponentInParent<Item>().itemInfo);
            Destroy(collision.gameObject.transform.parent.gameObject);
        }
        else if(collision.gameObject.tag == Tags.Rua)
        {
            SwitchState(deadState);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        currentState.OnCollisionEnter(this,collision);
    }

    private void OnTriggerEnter(Collider collider)
    {
        // Debug.Log($"Name: {collider.gameObject.name}");
        currentState.OnTriggerEnter(this,collider);
    }

    private void OnTriggerExit(Collider collider)
    {
        currentState.OnTriggerExit(this,collider);
    }


    public void CollectItem(ItemScriptable itemInfo)
    {
        if (InventoryWitch.itensChar.Count > 0)
        {
            BruxinhaItens newItem = new BruxinhaItens();
            newItem.tipodeItem = itemInfo.tipo;
            InventoryWitch.itensChar.Add(newItem);
        }
        else
        {
            BruxinhaItens itemWitch = InventoryWitch.itensChar.Find(p => p.tipodeItem == itemInfo.tipo);
            if (itemWitch != null)
            {
                itemWitch.amount++;
            }
            else
            {
                itemWitch.UIPosition = InventoryWitch.itensChar.Count;
                InventoryWitch.itensChar.Add(itemWitch);
            }
        }

    }


    public void FinishAttack()
    {
        SwitchState(stoppedState);
        StartCoroutine("DelayBetweenAttacks");
    }


    IEnumerator DelayBetweenAttacks()
    {
        yield return new WaitForSeconds(attackState.timeBetweenAttacks);
        attackState.canAttack = true;
    }
}
