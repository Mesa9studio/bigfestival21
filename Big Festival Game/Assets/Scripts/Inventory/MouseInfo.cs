using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MouseInfo : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Camera cam;
    [SerializeField] private Image _img;
    public BruxinhaItens itemSelected;
    public int maybeNextPositionItemWillPut;
    public bool anyItemSelect;
    private void Start()
    {
        ResetIMGClicked();
    }
    private void Update()
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle
            (
                (RectTransform)canvas.transform,
                Input.mousePosition,
                canvas.worldCamera,
                out position
            );
        transform.position = canvas.transform.TransformPoint(position);
    }
    public void UpdateIMGClicked(BruxinhaItens item)
    {
        Debug.Log("BBBBBBBBBB" + item.tipodeItem);
        itemSelected = item;
        _img.sprite = item.UiSprite;
        _img.color = new Color(_img.color.r, _img.color.g, _img.color.b, 1);
        anyItemSelect = true;
    }

    public void ResetIMGClicked()
    {
        _img.sprite = null;
        _img.color = new Color(_img.color.r, _img.color.g, _img.color.b,0);
        anyItemSelect = false;
    }
}
