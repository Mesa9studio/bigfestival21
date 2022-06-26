using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="New Item")]
public class ItemScriptable : ScriptableObject
{
    public enum TipoDeItens { Faca, Abobora,Combustivel }

    public TipoDeItens tipo;
    public Sprite UiSprite;

}
