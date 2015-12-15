using UnityEngine;
using System.Collections;

public class FireStrategy : MonoBehaviour, ICommand {

	public Vector3 speed;
	public Vector3 from;
	public GameObject objectFire;

	public void Run(){
		//GameObject b = 
			Instantiate(objectFire, from, transform.rotation);
	}
}
