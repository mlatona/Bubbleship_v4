using UnityEngine;
using System.Collections;

public class BubbleObj : MonoBehaviour, IBubbleMatrix
{

	public Vector3 rowCol;
	GameController gameController;
	IEnemyType enemyType;
	Animator animator;
	public Enums.BUBBLECOLOR staticBubbleColor;
	[HideInInspector] public Enums.BUBBLECOLOR bubbleColor;
	void Awake ()
	{
		enemyType = GetComponent<IEnemyType> ();
		animator = GetComponent<Animator>();
		gameController = GameController.Instance ();
	}

	public void changeColor(int bubbleColorParam){
		animator.SetInteger("color",bubbleColorParam);
	}

	public int GetColor(){
		return animator.GetInteger ("color");
	}

	// Use this for initialization
	void Start ()
	{	
		changeColor ((int)bubbleColor);
		if (enemyType !=null && enemyType.Get()==Enums.OWNER.ANY) {
			gameController.insert (gameObject, false);
			bubbleColor = staticBubbleColor;
		}
	}

	void Update(){
		if(GetColor() != -1){
			changeColor ((int)bubbleColor);
		}
	}


	#region IBubbleMatrix implementation
	public Vector3 GetRowCol(){ return rowCol;}
	public void SetRowCol(Vector3 rowColParam){rowCol = rowColParam;}
	
	public Enums.BUBBLECOLOR GetBubbleColor(){return bubbleColor;}
	public void SetBubbleColor(Enums.BUBBLECOLOR bubbleColorParam){bubbleColor = bubbleColorParam;}
	#endregion
}
