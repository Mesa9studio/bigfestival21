using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject inventoryUI;
    public List<BruxinhaItens> itensChar;
    public List<Image> itensUI;
    private void Start()
    {
        inventoryUI = GameObject.Find("Inventory");

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.gameObject.SetActive(!inventoryUI.gameObject.activeSelf);
            if (inventoryUI.gameObject.activeSelf)
                ShowInventory();
        }
    }
    public void ShowInventory()
    {
        List<BruxinhaItens> UIItensOrder = itensChar.OrderBy(t => t.UIPosition).ToList();

        foreach(var itemOrderUI in UIItensOrder)
        {
            if (itemOrderUI.amount > 0)
            {
                itensUI[itemOrderUI.UIPosition].sprite = itemOrderUI.UiSprite;
            }
        }
    }

    public void CollectItem(ItemScriptable item)
    {
        Debug.Log("Teste");
        BruxinhaItens itemDetect = itensChar.Find(p => p.tipodeItem == item.tipo);
        Debug.Log(itemDetect);
        if (itemDetect != null)
        {
            itemDetect.amount++;
        }
        else
        {
            itemDetect = new BruxinhaItens(item.tipo,0, itensChar.Count,item.UiSprite);
            itemDetect.UIPosition = itensChar.Count;
            itensChar.Add(itemDetect);
        }
    }
}

[System.Serializable]
public class BruxinhaItens
{
    public ItemScriptable.TipoDeItens tipodeItem;
    public int amount;
    public int UIPosition;
    public Sprite UiSprite;

    public BruxinhaItens() { }
    public BruxinhaItens(ItemScriptable.TipoDeItens newTipodeItem,int newAmout,int newUIPosition,Sprite newUISprite)
    {
        tipodeItem=newTipodeItem;
        amount=newAmout;
        UIPosition=newUIPosition;
        UiSprite=newUISprite;
    }
}
