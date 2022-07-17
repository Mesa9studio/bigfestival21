using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public int                      life                = 1;
    public Animator                 bruxaAnimator;
    [SerializeField]private Inventory InventoryWitch;
    // Start is called before the first frame update
    void Start()
    {
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


    public void SwitchState(BruxaBaseState state, bool Switch = true)
    {
        if(!Switch)
            return;

        currentState = state;
        currentState.EnterState(this);
        currentStateName = state.GetStateName();
    }

    // atualiza o update do estado atual
    void UpdateState()
    {
        if (currentState != null)
            currentState.UpdateState(this);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage();
        }
    }


    // atualiza o fixedUpdate do estado atual
    void FixedUpdateState()
    {
        if (currentState != null)
            currentState.FixedUpdateState(this);
    }

    public void TakeDamage()
    {
        life--;
        if (life > 0)
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


    }

    private void OnCollisionExit(Collision collision)
    {
        currentState.OnCollisionEnter(this,collision);
    }

    private void OnTriggerEnter(Collider collider)
    {
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
}
