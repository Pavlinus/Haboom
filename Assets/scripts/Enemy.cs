using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public ColorType.ItemColor color;
	public int score;

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag.Equals ("Bullet")) {
			Bullet bullet = collider.gameObject.GetComponent<Bullet> ();

			if (bullet.GetItemColor ().Equals (color)) {
				GameManager.totalScore += score;
				Destroy (gameObject);
			}
		
		} else if (collider.tag.Equals ("GameOver")) {
			Time.timeScale = 0f;

			// Show game over menu
		}
	}
}
