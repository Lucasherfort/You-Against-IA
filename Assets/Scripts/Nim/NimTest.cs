using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NimTest : MonoBehaviour
{
    private void Start()
    {
        Nim game = new Nim(15);
        MinimaxSearch<NimState, int, int> minimaxSearch = MinimaxSearch<NimState, int, int>.createFor(game);
	    AlphaBetaSearch<NimState, int, int> alphabetaSearch = AlphaBetaSearch<NimState, int, int>.createFor(game);

        NimState state = game.getInitialState();
	    int action1 = -1;
        int action2 = -1;

        Debug.Log("Machine player, what is your action?");
        action1 = minimaxSearch.makeDecision(state);
        action2 = alphabetaSearch.makeDecision(state);

	    Debug.Log("Chosen action is " + action1);
        Debug.Log("Chosen action is " + action2);

        Debug.Log("node minimax " + minimaxSearch.getMetrics());
        Debug.Log("node alphabeta " + alphabetaSearch.getMetrics());
    }
}
