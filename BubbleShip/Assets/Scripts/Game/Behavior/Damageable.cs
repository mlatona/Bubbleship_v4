using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Damageable : MonoBehaviour, IDamageable{

	public int damage = 0;
	public int life = 0;

	public void Damage(int damageTaken){
		life -= damageTaken;
		if (gameObject.tag == "Player" && life>-1) {
			Debug.Log (life);
				GameObject.FindGameObjectWithTag("HP"+life).GetComponent<Image>().sprite = null;
		}
		//Debug.Log ("Damageable "+life);
		//if his life less than 1, and is killable then kill it
		IKillable killable = gameObject.GetComponent<IKillable> ();
		if (killable != null && life <= 0) {
			killable.Kill();
		}
	}

	public int GetDamageTaken(){ return damage;}
	public int GetLife(){return life;}
}
