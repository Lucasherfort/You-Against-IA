using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NimManager : MonoBehaviour
{
    public GameObject NBA;
    public GameObject Game;
    int nbAllumette;
    public Text nbAllmetteText;
    int MinValue = 16;
    int MaxValue = 30;

    private void Start()
    {
        NBA.SetActive(true);
        Game.SetActive(false);

        nbAllumette = 16;
        nbAllmetteText.text = nbAllumette.ToString(); 
    }

    public void Moins()
    {
        if(nbAllumette > MinValue)
        {
           nbAllumette--; 
           nbAllmetteText.text = nbAllumette.ToString(); 
        }
    }

    public void Plus()
    {
        if(nbAllumette < MaxValue)
        {
            nbAllumette++;   
            nbAllmetteText.text = nbAllumette.ToString();        
        }
    }

    public void START_NIM_GAME()
    {
        GetComponent<NimTestAI>().SetupGame(nbAllumette);

        NBA.SetActive(false);
        Game.SetActive(true);
    }

    public void TRYAGAIN()
    {
        GetComponent<NimTestAI>().allumettesTxt.text = "";
        GetComponent<NimTestAI>().IATxt.text = "";
        GetComponent<NimTestAI>().SetupGame(nbAllumette);
    }

    public void RETOUR()
    {
        Game.SetActive(false);
        NBA.SetActive(true);
    }
}
