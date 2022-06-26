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
    public List<Image> itensCraftUI;
    public List<TextMeshProUGUI> itensAmount;
    public List<TextMeshProUGUI> craftItensAmount;
    public List<BruxinhaItens> craft;
    public List<bool> frameClicked;
    public List<bool> frameCraftClicked;
    private void Start()
    {
        inventoryUI = GameObject.Find("Inventory");
        inventoryUI.SetActive(false);
        itensAmount = inventoryUI.GetComponentsInChildren<TextMeshProUGUI>().ToList();
        bool[] aux = new bool[5];
        frameClicked = new List<bool>(aux);
        bool[] auxCraft = new bool[3];
        frameCraftClicked = new List<bool>(auxCraft);
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
            if (itemOrderUI.amount > 0 && !frameClicked[itemOrderUI.UIPosition])
            {
                itensUI[itemOrderUI.UIPosition].sprite = itemOrderUI.UiSprite;
                itensAmount[itemOrderUI.UIPosition].text = ""+itemOrderUI.amount;
            }
            else
            {
                itensUI[itemOrderUI.UIPosition].sprite = spriteDefault;

                itensAmount[itemOrderUI.UIPosition].text = "";
            }
        }
        for(int i =0;i< itensCraftUI.Count; i++)
        {
            itensCraftUI[i].sprite = craft[i].UiSprite;
            craftItensAmount[i].text = ""+ craft[i].amount;
        }
    }
    private void ResetInventory()
    {
        for(int i =0;i< itensUI.Count; i++)
        {
            itensUI[i].sprite = spriteDefault;
            itensAmount[i].text = "";
        }

        for(int i = 0; i < itensCraftUI.Count; i++)
        {
            itensCraftUI[i].sprite = spriteDefault;
            craftItensAmount[i].text = "";
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
