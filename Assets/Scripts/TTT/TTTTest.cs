using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTTTest : MonoBehaviour
{
    private void Start()
    {
        TTT game = new TTT();   
        MinimaxSearch<StateTTT, int, int> minimaxSearch = MinimaxSearch<StateTTT, int, int>.createFor(game);
        AlphaBetaSearch<StateTTT, int, int> alphabetaSearch = AlphaBetaSearch<StateTTT, int, int>.createFor(game);   

        StateTTT state = game.getInitialState();

	    int action1 = -100000;
        int action2 = -100000;

        action1 = minimaxSearch.makeDecision(state);
        action2 = alphabetaSearch.makeDecision(state);

        Debug.Log("Chosen action is " + action1+" and node minimax " + minimaxSearch.getMetrics());
        Debug.Log("Chosen action is " + action2+" and node alphabeta " + alphabetaSearch.getMetrics());
    }
}
