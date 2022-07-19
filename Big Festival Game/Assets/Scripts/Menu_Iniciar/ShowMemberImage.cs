using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ShowMemberImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Animator popUpAnimator;


    public void OnPointerEnter(PointerEventData eventData)
    {
        popUpAnimator.SetBool("Show", true);
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        popUpAnimator.SetBool("Show", false);
    }


}
