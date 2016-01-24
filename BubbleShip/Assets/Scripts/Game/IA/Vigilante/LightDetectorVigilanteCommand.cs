using UnityEngine;
using System.Collections;

namespace Vigilante{
public class LightDetectorVigilanteCommand : MonoBehaviour, ICollideCommand {

		Collider2D collider2d;

		#region ICommand implementation

		public void Run ()
		{
			Debug.Log ("_l_");
			gameObject.GetComponentInParent<VigilanteEnemy> ().enemyPos = collider2d.gameObject.transform.position;
		}

		#endregion

		#region IParam implementation

		public void Set (Collider2D t)
		{
			collider2d = t;
		}

		public Collider2D Get ()
		{
			return collider2d;
		}

		#endregion




}

}
