using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwaleTest : MonoBehaviour
{
    private void Start()
    {
        Awale game = new Awale();   
        //MinimaxSearch<StatePuissance4, int, int> minimaxSearch = MinimaxSearch<StatePuissance4, int, int>.createFor(game);
        AlphaBetaSearch<StateAwale, int, int> alphabetaSearch = AlphaBetaSearch<StateAwale, int, int>.createFor(game);   

        StateAwale state = game.getInitialState();

	    //int action = -100000;
        int action2 = -100000;

        Debug.Log("Machine player, what is your action?");
        //action = minimaxSearch.makeDecision(state);
        action2 = alphabetaSearch.makeDecision(state);
        //Debug.Log("Metrics for Minimax : "+minimaxSearch.getMetrics());
        Debug.Log("Metrics for AlphaBeta : "+alphabetaSearch.getMetrics());
	    //Debug.Log("Chosen action Minimax is " + action);
        Debug.Log("Chosen action AlphaBeta is " + action2);
    }
}
