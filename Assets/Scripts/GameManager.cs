using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject NimGame;
    public GameObject TTTGame;
    public GameObject Puissance4Game;
    public GameObject AwaleGame;

    private void Start()
    {
        MainMenu.SetActive(true);
        NimGame.SetActive(false);
        TTTGame.SetActive(false);
        Puissance4Game.SetActive(false);
        AwaleGame.SetActive(false);
    }

    public void GameChosen(Button button)
    {
        switch (button.name)
        {
            case "Allumettes":
                MainMenu.SetActive(false);
                NimGame.SetActive(true);
                break;

            case "Morpion":
                MainMenu.SetActive(false);
                TTTGame.SetActive(true);
                TTTGame.GetComponentInChildren<TTTTestAI>().CleanGrid();
                break;

            case "Puissance4":
                MainMenu.SetActive(false);
                Puissance4Game.SetActive(true);
                Puissance4Game.GetComponentInChildren<Puissance4TestAI>().CleanGrid();
                break;

            case "Awale":
                MainMenu.SetActive(false);
                AwaleGame.SetActive(true);
                AwaleGame.GetComponentInChildren<AwaleTestAI>().CleanGrid();
                break;   

            case "Quitter":
                Application.Quit();
                break;
        }
    }

    public void NimMenuComeBack()
    {
        NimGame.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void TTTMenuComeBack()
    {
        TTTGame.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void Puissance4ComeBack()
    {
        Puissance4Game.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void AwaleComeBack()
    {
        AwaleGame.SetActive(false);
        MainMenu.SetActive(true);
    }
}
