using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puissance4Test : MonoBehaviour
{
    private void Start()
    {

        Puissance4 game = new Puissance4();   
        //MinimaxSearch<StatePuissance4, int, int> minimaxSearch = MinimaxSearch<StatePuissance4, int, int>.createFor(game);
        AlphaBetaSearch<StatePuissance4, int, int> alphabetaSearch = AlphaBetaSearch<StatePuissance4, int, int>.createFor(game);   

        StatePuissance4 state = game.getInitialState();

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
