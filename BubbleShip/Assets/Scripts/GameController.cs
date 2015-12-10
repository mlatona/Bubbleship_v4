using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController{

	public static GameController _instance = null;

	BubbleMatrix bubbleMatrix;

	public static GameController Instance() { 
		
		if (_instance==null)
		{
			_instance=new GameController() ;
			
		}
		return _instance;
	}

	public GameController() {
		Debug.Log("Starts GameController ");
		bubbleMatrix = new BubbleMatrix ();
	}

	public void insert (GameObject bubbleObj, bool substract)
	{
		bubbleMatrix.insert (bubbleObj, substract);
	}

	public void destroyBubbles(GameObject bubbleObj){
		//get neighbours and destroy if its necesary
		Hashtable sameColorConeectedBubbles = new Hashtable ();
		Bubble bubbleScript = bubbleObj.gameObject.GetComponent<Bubble> ();
		Vector3 rowCol = bubbleScript.rowCol;
		sameColorConeectedBubbles.Add ("x:" + rowCol.x + ", y:" + rowCol.y, bubbleObj);
		int sameColor = 1 + destroyBubbles 
			(sameColorConeectedBubbles, bubbleMatrix.getNeighbours (bubbleScript, bubbleObj.transform.localPosition), bubbleObj);
		//if there are three with the same color

		if (sameColor > 2) {
			foreach (GameObject bubbleConnectedObj in sameColorConeectedBubbles.Values) {
				//Destroy
				if(bubbleConnectedObj==null){
					continue;
				}

				destroy(bubbleConnectedObj);
			}
		}
	}

	public void destroy(GameObject bubbleObj){
		Bubble bubbleScript = bubbleObj.gameObject.GetComponent<Bubble> ();
		if (bubbleScript == null)
			return;
		Vector3 rowCol = bubbleScript.rowCol;
		bubbleMatrix.remove("x:" + rowCol.x + ", y:" + rowCol.y);
		bubbleScript.destroy();
	}

	private int destroyBubbles(Hashtable list, GameObject[] neighbours, GameObject parentBubbleObj){
		int sameColor = 0;
		foreach (GameObject neighbour in neighbours) {

			if (neighbour == null) {
				continue;
			}
			//Debug.Log(neighbour.transform.localPosition+"neightbour:_"+parentBubbleObj.transform.localPosition);	
			Bubble neighbourBubble = neighbour.gameObject.GetComponent<Bubble> ();
			Bubble parentBubble = parentBubbleObj.gameObject.GetComponent<Bubble> ();
			Vector3 rowCol = neighbourBubble.rowCol;
			if (neighbourBubble.bubbleColor == parentBubble.bubbleColor
			    && !list.ContainsKey("x:" + rowCol.x + ", y:" + rowCol.y)) {

				list.Add("x:" + rowCol.x + ", y:" + rowCol.y,neighbour);

				sameColor += 1 + destroyBubbles(list, bubbleMatrix.getNeighbours (neighbourBubble, neighbour.transform.localPosition), neighbour);
				//Debug.Log(sameColor);
			}
		}
		return sameColor;
	}
	/** Destruye solo UNA Bubble
	 *  Autor: Richard
	 */
	public void destroy_one_bubble(GameObject bubbleObj){
		Bubble bubbleScript = bubbleObj.gameObject.GetComponent<Bubble> ();
		if (bubbleScript == null)
			return;
		/*
		Vector3 rowCol = bubbleScript.rowCol;
		bubbleMatrix.remove("x:" + rowCol.x + ", y:" + rowCol.y);
		*/
		bubbleScript.destroy();
	}
}
