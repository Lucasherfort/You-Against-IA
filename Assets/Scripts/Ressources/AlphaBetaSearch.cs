using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaBetaSearch<STATE, ACTION, PLAYER> 
{
    private Game<STATE, ACTION, PLAYER> game;
    private int expandeNode;

    /** Creates a new search object for a given game. */
	public static AlphaBetaSearch<STATE, ACTION, PLAYER> createFor(Game<STATE, ACTION, PLAYER> game) 
    {
        return new AlphaBetaSearch<STATE, ACTION, PLAYER>(game);
	}
    public AlphaBetaSearch(Game<STATE, ACTION, PLAYER> game) 
    {
		this.game = game;
    }
    public ACTION makeDecision(STATE state) 
    {
        expandeNode = 0;
		ACTION result = default(ACTION); 
		double resultValue = double.NegativeInfinity;

		PLAYER player = game.getPlayer(state);

        double alpha = double.NegativeInfinity;
        double beta = double.PositiveInfinity;

		foreach (ACTION action in game.getActions(state)) 
        {
            double value = 0;

            if(!game.useDepth())
            {
                value = minValue(game.getResult(state, action), player,alpha,beta);
            }
            else
            {
                value = minValueWithDepth(game.getResult(state, action), player,alpha,beta,game.getDepth());
            }

		    if (value > resultValue) 
            {
		        result = action;
		        resultValue = value;
		    }
		}
		return result;
    }
	public double maxValue(STATE state, PLAYER player, double alpha, double beta) 
    {
        double value = double.NegativeInfinity;
        expandeNode++;

        if (game.isTerminal(state))
        {
            return game.getUtility(state, player);
        }

		foreach (ACTION action in game.getActions(state))
        {
            value = Mathf.Max((float)value,(float)minValue(game.getResult(state, action), player,alpha,beta));

            if(value >= beta)
            {
                return value;
            }

            alpha = Mathf.Max((float)alpha,(float)value);
        }

        return value;
	}
    public double minValue(STATE state, PLAYER player, double alpha, double beta) 
    {
        double value = double.PositiveInfinity;
        expandeNode++;

        if (game.isTerminal(state))
        {
		    return game.getUtility(state, player);
        }

	    foreach (ACTION action in game.getActions(state))
        {
		    value = Mathf.Min((float)value,(float)maxValue(game.getResult(state, action), player, alpha,beta));        

            if(alpha >= value)
            {
                return value;
            }

            beta = Mathf.Min((float)beta,(float)value);
        }

        return value;
	}

    	public double maxValueWithDepth(STATE state, PLAYER player, double alpha, double beta, int d) 
    {
        double value = double.NegativeInfinity;
        expandeNode++;

        if (game.isTerminal(state) || d == 0)
        {
            return game.getUtility(state, player);
        }

		foreach (ACTION action in game.getActions(state))
        {
            value = Mathf.Max((float)value,(float)minValueWithDepth(game.getResult(state, action), player,alpha,beta,d-1));

            if(value >= beta)
            {
                return value;
            }

            alpha = Mathf.Max((float)alpha,(float)value);
        }

        return value;
	}
    public double minValueWithDepth(STATE state, PLAYER player, double alpha, double beta, int d) 
    {
        double value = double.PositiveInfinity;
        expandeNode++;

        if (game.isTerminal(state) || d==0)
        {
		    return game.getUtility(state, player);
        }

	    foreach (ACTION action in game.getActions(state))
        {
		    value = Mathf.Min((float)value,(float)maxValueWithDepth(game.getResult(state, action), player, alpha,beta, d-1));        

            if(alpha >= value)
            {
                return value;
            }

            beta = Mathf.Min((float)beta,(float)value);
        }

        return value;
	}

    public int getMetrics()
    {
        return expandeNode;
    }
}
