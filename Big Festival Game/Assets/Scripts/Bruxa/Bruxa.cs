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
    [Header ("Witch Data")]
    public Rigidbody                myRb;
    public int                      life                = 1;
    [SerializeField]private Inventory InventoryWitch;
    // Start is called before the first frame update
    void Start()
    {
        // myRb.GetComponent<Rigidbody>();
        SwitchState(movementState);
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


    public void SwitchState(BruxaBaseState state)
    {
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
        life--;
        currentState.TakeDamage(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enter collision");
        currentState.OnCollisionEnter(this,collision);
        if(collision.gameObject.tag == "Faca" || collision.gameObject.tag == "Abobora")
        {
            Debug.Log(collision.gameObject);
            Debug.Log(collision.gameObject.GetComponent<Item>());
            InventoryWitch.CollectItem(collision.gameObject.GetComponentInParent<Item>().itemInfo);
            Destroy(collision.gameObject.transform.parent.gameObject);
        }

        
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Enter collision");
        currentState.OnCollisionEnter(this,collision);
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
