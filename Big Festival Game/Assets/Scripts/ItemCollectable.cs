using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectable : MonoBehaviour, ICollectableItem
{
    public ItemScriptable itemInfo;
    [SerializeField] AudioSource audioSource;
    public void DestroyItem()
    {
        StartCoroutine(DestroyItemCoroutine());
    }
    IEnumerator DestroyItemCoroutine()
    {
        gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
        gameObject.GetComponentInChildren<Collider>().enabled = false;
        audioSource.Play();
        yield return new WaitUntil(()=>!audioSource.isPlaying);
        Destroy(gameObject);
    }
}
