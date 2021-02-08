using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Othello : Game<StateOthello,int,int>
{
    StateOthello state = new StateOthello();

    public Othello()
    {
        state.player = 1;
        state.grid = new Color[64];
    }

    public StateOthello getInitialState()
    {
        state.grid[27] = Color.white;
        state.grid[28] = Color.black;
        state.grid[35] = Color.black;
        state.grid[36] = Color.white;

        return state;
    }

    public int getPlayer(StateOthello state)
    {
        return(state.player);
    }

    public List<int> getActions(StateOthello state)
    {
        List<int> actions = new List<int>();
        
        for(int i = 0 ; i < state.grid.Length ; i++)
        {
            if(state.grid[i] == Color.clear)
            {

                // TODO :(

                actions.Add(i);
            }
        }

        return (actions);
    }

    public StateOthello getResult(StateOthello state, int action)
    {
        StateOthello newState = new StateOthello();

        newState.grid = (Color[])state.grid.Clone();


        // TODO :(

        if(state.player == 1)
        {
            newState.grid[action] = Color.black;
        }
        else
        {
            newState.grid[action] = Color.white;
        }

        newState.player = 1 - state.player;

        return(newState);
    }

    public bool isTerminal(StateOthello state)
    {
        for(int i = 0 ; i < state.grid.Length ; i++)
        {
            if(state.grid[i] == Color.clear)
            {
                return false;
            }
        }
        return true;
    }

    public int getUtility(StateOthello state, int player)
    {
        /* Alignement d'une couleur  +1 
        2 couleurs +5
        3 couleurs 50
        4 couleurs 1000
        */

        int score = 0;

        // TODO :)

        return score;
    }

    public bool useDepth()
    {
        return true;
    }

    public int getDepth()
    {
        return 4;
    }

    public bool isMax( int player)
    {
        if (player == 1)
        {
            return true;
        }
        else
        {
            return false;           
        }        
    }
}


/* 1 = noir et 0 = blanc */
public class StateOthello
{
    public int player;
    public Color[] grid;


    // Constructeur par défaut
    public StateOthello()
    {
        this.player = 1;
        this.grid = null;
    }
}
