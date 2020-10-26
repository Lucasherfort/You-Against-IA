using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nim : Game<NimState,int,int>
{
    NimState state = new NimState();

    public Nim(int allumettes)
    {
        state.player = 1;
        state.allumettes = allumettes;
    }

    public NimState getInitialState()
    {
        return state;
    }

    public int getPlayer(NimState state)
    {
        return(state.player);
    }

    public List<int> getActions(NimState state)
    {
        List<int> actions = new List<int>();
        int allumettesRestantes = state.allumettes;

        if (allumettesRestantes > 3)
        {
            actions.Add(1);
            actions.Add(2);
            actions.Add(3);
        }
        else if (allumettesRestantes == 3)
        {
            actions.Add(1);
            actions.Add(2);         
        }
        else if (allumettesRestantes == 2)
        {
            actions.Add(1);
        }
    
        return (actions);
    }

    public NimState getResult(NimState state, int action)
    {
        NimState newState = new NimState();
        int currentAllumettes = state.allumettes;
        int newNbAllumettes = currentAllumettes - action;

        newState.player = 1 - state.player;
        newState.allumettes = newNbAllumettes;

        return(newState);
    }

    public bool isTerminal(NimState state)
    {
        if (state.allumettes == 1)
        {
            return true;
        }
        else
        {
            return false;           
        }
    }

    public int getUtility(NimState state, int player)
    {

        if(state.player == player)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }
    public bool isMax( int player)
    {
        if (player == 0)
        {
            return true;
        }
        else
        {
            return false;           
        }        
    }

    public bool useDepth()
    {
        return false;
    }

    public int getDepth()
    {
        return 0;
    }
}

public class NimState
{
    public int player;
    public int allumettes;

    /* Constructeur par défaut */
    public NimState()
    {
        this.player = 1;
        this.allumettes = 0;
    }
}
