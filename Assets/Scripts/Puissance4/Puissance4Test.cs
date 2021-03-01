using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puissance4Test : MonoBehaviour
{
    private void Start()
    {
        Puissance4 game = new Puissance4();   
        MinimaxSearch<StatePuissance4, int, int> minimaxSearch = MinimaxSearch<StatePuissance4, int, int>.createFor(game);
        AlphaBetaSearch<StatePuissance4, int, int> alphabetaSearch = AlphaBetaSearch<StatePuissance4, int, int>.createFor(game);   

        StatePuissance4 state = game.getInitialState();

	    int action1 = -100000;
        int action2 = -100000;

        action1 = minimaxSearch.makeDecision(state);
        action2 = alphabetaSearch.makeDecision(state);
        
        Debug.Log("Chosen action is " + action1+" and node minimax " + minimaxSearch.getMetrics());
        Debug.Log("Chosen action is " + action2+" and node alphabeta " + alphabetaSearch.getMetrics());
    }
}
