using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipSpFireCommand : MonoBehaviour, ICommand{

	GameController gameController;
	public GameObject[] typeSp;
	public Vector3 added;
	public Vector3 speed;

	// Use this for initialization
	void Start () {
		gameController = GameController.Instance ();
	}
	
	// Update is called once per frame
	void Update () {
		int i = 0;
		foreach (int a in gameController.hasSp ()) {
			Image image = GameObject.FindGameObjectWithTag("Sp"+i).GetComponent<Image>();
			if (a != -1) {
				//Debug.Log(i);
				image.sprite = typeSp[a].GetComponent<SpriteRenderer>().sprite;
			}else{
				image.sprite = null;
			}
			i++;
		}
	}

	#region ICommand implementation
	public void Run ()
	{
		int typeSpI = gameController.GetSp();
		if(typeSpI != -1){
			GameObject b = 
				Instantiate(typeSp[typeSpI], transform.position + added, transform.rotation) as GameObject;
			b.transform.parent = gameObject.transform.parent;
			b.GetComponent<IMoveable> ().SetSpeed (speed);
			b.GetComponent<IEnemyType> ().Set (Enums.OWNER.ISNOTENEMY);
		}
	}
	#endregion
}
