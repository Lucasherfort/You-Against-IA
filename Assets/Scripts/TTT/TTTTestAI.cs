using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TTTTestAI : MonoBehaviour
{
    public GameObject End;
    public GameObject[] Cell;

    TTT game;
    //MinimaxSearch<State, int, int> minimaxSearch;
    AlphaBetaSearch<StateTTT,int,int> alphabetaSearch;
    StateTTT CurrentState;

    private void Start()
    {
        End.SetActive(false);

        game = new TTT();

        //minimaxSearch = MinimaxSearch<State, int, int>.createFor(game);
        alphabetaSearch = AlphaBetaSearch<StateTTT, int, int>.createFor(game);

        CurrentState = game.getInitialState();

        CheckisTerminal();
    }

    public void CheckisTerminal()
    {
        if(!game.isTerminal(CurrentState))
        {
            if(CurrentState.player == 0)
            {
                AICanPlay();
            }
            else
            {
                return;
            }
        }
        else
        {
            if(CurrentState.player == 1)
            {
                Debug.Log("Félicitation, tu as gagné face à l'ordinateur");            
            }
            else
            {
                Debug.Log("Dommage, l'IA a été plus fort que toi. L'important c'est de participer.");               
            }

            // Affichage Menu
            End.SetActive(true);
        }
    }

    void AICanPlay()
    {
        int action;

        action = alphabetaSearch.makeDecision(CurrentState);

        GameObject.Find(action.ToString()).GetComponentInChildren<Text>().text = "O";

        StateTTT updateState = game.getResult(CurrentState, action);

        CurrentState = updateState;

        CheckisTerminal();
    }

    public void PlayerChooseCase(Button button)
    {
        Text buttonText = GameObject.Find(button.name).GetComponentInChildren<Text>();

        if(buttonText.text == "" && !game.isTerminal(CurrentState))
        {
            int action = int.Parse(button.name);
            StateTTT updateState = game.getResult(CurrentState, action);

            buttonText.text = "X";
            CurrentState = updateState;

            CheckisTerminal();
        }
        else
        {
            // erreur
            Debug.Log("Action impossible");        
            return;   
        }
    }

    public void TRY_AGAIN()
    {
        CleanGrid();
    }

    public void CleanGrid()
    {
        for(int i = 0 ; i < Cell.Length ; i++)
        {
            Cell[i].GetComponentInChildren<Text>().text = "";
        }

        Start();
    }
 }
