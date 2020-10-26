using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Awale : Game<StateAwale,int,int>
{
    StateAwale state = new StateAwale();
    public Awale()
    {
        state.player = 1;
        state.grid = new int[12];

        state.grid[0] = 4;
        state.grid[1] = 4;
        state.grid[2] = 4;
        state.grid[3] = 4;
        state.grid[4] = 4;
        state.grid[5] = 4;
        state.grid[6] = 4;
        state.grid[7] = 4;
        state.grid[8] = 4;
        state.grid[9] = 4;
        state.grid[10] = 4;
        state.grid[11] = 4;
    }

    public StateAwale getInitialState()
    {

        return state;
    }

    public int getPlayer(StateAwale state)
    {
        return(state.player);
    }

    public List<int> getActions(StateAwale state)
    {
        List<int> actions = new List<int>();

        if(state.player == 0)
        {
            if(state.grid[6] != 0)
            {
                actions.Add(6);
            }
            if(state.grid[7] != 0)
            {
                actions.Add(7);
            }
            if(state.grid[8] != 0)
            {
                actions.Add(8);
            }
            if(state.grid[9] != 0)
            {
                actions.Add(9);
            }
            if(state.grid[10] != 0)
            {
                actions.Add(10);
            }
            if(state.grid[11] != 0)
            {
                actions.Add(11);
            }
        }
        else
        {
            if(state.grid[0] != 0)
            {
                actions.Add(0);
            }
            if(state.grid[1] != 0)
            {
                actions.Add(1);
            }
            if(state.grid[2] != 0)
            {
                actions.Add(2);
            }
            if(state.grid[3] != 0)
            {
                actions.Add(3);
            }
            if(state.grid[4] != 0)
            {
                actions.Add(4);
            }
            if(state.grid[5] != 0)
            {
                actions.Add(5);
            }
        }

        return (actions);
    }

    public StateAwale getResult(StateAwale state, int action)
    {
        StateAwale newState = new StateAwale();

        newState.grid = (int[])state.grid.Clone();

        newState.scoreAI = state.scoreAI;
        newState.scorePlayer = state.scorePlayer;

        // SeedInsideGrenier
        int SeedInsideGrenier = state.grid[action];

        // Vide le grenier de action
        newState.grid[action] = 0;

        int start = action;

        // indicateur de grenier 
        int depart = action+1;

        // Mise à jour des greniers
        while(SeedInsideGrenier != 0)
        {
            if(start == depart)
            {
                depart++;
            }

            // On repart au début 
            if(depart > 11)
            {
                depart = 0;
            }

            newState.grid[depart]++;
            SeedInsideGrenier--;

            // On passe au grenier suivant 
            depart++;
        }

        // On retire les graines si necessaire
        int arrive = depart-1;

        if(state.player == 1)
        {

            while(arrive < 12 && arrive > 5 && (newState.grid[arrive] == 2 || newState.grid[arrive] == 3))
            {
                newState.scorePlayer += newState.grid[arrive];
                newState.grid[arrive] = 0;
                arrive--;
            }
        }
        else
        {
            while(arrive >= 0 && arrive < 6 && (newState.grid[arrive] == 2 || newState.grid[arrive] == 3))
            {
                newState.scoreAI += newState.grid[arrive];
                newState.grid[arrive] = 0;
                arrive--;
            }
        }

        // Chagement de joueur
        newState.player = 1 - state.player;

        return(newState);
    }

    public bool isTerminal(StateAwale state)
    {
        if((state.player == 1 && state.grid[0] == 0 && state.grid[1] == 0 && state.grid[2] == 0 
        && state.grid[3] == 0 && state.grid[4] == 0 && state.grid[5] == 0)
        || (state.player == 0 && state.grid[6] == 0 && state.grid[7] == 0 && state.grid[8] == 0 
        && state.grid[9] == 0 && state.grid[10] == 0 && state.grid[11] == 0))
        {
            return true;
        }

        return false;
    }

    public int getUtility(StateAwale state, int player)
    {
        //int NbSeedIA = 0;
        //int NBSeedPlayer = 0;

        //NbSeedIA = state.grid[6] + state.grid[7] + state.grid[8] + state.grid[9] + state.grid[10] + state.grid[11];
        //NBSeedPlayer = state.grid[0] + state.grid[1] + state.grid[2] + state.grid[3] + state.grid[4] + state.grid[5];     

        return state.scoreAI - state.scorePlayer;
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

    public bool useDepth()
    {
        return true;
    }

    public int getDepth()
    {
        return 12;
    }

}

/* 11 10 9  8  7  6
    0  1 2  3  4  5*/
public class StateAwale
{
    public int player;
    public int[] grid;
    public int scoreAI;
    public int scorePlayer;

    // Constructeur par défaut
    public StateAwale()
    {
        this.player = 1;
        this.grid = null;
        this.scoreAI = 0;
        this.scorePlayer = 0;
    }
}
