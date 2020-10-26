using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AwaleTestAI : MonoBehaviour
{
    public GameObject End;
    public GameObject[] Cell;

    public Text ScoreAI;
    public Text ScorePlayer;
    Awale game;
    AlphaBetaSearch<StateAwale,int,int> alphabetaSearch;
    StateAwale CurrentState;

    private void Start()
    {
        End.SetActive(false);
        game = new Awale();

        //minimaxSearch = MinimaxSearch<State, int, int>.createFor(game);
        alphabetaSearch = AlphaBetaSearch<StateAwale, int, int>.createFor(game);

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
            if(CurrentState.player == 0)
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

        Debug.Log("L'IA a choisi de jouer case "+action);

        StateAwale updateState = game.getResult(CurrentState, action);

        CurrentState = updateState;

        RefreshScore();

        CheckisTerminal();
    }

    public void PlayerChooseCase(Button button)
    {
        int action = int.Parse(button.name);
        if(CurrentState.grid[action] != 0 && !game.isTerminal(CurrentState))
        {
            StateAwale updateState = game.getResult(CurrentState, action);

            CurrentState = updateState;

            RefreshScore();

            CheckisTerminal();
        }
        else
        {
            // erreur
            Debug.Log("Action impossible");        
            return;   
        }
    }

    private void RefreshScore()
    {

        ScoreAI.text = CurrentState.scoreAI.ToString();
        ScorePlayer.text = CurrentState.scorePlayer.ToString();

        for(int i = 0 ; i < Cell.Length ; i++)
        {
            Cell[i].GetComponentInChildren<Text>().text = CurrentState.grid[i].ToString();
        }

    }

    public void CleanGrid()
    {
        for(int i = 0 ; i < Cell.Length ; i++)
        {
            Cell[i].GetComponentInChildren<Text>().text = "4";
        }

        ScoreAI.text = "0";
        ScorePlayer.text = "0";

        Start();
    }
}
