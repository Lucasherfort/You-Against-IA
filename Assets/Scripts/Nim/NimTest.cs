using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NimTest : MonoBehaviour
{
    [Min(2)]
    public int Matches = 2; 

    private void Start()
    {
        Nim game = new Nim(Matches);
        MinimaxSearch<NimState, int, int> minimaxSearch = MinimaxSearch<NimState, int, int>.createFor(game);
	    AlphaBetaSearch<NimState, int, int> alphabetaSearch = AlphaBetaSearch<NimState, int, int>.createFor(game);

        NimState state = game.getInitialState();
	    int action1 = -1;
        int action2 = -1;
        
        action1 = minimaxSearch.makeDecision(state);
        action2 = alphabetaSearch.makeDecision(state);

        Debug.Log("Chosen action is " + action1+" and node minimax " + minimaxSearch.getMetrics());
        Debug.Log("Chosen action is " + action2+" and node alphabeta " + alphabetaSearch.getMetrics());
    }
}
