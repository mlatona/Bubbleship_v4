using UnityEngine;
using System.Collections;

public class Killable : MonoBehaviour, IKillable {

	public void Kill(){
		//kill
		Destroy (gameObject);
	}

}
