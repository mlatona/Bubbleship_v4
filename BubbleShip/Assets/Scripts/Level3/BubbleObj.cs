using UnityEngine;
using System.Collections;

public class BubbleObj : MonoBehaviour, ICollisionable, IBubbleMatrix
{
	
	public bool isEnemy = false;
	public bool playerFired = false, oneContact=false;
	public Vector3 speed, direction, rowCol;
	GameController gameController;

	public Enums.BUBBLECOLOR bubbleColor;
	public Sprite[] typeBubbles;

	void Awake ()
	{
		if (!playerFired) {
			speed = new Vector3 (0, 0, 0);
		}
		direction = new Vector3 (1, 1, 0);
		gameController = GameController.Instance ();
		changeColor ((int)bubbleColor);
	}

	public void changeColor(int bubbleCol){
		GetComponent<SpriteRenderer> ().sprite = typeBubbles [bubbleCol];
	}

	// Use this for initialization
	void Start ()
	{
		//Debug.Log ("Antes="+transform.localPosition);
		//Debug.Log ("Ahora="+GameController.Instance().moveToCorrectPosition(transform.localPosition));

		//Debug.Log ("PlayerFired: "+playerFired);
		if (!playerFired)
			gameController.insert (gameObject, false);
			//transform.localPosition = gameController.moveToCorrectPosition (transform.localPosition, false);
		//else Debug.Log ("Speed:"+speed);
	}
		
	// Update is called once per frame
	void Update ()
	{

	}

	/**
	 * Implements ICollisionable
	 * We can attend there a collision, it is depending the object that collided
	 */
	public void CollideWithBubble(GameObject collideObject){
		IMoveable moveable = GetComponent<IMoveable> ();
		if (moveable != null) {
			moveable.SetSpeed(Vector3.zero);
			gameController.insert (gameObject, true);
			gameController.destroyBubbles (gameObject);
		}
	}
	public void CollideWithSpaceShip(GameObject collideObject){
		GetComponent<IDamageable> ().Damage (collideObject.GetComponent<IDamageable>().GetDamageTaken());
	}

	/**
	 * Implements IBubbleMatrix, because it wants to be in the matrix
	 * 
	 * */
	public Vector3 GetRowCol(){ return rowCol;}
	public void SetRowCol(Vector3 rowColParam){rowCol = rowColParam;}
	
	public Enums.BUBBLECOLOR GetBubbleColor(){return bubbleColor;}
	public void SetBubbleColor(Enums.BUBBLECOLOR bubbleColorParam){bubbleColor = bubbleColorParam;}

}
