using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using Random=UnityEngine.Random;

public class Spaceship : MonoBehaviour {

	//velocidad
	public Vector2 speed = new Vector2(0.8f, 0.5f);

	public GameObject bubble;
	public float timeLapsedLastFire = 0;
	private Bubble.BUBBLECOLOR actualBubble, nextBubble;
	Bubble bScript;

	void Awake(){

		bScript = bubble.GetComponent<Bubble> ();
		actualBubble = getRandomBubbleColor();
		nextBubble = getRandomBubbleColor();
		updateBubbles ();
	}

	private Bubble.BUBBLECOLOR getRandomBubbleColor(){
		return (Bubble.BUBBLECOLOR)Random.Range(0, 4);
	}



	// Update is called once per frame
	void Update () {

		float inputX = Input.GetAxis ("Horizontal");
		//float inputY = Input.GetAxis ("Vertical");

		Vector3 tmp = new Vector3 (speed.x * inputX, speed.y , 0);

		Vector3 movement = tmp * Time.deltaTime;
		transform.Translate (movement);

		movement.x = 0;
		Camera.main.transform.Translate(movement);

		timeLapsedLastFire += Time.deltaTime;
		bool fire = Input.GetButton ("Fire1");
		if (fire && timeLapsedLastFire>0.5) {

			timeLapsedLastFire = 0;

			bScript.playerFired = true;
			Vector3 mousePos = Input.mousePosition;
			mousePos.z = 59;
			Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePos);
			//Debug.Log("World:"+worldMousePosition+"Mouse:"+Input.mousePosition);

			Vector3 direction = worldMousePosition - (transform.position + new Vector3(0,1,0));
			//float angle = Mathf.Atan2(direction.y, direction.x);

			//Debug.Log(""+direction);
			bScript.speed = direction;
			bScript.bubbleColor = actualBubble;

			GameObject b = Instantiate(bubble, transform.position+ new Vector3(0,(float) 1.8,0), transform.rotation) as GameObject;

			//ShootedBubble shootedBubble = new ShootedBubble(direction);


			b.AddComponent<CircleCollider2D>();

			//ShootedBubble shootedBubble = b.AddComponent<ShootedBubble>();
			//shootedBubble.SettingDirection(direction);

			b.transform.parent = transform.parent;

			actualBubble = nextBubble;
			nextBubble = getRandomBubbleColor();
			updateBubbles();
		}

	}

	void updateBubbles(){ 
		GameObject.FindGameObjectWithTag("ActualBubble")
			.GetComponent<SpriteRenderer> ().sprite = bScript.typeBubbles[(int)actualBubble];
		GameObject.FindGameObjectWithTag("NextBubble")
			.GetComponent<SpriteRenderer> ().sprite = bScript.typeBubbles[(int)nextBubble];
	}
}
