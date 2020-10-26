using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Game<STATE, ACTION, PLAYER>
{
    // renvoie l’ ́etat initial du jeu
	STATE getInitialState();

	// renvoie le joueur actif d’un  ́etat donné
	PLAYER getPlayer(STATE state);

	// renvoie la liste des actions possibles pour un ́Etat donné
	List<ACTION> getActions(STATE state);

	// renvoie l’ ́etat r ́esultant de l’ex ́ecution d’une action donn ́ee sur un  ́etat donné
	STATE getResult(STATE state, ACTION action);

	//  ́Verifie si un ́Etat est en phase terminale
	bool isTerminal(STATE state);

	// Retourne la valeur d’utilit ́e d’un  ́etat donné
	int getUtility(STATE state, PLAYER player);

	// Retourne true si le joueur est le joueur Max, false si c’est le joueur Min
    bool isMax( PLAYER player);

	// Retourne vrai si on veut limiter la profondeur d'exploration 
	bool useDepth();

	// Retourne le profondeur maximale dans le cas d’une recherche `a profondeur limitée
    int getDepth();
}
