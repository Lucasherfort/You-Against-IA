using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puissance4 : Game<StatePuissance4,int,int>
{
    StatePuissance4 state = new StatePuissance4();

    public Puissance4()
    {
        state.player = 1;
        state.grid = new Color[42];
    }
    public StatePuissance4 getInitialState()
    {
        return state;
    }

    public int getPlayer(StatePuissance4 state)
    {
        return(state.player);
    }

    public List<int> getActions(StatePuissance4 state)
    {
        List<int> actions = new List<int>();

        for(int i = 35 ; i >= 0 ; i = i - 7)
        {
            if(state.grid[i] == Color.clear)
            {
                actions.Add(i);
                break;
            }
        }

        // 2ème colonne
        for(int i = 36 ; i >= 1 ; i = i - 7)
        {
            if(state.grid[i] == Color.clear)
            {
                actions.Add(i);
                break;
            }
        }

        // 3ème colonne
        for(int i = 37 ; i >= 2 ; i = i - 7)
        {
            if(state.grid[i] == Color.clear)
            {
                actions.Add(i);
                break;
            }
        }

        // 4ème colonne
        for(int i = 38 ; i >= 3 ; i = i - 7)
        {
            if(state.grid[i] == Color.clear)
            {
                actions.Add(i);
                break;
            }
        }

        // 5ème colonne
        for(int i = 39 ; i >= 4 ; i = i - 7)
        {
            if(state.grid[i] == Color.clear)
            {
                actions.Add(i);
                break;
            }
        }

        // 6ème colonne
        for(int i = 40 ; i >= 5 ; i = i - 7)
        {
            if(state.grid[i] == Color.clear)
            {
                actions.Add(i);
                break;
            }
        }

        // 7ème colonne
        for(int i = 41 ; i >= 6 ; i = i - 7)
        {
            if(state.grid[i] == Color.clear)
            {
                actions.Add(i);
                break;
            }
        }

        return (actions);
    }

    public StatePuissance4 getResult(StatePuissance4 state, int action)
    {
        StatePuissance4 newState = new StatePuissance4();

        newState.grid = (Color[])state.grid.Clone();

        if(state.player == 1)
        {
            newState.grid[action] = Color.yellow;
        }
        else
        {
            newState.grid[action] = Color.red;
        }

        newState.player = 1 - state.player;

        return(newState);
    }

    public bool isTerminal(StatePuissance4 state)
    {
        // Ligne 1
        for(int i = 0 ; i < 4 ; i++)
        {
            if(FourEqualColors(state.grid[i],state.grid[i+1],state.grid[i+2],state.grid[i+3]))
            {
                return true;
            }
        }

        // Ligne 2
        for(int i = 7 ; i < 11 ; i++)
        {
            if(FourEqualColors(state.grid[i],state.grid[i+1],state.grid[i+2],state.grid[i+3]))
            {
                return true;
            }
        }

        // Ligne 3
        for(int i = 14 ; i < 18 ; i++)
        {
            if(FourEqualColors(state.grid[i],state.grid[i+1],state.grid[i+2],state.grid[i+3]))
            {
                return true;
            }
        }

        // Ligne 4
        for(int i = 21 ; i < 25 ; i++)
        {
            if(FourEqualColors(state.grid[i],state.grid[i+1],state.grid[i+2],state.grid[i+3]))
            {
                return true;
            }
        }

        // Ligne 5
        for(int i = 28 ; i < 32 ; i++)
        {
            if(FourEqualColors(state.grid[i],state.grid[i+1],state.grid[i+2],state.grid[i+3]))
            {
                return true;
            }
        }

        // Ligne 6
        for(int i = 35 ; i < 39 ; i++)
        {
            if(FourEqualColors(state.grid[i],state.grid[i+1],state.grid[i+2],state.grid[i+3]))
            {
                return true;
            }
        }

        // Colonne 1
        for(int i = 0 ; i < 15 ; i += 7)
        {
            if(FourEqualColors(state.grid[i],state.grid[i+7],state.grid[i+14],state.grid[i+21]))
            {
                return true;
            }
        }

        // Colonne 2
        for(int i = 1 ; i < 16 ; i += 7)
        {
            if(FourEqualColors(state.grid[i],state.grid[i+7],state.grid[i+14],state.grid[i+21]))
            {
                return true;
            }
        }

        // Colonne 3
        for(int i = 2 ; i < 17 ; i += 7)
        {
            if(FourEqualColors(state.grid[i],state.grid[i+7],state.grid[i+14],state.grid[i+21]))
            {
                return true;
            }
        }

        // Colonne 4
        for(int i = 3 ; i < 18 ; i += 7)
        {
            if(FourEqualColors(state.grid[i],state.grid[i+7],state.grid[i+14],state.grid[i+21]))
            {
                return true;
            }
        }

        // Colonne 5
        for(int i = 4 ; i < 19 ; i += 7)
        {
            if(FourEqualColors(state.grid[i],state.grid[i+7],state.grid[i+14],state.grid[i+21]))
            {
                return true;
            }
        }

        // Colonne 6
        for(int i = 5 ; i < 20 ; i += 7)
        {
            if(FourEqualColors(state.grid[i],state.grid[i+7],state.grid[i+14],state.grid[i+21]))
            {
                return true;
            }
        }

        // Colonne 7
        for(int i = 6 ; i < 21 ; i += 7)
        {
            if(FourEqualColors(state.grid[i],state.grid[i+7],state.grid[i+14],state.grid[i+21]))
            {
                return true;
            }
        }

        // Diagonale Montante 1
        for(int i = 21 ; i < 25 ; i ++)
        {
            if(FourEqualColors(state.grid[i],state.grid[i-6],state.grid[i-12],state.grid[i-18]))
            {
                return true;
            }
        }

        // Diagonale Montante 2
        for(int i = 28 ; i < 32 ; i ++)
        {
            if(FourEqualColors(state.grid[i],state.grid[i-6],state.grid[i-12],state.grid[i-18]))
            {
                return true;
            }
        }

        // Diagonale Montante 3
        for(int i = 35 ; i < 39 ; i ++)
        {
            if(FourEqualColors(state.grid[i],state.grid[i-6],state.grid[i-12],state.grid[i-18]))
            {
                return true;
            }
        }

        // Diagonale Descendante 1
        for(int i = 0 ; i < 4 ; i ++)
        {
            if(FourEqualColors(state.grid[i],state.grid[i+8],state.grid[i+16],state.grid[i+24]))
            {
                return true;
            }
        }
        
        // Diagonale Descendante 2
        for(int i = 7 ; i < 11 ; i ++)
        {
            if(FourEqualColors(state.grid[i],state.grid[i+8],state.grid[i+16],state.grid[i+24]))
            {
                return true;
            }
        }

        // Diagonale Descendante 3
        for(int i = 14 ; i < 18 ; i ++)
        {
            if(FourEqualColors(state.grid[i],state.grid[i+8],state.grid[i+16],state.grid[i+24]))
            {
                return true;
            }
        }

        if(getActions(state).Count == 0)
        {
            return true;
        }

        return false;
    }

    public int getUtility(StatePuissance4 state, int player)
    {
        /* Alignement d'une couleur  +1 
        2 couleurs +5
        3 couleurs 50
        4 couleurs 1000
        */

        int score = 0;

        // Ligne 1
        for(int i = 0 ; i < 4 ; i++)
        {
            score += EvaluateState(state,i,i+1,i+2,i+3);
        }

        // Ligne 2
        for(int i = 7 ; i < 11 ; i++)
        {
            score += EvaluateState(state,i,i+1,i+2,i+3);
        }

        // Ligne 3
        for(int i = 14 ; i < 18 ; i++)
        {
            score += EvaluateState(state,i,i+1,i+2,i+3);
        }

        // Ligne 4
        for(int i = 21 ; i < 25 ; i++)
        {
            score += EvaluateState(state,i,i+1,i+2,i+3);
        }

        // Ligne 5
        for(int i = 28 ; i < 32 ; i++)
        {
            score += EvaluateState(state,i,i+1,i+2,i+3);
        }

        // Ligne 6
        for(int i = 35 ; i < 39 ; i++)
        {
            score += EvaluateState(state,i,i+1,i+2,i+3);
        }

        // Colonne 1
        for(int i = 0 ; i < 15 ; i += 7)
        {
            score += EvaluateState(state,i,i+7,i+14,i+21);
        }

        // Colonne 2
        for(int i = 1 ; i < 16 ; i += 7)
        {
            score += EvaluateState(state,i,i+7,i+14,i+21);
        }

        // Colonne 3
        for(int i = 2 ; i < 17 ; i += 7)
        {
            score += EvaluateState(state,i,i+7,i+14,i+21);
        }

        // Colonne 4
        for(int i = 3 ; i < 18 ; i += 7)
        {
            score += EvaluateState(state,i,i+7,i+14,i+21);
        }

        // Colonne 5
        for(int i = 4 ; i < 19 ; i += 7)
        {
            score += EvaluateState(state,i,i+7,i+14,i+21);
        }

        // Colonne 6
        for(int i = 5 ; i < 20 ; i += 7)
        {
            score += EvaluateState(state,i,i+7,i+14,i+21);
        }

        // Colonne 7
        for(int i = 6 ; i < 21 ; i += 7)
        {
            score += EvaluateState(state,i,i+7,i+14,i+21);
        }

        // Diagonale Montante 1
        for(int i = 21 ; i < 25 ; i ++)
        {
            score += EvaluateState(state,i,i-6,i-12,i-18);
        }

        // Diagonale Montante 2
        for(int i = 28 ; i < 32 ; i ++)
        {
            score += EvaluateState(state,i,i-6,i-12,i-18);
        }

        // Diagonale Montante 3
        for(int i = 35 ; i < 39 ; i ++)
        {
            score += EvaluateState(state,i,i-6,i-12,i-18);
        }

        // Diagonale Descendante 1
        for(int i = 0 ; i < 4 ; i ++)
        {
            score += EvaluateState(state,i,i+8,i+16,i+24);
        }
        
        // Diagonale Descendante 2
        for(int i = 7 ; i < 11 ; i ++)
        {
            score += EvaluateState(state,i,i+8,i+16,i+24);
        }

        // Diagonale Descendante 3
        for(int i = 14 ; i < 18 ; i ++)
        {
            score += EvaluateState(state,i,i+8,i+16,i+24);
        }

        return score;
    }

    public int EvaluateState(StatePuissance4 state, int a, int b, int c, int d)
    {
        int score = 0;
        int nbRouge = 0;
        int nbJaune = 0;
        int empty = 0;

        if(state.grid[a] == Color.yellow)
        {
            nbJaune++;
        }
        else if (state.grid[a] == Color.red)
        {
            nbRouge++;
        }
        else
        {
            empty++;
        }

        if(state.grid[b] == Color.yellow)
        {
            nbJaune++;
        }
        else if (state.grid[b] == Color.red)
        {
            nbRouge++;
        }
        else
        {
            empty++;
        }

        if(state.grid[c] == Color.yellow)
        {
            nbJaune++;
        }
        else if (state.grid[c] == Color.red)
        {
            nbRouge++;
        }
        else
        {
            empty++;
        }

        if(state.grid[d] == Color.yellow)
        {
            nbJaune++;
        }
        else if (state.grid[d] == Color.red)
        {
            nbRouge++;
        }
        else
        {
            empty++;
        }

        /* Attribution du score en fonction des valeurs */

        if(empty == 4)
        {
            score = 0;
        }
        else if(nbJaune == 1 && empty==3)
        {
            score = -1;
        }
        else if(nbJaune == 2 && empty==2)
        {
            score = -10;
        }

        else if(nbJaune == 3 && empty==1)
        {
            score = -1000;
        }

        else if(nbJaune == 4)
        {
            score = -10000;
        }

        else if(nbRouge == 1 && empty==3)
        {
            score = 1;
        }
        else if(nbRouge == 2 && empty==2)
        {
            score = 10;
        }

        else if(nbRouge == 3 && empty==1)
        {
            score = 1000;
        }

        else if(nbRouge == 4)
        {
            score = 10000;
        }
        
        return score;
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
        return 4;
    }

    private bool FourEqualColors(Color a, Color b, Color c, Color d) 
    {
        return (a == b && b == c && c == d) && a != Color.clear;
    }
}

/* 1 = jaune et 0 = rouge*/
public class StatePuissance4
{
    public int player;
    public Color[] grid;


    // Constructeur par défaut
    public StatePuissance4()
    {
        this.player = 1;
        this.grid = null;
    }
}
