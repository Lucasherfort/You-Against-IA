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

	    int action = -100000;
        int action2 = -100000;

        Debug.Log("Machine player, what is your action?");
        action = minimaxSearch.makeDecision(state);
        action2 = alphabetaSearch.makeDecision(state);
        Debug.Log("Metrics for Minimax : "+minimaxSearch.getMetrics());
        Debug.Log("Metrics for AlphaBeta : "+alphabetaSearch.getMetrics());
	    Debug.Log("Chosen action Minimax is " + action);
        Debug.Log("Chosen action AlphaBeta is " + action2);

    }
}
