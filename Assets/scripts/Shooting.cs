using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public GameObject[] bulletObj;
	public Sprite[] tubeSprites;
	public Sprite[] playerSprites;
	public ParticleSystem[] shootParticles;

	SpriteRenderer playerRenderer;
	SpriteRenderer tubeRenderer;

	float shootFreq = 0.1f;
	float shootTime = 1f;
	int curSpriteIndex;
	
	void Start () {
		curSpriteIndex = 0;

		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		GameObject tube = GameObject.FindGameObjectWithTag ("Tube");

		playerRenderer = player.GetComponent<SpriteRenderer> ();
		tubeRenderer = tube.GetComponent<SpriteRenderer> ();
	}

	void Update () {
		if (Input.GetMouseButton (0)) {
			if (shootTime > shootFreq) {
				shootTime = 0f;

				// Instantiate bullet object and make it moving
				GameObject clone;
				clone = Instantiate (bulletObj[curSpriteIndex], 
				                     transform.position, 
				                     Quaternion.identity) as GameObject;

				clone.GetComponent<Rigidbody2D> ().velocity = new Vector2 (10f, 0f);
				Destroy (clone, 3f);

				PlayShootParticles (shootParticles[curSpriteIndex]);
			} else { 
				shootTime += Time.deltaTime / 4f;
			}
		} else {
			shootTime = 1f;
		}

		// If right mouse button pressed
		if (Input.GetMouseButtonDown (1)) {
			curSpriteIndex++;
			curSpriteIndex = curSpriteIndex % bulletObj.Length;

			// Change player and tube skins 
			playerRenderer.sprite = playerSprites[curSpriteIndex];
			tubeRenderer.sprite = tubeSprites[curSpriteIndex];
		}
	}

	void PlayShootParticles(ParticleSystem shootParticles) {
		shootParticles.playOnAwake = true;
		shootParticles.Play ();
	}
}
