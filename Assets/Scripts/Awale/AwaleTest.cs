using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwaleTest : MonoBehaviour
{
    private void Start()
    {
        Awale game = new Awale();   
        MinimaxSearch<StateAwale, int, int> minimaxSearch = MinimaxSearch<StateAwale, int, int>.createFor(game);
        AlphaBetaSearch<StateAwale, int, int> alphabetaSearch = AlphaBetaSearch<StateAwale, int, int>.createFor(game);   

        StateAwale state = game.getInitialState();

	    int action1 = -100000;
        int action2 = -100000;

        action1 = minimaxSearch.makeDecision(state);
        action2 = alphabetaSearch.makeDecision(state);

        Debug.Log("Chosen action is " + action1+" and node minimax " + minimaxSearch.getMetrics());
        Debug.Log("Chosen action is " + action2+" and node alphabeta " + alphabetaSearch.getMetrics());
    }
}
