using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    // identificação dentro da Unity.
    public GameObject generalMenu;
    public GameObject optionMenu;

    // Start is called before the first frame update.
    void Start()
    {
        ActiveMenu (generalMenu);
    }

    // Update is called once per frame.
    void Update()
    {
        
    }

    private void HideMenus()
    {
    // Primeiro ele desativa todas as telas.
        generalMenu.SetActive (false);
        optionMenu.SetActive (false);
    }
    public void ActiveMenu (GameObject Menu)
    {
    // Aqui ativa a Tela do menu dependendo do botão.
        HideMenus();
        Menu.SetActive (true);
    }
    // Para fechar o jogo.
    public void ExitGame() {
        ApplicationController.ExitGame();
            }
}
