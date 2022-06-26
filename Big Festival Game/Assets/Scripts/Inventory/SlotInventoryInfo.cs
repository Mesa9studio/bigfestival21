using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotInventoryInfo : MonoBehaviour, IPointerDownHandler,IPointerUpHandler,IPointerEnterHandler
{
    private Inventory inventory;
    [SerializeField]private int position;
    [SerializeField] private MouseInfo _mInfo;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindObjectOfType<Inventory>();
        _mInfo = GameObject.FindObjectOfType<MouseInfo>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        BruxinhaItens itemClick = inventory.itensChar.Find(p => p.UIPosition == position);
        if (eventData.button.ToString()== "Left")
        {
            if (itemClick != null)
            {
                inventory.frameClicked[position] = true;
                inventory.ShowInventory();
                _mInfo.UpdateIMGClicked(itemClick);
                _mInfo.anyItemSelect = true;
            }
        }
        else
        {
            if (itemClick.tipodeItem == ItemScriptable.TipoDeItens.Combustivel)
            {
                //inventory.GetComponent<Bruxa>().flyState
            }
            else
            {
                BruxinhaItens knife = inventory.itensChar.Find(p => p.tipodeItem == ItemScriptable.TipoDeItens.Faca);
                BruxinhaItens abob = inventory.itensChar.Find(p => p.tipodeItem == ItemScriptable.TipoDeItens.Abobora);
                if (knife != null && abob.amount > 0)
                {
                    BruxinhaItens comb = inventory.itensChar.Find(p => p.tipodeItem == ItemScriptable.TipoDeItens.Combustivel);
                    Debug.Log(comb);
                    if (comb != null)
                    {
                        comb.amount++;
                        abob.amount--;
                        inventory.ShowInventory();
                    }
                    else
                    {
                        int posUICombustivel = 0;
                        for (int i = 0; i < 5; i++)
                        {
                            if (inventory.itensChar.Find(p => p.UIPosition == i) == null)
                            {
                                posUICombustivel = i;
                                i = 5;
                            }
                        }
                        Debug.Log(posUICombustivel);
                        inventory.AdicionarElementoCombustivel(posUICombustivel);
                        abob.amount--;
                        inventory.ShowInventory();
                    }
                }
            }
            
        }


    }

    public void OnPointerUp(PointerEventData eventData)
    {
        BruxinhaItens item = inventory.itensChar.Find(P => P.UIPosition == position);
        if (eventData.button.ToString() == "Left")
        {
            if (item != null)
            {
                item.UIPosition = _mInfo.maybeNextPositionItemWillPut;
                _mInfo.maybeNextPositionItemWillPut = 0;
                _mInfo.ResetIMGClicked();
                inventory.frameClicked[position] = false;
                _mInfo.anyItemSelect = false;
                inventory.ShowInventory();
            }
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_mInfo.anyItemSelect)
        {
            Debug.Log(this.gameObject.name + " Was Enter: " + _mInfo.anyItemSelect);
            _mInfo.maybeNextPositionItemWillPut = position;
        }
    }
}
