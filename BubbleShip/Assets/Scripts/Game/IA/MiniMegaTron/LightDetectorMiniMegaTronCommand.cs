using UnityEngine;
using System.Collections;

namespace MiniMegaTron{
public class LightDetectorMiniMegaTronCommand : MonoBehaviour, ICollideCommand {

		Collider2D collider2d;

		#region ICommand implementation

		public void Run ()
		{
			//Debug.Log ("_l_");
			gameObject.GetComponentInParent<MiniMegaTronEnemy> ().enemyPos = collider2d.gameObject.transform.localPosition;
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
