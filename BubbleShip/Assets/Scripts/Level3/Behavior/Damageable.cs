using UnityEngine;
using System.Collections;

public class Damageable : MonoBehaviour, IDamageable{

	public int damage = 0;
	public int life = 0;

	public void Damage(int damageTaken){
		life -= damageTaken;
		//Debug.Log ("Damageable "+life);
		//if his life less than 1, and is killable then kill it
		IKillable killable = gameObject.GetComponent<IKillable> ();
		if (killable != null && life <= 0) {
			killable.Kill();
		}
	}

	public int GetDamageTaken(){ return damage;}
}
