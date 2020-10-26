using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NimTestAI : MonoBehaviour
{
    public Text allumettesTxt;
    public Text IATxt;
    public GameObject End;
    Nim game;
    //MinimaxSearch<List<int>, int, int> minimaxSearch;
    AlphaBetaSearch<NimState,int,int> alphabetaSearch;
    NimState CurrentState;

    public void SetupGame(int nb)
    {
        End.SetActive(false);
        allumettesTxt.text = "";
        IATxt.text = "";

        game = new Nim(nb);
        //minimaxSearch = MinimaxSearch<List<int>, int, int>.createFor(game);
        alphabetaSearch = AlphaBetaSearch<NimState, int, int>.createFor(game);
        CurrentState = game.getInitialState();
        allumettesTxt.text = "Allumettes restantes : "+CurrentState.allumettes.ToString();

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
                IATxt.text = "Félicitation, tu as gagné face à l'ordinateur";            
            }
            else
            {
                IATxt.text = "Dommage, l'IA a été plus fort que toi. L'important c'est de participer.";               
            }

            // Affichage Menu
            End.SetActive(true);
        }
    }

    void AICanPlay()
    {
        int action = -1;
        //action = minimaxSearch.makeDecision(CurrentState);
        action = alphabetaSearch.makeDecision(CurrentState);
        IATxt.text = "L'IA a choisi de retirer "+action.ToString()+" allumettes";
        NimState updateState = game.getResult(CurrentState, action);
        allumettesTxt.text = "Allumettes restantes : "+updateState.allumettes.ToString();
        CurrentState = updateState;
        

        CheckisTerminal();
    }

    public void PlayerChooseNumber(Button button)
    {
        int action = int.Parse(button.name);

        // On vérifie que l'action est possible
        List<int> actionpossible = game.getActions(CurrentState);
        if(actionpossible.Contains(action))
        {
            // On peut jouer
            NimState updateState = game.getResult(CurrentState, action); 
            allumettesTxt.text = "Allumettes restantes : "+updateState.allumettes.ToString();
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
}
