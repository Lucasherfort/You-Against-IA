using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTT : Game<StateTTT,int,int>
{
    StateTTT state = new StateTTT();

    public TTT()
    {
        state.player = 1;
        state.grid = new string[9];
    }

    public StateTTT getInitialState()
    {
        return state;
    }

    public int getPlayer(StateTTT state)
    {
        return(state.player);
    }

    public List<int> getActions(StateTTT state)
    {
        List<int> actions = new List<int>();

        for(int i=0; i < 9; i++)
        {
            if(state.grid[i] == null)
            {
                actions.Add(i);
            }
        }
    
        return (actions);
    }

    public StateTTT getResult(StateTTT state, int action)
    {
        StateTTT newState = new StateTTT();

        newState.grid = (string[])state.grid.Clone();

        if(state.player == 1)
        {
            newState.grid[action] = "X";
        }
        else
        {
            newState.grid[action] = "O";
        }

        // Changement de joueur
        newState.player = 1 - state.player;

        return(newState);
    }

    public bool isTerminal(StateTTT state)
    {
        if(ThreeEqualSymbols(state.grid[0],state.grid[1],state.grid[2]))
        {
            return true;
        }

        if(ThreeEqualSymbols(state.grid[3],state.grid[4],state.grid[5]))
        {
            return true;
        }

        if(ThreeEqualSymbols(state.grid[6],state.grid[7],state.grid[8]))
        {
            return true;
        }

        if(ThreeEqualSymbols(state.grid[0],state.grid[3],state.grid[6]))
        {
            return true;
        }

        if(ThreeEqualSymbols(state.grid[1],state.grid[4],state.grid[7]))
        {
            return true;
        }

        if(ThreeEqualSymbols(state.grid[2],state.grid[5],state.grid[8]))
        {
            return true;
        }

        if(ThreeEqualSymbols(state.grid[0],state.grid[4],state.grid[8]))
        {
            return true;
        }

        if(ThreeEqualSymbols(state.grid[2],state.grid[4],state.grid[6]))
        {
            return true;
        }

        if(getActions(state).Count == 0)
        {
            return true;
        }

        return false;
    }

    public int getUtility(StateTTT state, int player)
    {
        int score = 0;
        // Evaluate score for each of the 8 lines (3 rows, 3 columns, 2 diagonals)
        score += evaluateLine(state, 0, 1, 2);  // row 0
        score += evaluateLine(state, 3, 4, 5);  // row 1
        score += evaluateLine(state, 6, 7, 8);  // row 2
        score += evaluateLine(state, 0, 3, 6);  // col 0
        score += evaluateLine(state, 1, 4, 7);  // col 1
        score += evaluateLine(state, 2, 5, 8);  // col 2
        score += evaluateLine(state, 0, 4, 8);  // diagonal
        score += evaluateLine(state, 2, 4, 8);  // alternate diagonal
        
        return score;
    }

    public int evaluateLine(StateTTT state, int cell1, int cell2, int cell3)
    {
        int score = 0;
        int nbX = 0;
        int nbO = 0;
        int empty = 0;

        if(state.grid[cell1] == "O")
        {
            nbO++;
        }
        else if(state.grid[cell1] == "X")
        {
            nbX++;
        }
        else
        {
            empty++;
        }

        if(state.grid[cell2] == "O")
        {
            nbO++;
        }
        else if(state.grid[cell2] == "X")
        {
            nbX++;
        }
        else
        {
            empty++;
        }

        if(state.grid[cell3] == "O")
        {
            nbO++;
        }
        else if(state.grid[cell3] == "X")
        {
            nbX++;
        }
        else
        {
            empty++;
        }

        if(nbO == 3)
        {
            score = 100;
        }

        if(nbO==2 && empty == 0)
        {
            score = 10;
        }
        if(nbO==1 && empty == 2)
        {
            score = 1;
        }

        if(nbX == 3)
        {
            score = -100;
        }

        if(nbX==2 && empty == 0)
        {
            score = -10;
        }
        if(nbX==1 && empty == 2)
        {
            score = -1;
        }

        return score;
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
        return 2;
    }

    private bool ThreeEqualSymbols(string a, string b, string c) // Checks if there is 3 equal values and no blanks
    {
        return (a == b && b == c) && a != null;
    }
}

public class StateTTT
{
    public int player;
    public string[] grid;

    public StateTTT()
    {
        this.player = 0;
        this.grid = null;
    }
}
