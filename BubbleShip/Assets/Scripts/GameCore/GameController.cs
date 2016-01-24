using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController{

	public static GameController _instance = null;

	static int sizeSp = 3;
	BubbleMatrix bubbleMatrix;
	public bool paused = false;
	int totalScore;
	int[] bubbleSp;
	int bubbleSpIn;
	ArrayList visibles;

	public static GameController Instance() { 
		
		if (_instance==null)
		{
			_instance=new GameController() ;
			
		}
		return _instance;
	}

	public void resetGame(){
		_instance = null;
	}

	public GameController() {
		//Debug.Log("Starts GameController ");
		bubbleMatrix = new BubbleMatrix ();
		totalScore = 0;
		bubbleSp = new int[sizeSp];
		for(int i=0;i<sizeSp;i++){
			bubbleSp[i] = -1;
		}
		bubbleSpIn = 0;
		visibles = new ArrayList ();
	}

	public void insert (GameObject bubbleObj, bool substract)
	{
		bubbleMatrix.insert (bubbleObj, substract);
	}

	public Vector3 getRowCol(Vector3 pos){
		return bubbleMatrix.calcColAndRow (pos);
	}

	public Vector3 correctPosition(Vector3 pos, Vector3 rowCol){
		return bubbleMatrix.moveToCorrectPosition (pos, rowCol);
	}

	public GameObject[] getNeighbours(Vector3 rowCol){
		return bubbleMatrix.getNeighbours (rowCol);
	}

	public void destroyBubbles (GameObject[] bubbles)
	{
		foreach (GameObject bubbleConnectedObj in bubbles) {
			//Destroy
			if (bubbleConnectedObj == null) {
				continue;
			}
			Debug.Log (bubbleConnectedObj.name);
			destroy (bubbleConnectedObj);
		}
	}

	public void destroyBubbles(GameObject bubbleObj){
		//get neighbours and destroy if its necesary
		Hashtable sameColorConeectedBubbles = new Hashtable ();
		IBubbleMatrix bubbleScript = bubbleObj.gameObject.GetComponent<IBubbleMatrix> ();
		Vector3 rowCol = bubbleScript.GetRowCol();
		sameColorConeectedBubbles.Add ("x:" + rowCol.x + ", y:" + rowCol.y, bubbleObj);
		int sameColor = 1 + destroyBubbles 
			(sameColorConeectedBubbles, bubbleMatrix.getNeighbours (bubbleScript, bubbleObj.transform.localPosition), bubbleObj);
		//if there are three with the same color
		//Debug.Log (rowCol+"GameController SameColor: " + sameColor);
		if (sameColor > 2) {
			foreach (GameObject bubbleConnectedObj in sameColorConeectedBubbles.Values) {
				//Destroy
				if (bubbleConnectedObj == null) {
					continue;
				}
				Debug.Log (bubbleConnectedObj.name);
				destroy (bubbleConnectedObj);
			}
		}
	}

	public void destroy(GameObject bubbleObj){
		IKillable killable = bubbleObj.gameObject.GetComponent<IKillable> ();
		IBubbleMatrix bubbleOnMatrix = bubbleObj.gameObject.GetComponent<IBubbleMatrix> ();
		if (bubbleOnMatrix == null)
			return;
		Vector3 rowCol = bubbleOnMatrix.GetRowCol();
		bubbleMatrix.remove("x:" + rowCol.x + ", y:" + rowCol.y);
		if(killable != null)
			killable.Kill();
	}

	private int destroyBubbles(Hashtable list, GameObject[] neighbours, GameObject parentBubbleObj){
		int sameColor = 0;
		foreach (GameObject neighbour in neighbours) {

			if (neighbour == null) {
				continue;
			}
			//Debug.Log(neighbour.transform.localPosition+"neightbour:_"+parentBubbleObj.transform.localPosition);	
			IBubbleMatrix neighbourBubble = neighbour.gameObject.GetComponent<IBubbleMatrix> ();
			IBubbleMatrix parentBubble = parentBubbleObj.gameObject.GetComponent<IBubbleMatrix> ();
			Vector3 rowCol = neighbourBubble.GetRowCol();
			if (neighbourBubble.GetBubbleColor() == parentBubble.GetBubbleColor()
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

	public void Score(int scoreParam){
		totalScore += scoreParam;
	}

	public int GetTotalScore(){
		return totalScore;
	}

	public void AddSp (int typeSp)
	{
		for(int i=0;i<bubbleSpIn;i++)
			Debug.Log ("GameController_AddSP bubbleSP["+i+"]="+bubbleSp[i]);
		if(bubbleSpIn < sizeSp){
			bubbleSp[bubbleSpIn] = typeSp;
			bubbleSpIn++;
		}
		Debug.Log ("GameController_AddSP bubbleSPIn="+bubbleSpIn);
	}

	public int GetSp(){
		if (bubbleSpIn == 0) {
			return -1;
		}
		int toReturn = bubbleSp [0];
		for(int i=bubbleSpIn-1;i>0;i--){
			bubbleSp[i-1] = bubbleSp[i];
		}
		bubbleSp[bubbleSpIn-1] = -1;
		for(int i=0;i<bubbleSpIn;i++)
			Debug.Log ("GameController_AddSP bubbleSP["+i+"]="+bubbleSp[i]);
		bubbleSpIn--;
		return toReturn;
	}

	public int[] hasSp(){
		return bubbleSp;
	}

	public void addVisible(BubbleObj a){
		visibles.Add (a);
	}
	public ArrayList getVisibles(){
		return visibles;
	}
}
