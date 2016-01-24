using UnityEngine;
using System.Collections;

public class FireCommand : MonoBehaviour, ICommand {

	public Vector3 speed;
	public Vector3 added;
	public GameObject objectFire;
	Enums.OWNER enemyType;

	void Start(){
		enemyType = GetComponent<IEnemyType> ().Get();
	}

	public void Run(){
		GameObject b = 
			Instantiate(objectFire, transform.position + added, transform.rotation) as GameObject;
		b.transform.parent = gameObject.transform.parent;
		b.transform.eulerAngles = Vector3.zero;
		b.GetComponent<IMoveable> ().SetSpeed (speed);
		Debug.Log (enemyType);
		b.GetComponent<IEnemyType> ().Set (enemyType);
	}
}
