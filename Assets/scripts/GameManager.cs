﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static int totalScore = 0;
	public static int redEnemies = 0;
	public static int blueEnemies = 0;
	public static int greenEnemies = 0;
	public static int orangeEnemies = 0;

	void Start() {
		/*GetComponent<GameplayMenus> ().SetComponentsState (false);
		GetComponent<GameOverMenu> ().SetComponentsState (false);
		GetComponent<HelpMenu> ().SetComponentsState (true);*/

		ResetValues ();
	}
 
	public static void ResetValues() {
		totalScore = 0;
		redEnemies = 0;
		blueEnemies = 0;
		greenEnemies = 0;
		orangeEnemies = 0;
	}
}
