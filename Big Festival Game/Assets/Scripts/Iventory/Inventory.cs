using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;
public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private RectTransform inventoryUIBG;
    public List<BruxinhaItens> itensChar;
    public Sprite spriteDefault;
    public List<Image> itensUI;
    public List<TextMeshProUGUI> itensAmount;
    private void Start()
    {
        inventoryUI = GameObject.Find("Inventory");
        inventoryUI.SetActive(false);
        itensAmount = inventoryUI.GetComponentsInChildren<TextMeshProUGUI>().ToList();

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
        CellSize();
        ResetInventory();
        foreach (var itemOrderUI in UIItensOrder)
        {
            if (itemOrderUI.amount > 0)
            {
                itensUI[itemOrderUI.UIPosition].sprite = itemOrderUI.UiSprite;
                itensAmount[itemOrderUI.UIPosition].text = ""+itemOrderUI.amount;
            }
            else
            {
                itensAmount[itemOrderUI.UIPosition].text = "";
            }
        }
    }
    private void ResetInventory()
    {
        for(int i =0;i< itensUI.Count; i++)
        {
            itensUI[i].sprite = spriteDefault;
            itensAmount[i].text = "";
        }
    }
    public void CollectItem(ItemScriptable item)
    {
        BruxinhaItens itemDetect = itensChar.Find(p => p.tipodeItem == item.tipo);
        Debug.Log(itemDetect);
        if (itemDetect != null)
        {
            itemDetect.amount++;
        }
        else
        {
            itemDetect = new BruxinhaItens(item.tipo,1, itensChar.Count,item.UiSprite);
            itemDetect.UIPosition = itensChar.Count;
            itensChar.Add(itemDetect);
        }
    }



    private void CellSize()
    {
        GridLayoutGroup gridLayout = inventoryUI.GetComponentInChildren<GridLayoutGroup>();
        gridLayout.cellSize = new Vector2((inventoryUIBG.rect.width / 5)-20, (inventoryUIBG.rect.width / 5)-20);
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
