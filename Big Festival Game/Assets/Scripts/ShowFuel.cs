using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFuel : MonoBehaviour
{
    public Image img;
    public Bruxa bruxa;
    // Start is called before the first frame update
    void Start()
    {
        bruxa = GameObject.FindWithTag("Player").GetComponent<Bruxa>();
    }

    // Update is called once per frame
    void Update()
    {
        img.fillAmount = bruxa.flyState.flyFuel/10;
    }
}
