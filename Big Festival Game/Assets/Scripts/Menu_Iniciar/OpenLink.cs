using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLink : MonoBehaviour
{
    private Dictionary<string, string> links = new Dictionary<string, string>
    {
        {"Kellen",              "https://www.instagram.com/ascronicasdekellen/"},
        {"Jessé",               "https://bit.ly/399PiEv"},
        {"Edilson",             "https://www.linkedin.com/in/edilson-chavesws/"},
        {"Guilherme",           "https://www.linkedin.com/in/guilhermedecicco/"},
        {"Giovanni",            "https://linktr.ee/Giovanni_Garritano"},
        {"Bruno",               "https://linktr.ee/brunozandern"},
        {"Daniele",             "https://www.danieledantas.com/"},
        {"Renato",              "https://www.artstation.com/renight0"},
    };


    // quem chama essa função é algum botão
    public void OpenParticipant(string ptc)
    {
        GoURL(links[ptc]);
    }


    public void GoURL(string url)
    {
        Application.OpenURL(url);
    }
}
