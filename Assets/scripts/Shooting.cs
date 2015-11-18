using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public GameObject[] bulletObj;
	public Sprite[] tubeSprites;
	public Sprite[] playerSprites;

	SpriteRenderer playerRenderer;
	SpriteRenderer tubeRenderer;

	float shootFreq = 0.1f;
	float shootTime = 1f;
	int curSpriteIndex;
	ColorType.ItemColor[] colorID;
	
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
				
				GameObject clone;
				clone = Instantiate (bulletObj[curSpriteIndex], 
				                     transform.position, 
				                     Quaternion.identity) as GameObject;

				clone.GetComponent<Rigidbody2D> ().velocity = new Vector2 (10f, 0f);
				Destroy (clone, 3f);
			} else { 
				shootTime += Time.deltaTime / 4f;
			}
		} else {
			shootTime = 1f;
		}

		if (Input.GetMouseButtonDown (1)) {
			curSpriteIndex++;
			curSpriteIndex = curSpriteIndex % bulletObj.Length;

			playerRenderer.sprite = playerSprites[curSpriteIndex];
			tubeRenderer.sprite = tubeSprites[curSpriteIndex];
		}
	}
}
