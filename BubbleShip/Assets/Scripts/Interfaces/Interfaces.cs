using UnityEngine;
using System.Collections;

public interface IKillable
{
	void Kill();
}

public interface IMoveable
{
	void Move();
}

public interface ICommand
{
	void Run();
}

public interface IDamageable
{
	void Damage(int damageTaken);
}

public interface ICollisionable
{
	void CollideWithBubble(GameObject collideObject);
	void CollideWithSpaceShip(GameObject collideObject);
	void CollideWithWall(GameObject collideObject);
}

public interface IBubbleMatrix
{
	Vector3 GetRowCol();
	void SetRowCol(Vector3 rowColParam);

	Enums.BUBBLECOLOR GetBubbleColor();
	void SetBubbleColor(Enums.BUBBLECOLOR bubbleColorParam);
}