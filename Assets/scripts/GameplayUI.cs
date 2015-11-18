using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameplayUI : MonoBehaviour {

	public Text totalScore;
	public Text enemyPoints;
	
	void Start () {
		
	}

	void Update () {
		totalScore.text = "Score " + GameManager.totalScore;
	}
}
