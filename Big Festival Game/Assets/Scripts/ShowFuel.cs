using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFuel : MonoBehaviour
{
    public Image img;
    public Bruxa bruxa;
    private float maxFuel;
    // Start is called before the first frame update
    void Start()
    {
        bruxa = GameObject.FindWithTag("Player").GetComponent<Bruxa>();
        maxFuel = bruxa.flyState.flyFuel;
    }

    // Update is called once per frame
    void Update()
    {
        img.fillAmount = bruxa.flyState.flyFuel/maxFuel;
    }
}
