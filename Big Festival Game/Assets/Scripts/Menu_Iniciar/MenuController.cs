using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // identificação dentro da Unity.
    public GameObject generalMenu;
    public GameObject optionMenu;
    public string nomeDaCena = "GameScenePersonal";

    // Start is called before the first frame update.
    void Start()
    {
        ActiveMenu (generalMenu);
    }

    private void HideMenus()
    {
        // Primeiro ele desativa todas as telas.
        generalMenu.SetActive (false);
        optionMenu.SetActive (false);
    }

    public void ActiveMenu (GameObject Menu)
    {
        // Aqui ativa a Tela do menu dependendo do bot�o.
        HideMenus();
        Menu.SetActive (true);
    }

    // Para fechar o jogo.
    public void ExitGame()
    {
        // ApplicationController.ExitGame();
        Application.Quit();
    }

    public void LoadGamePlay()
    {
        SceneManager.LoadScene(nomeDaCena);
    }
}
