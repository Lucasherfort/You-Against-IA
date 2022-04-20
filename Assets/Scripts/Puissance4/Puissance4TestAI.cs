using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puissance4TestAI : MonoBehaviour
{
    public GameObject End;
    public GameObject[] Cell;
    Puissance4 game;
    //MinimaxSearch<State, int, int> minimaxSearch;
    AlphaBetaSearch<StatePuissance4,int,int> alphabetaSearch;
    StatePuissance4 CurrentState;

    private void Start()
    {
        End.SetActive(false);
        game = new Puissance4();

        //minimaxSearch = MinimaxSearch<State, int, int>.createFor(game);
        alphabetaSearch = AlphaBetaSearch<StatePuissance4, int, int>.createFor(game);

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

        GameObject.Find(action.ToString()).GetComponent<Image>().color = Color.red;

        StatePuissance4 updateState = game.getResult(CurrentState, action);

        CurrentState = updateState;

        CheckisTerminal();
    }

    public void PlayerChooseCase(Button button)
    {
        int action = int.Parse(button.name);
        if(button.GetComponent<Image>().color == Color.white && game.getActions(CurrentState).Contains(action) && !game.isTerminal(CurrentState))
        {
            StatePuissance4 updateState = game.getResult(CurrentState, action);

            button.GetComponent<Image>().color = Color.yellow;
            CurrentState = updateState;

            CheckisTerminal();
        }
        else
        {     
            return;   
        }
    }

    public void CleanGrid()
    {
        for(int i = 0 ; i < Cell.Length ; i++)
        {
            Cell[i].GetComponent<Image>().color = Color.white;
        }

        Start();
    }
}
