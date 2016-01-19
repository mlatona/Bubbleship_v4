using UnityEngine;
using System.Collections;

public class EnemyType : MonoBehaviour, IEnemyType {

	public Enums.OWNER enemyType;

	#region IParam implementation
	public void Set (Enums.OWNER t)
	{
		enemyType = t;
	}
	public Enums.OWNER Get ()
	{
		return enemyType;
	}
	#endregion
}
