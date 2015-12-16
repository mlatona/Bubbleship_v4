﻿using UnityEngine;
using System.Collections;

public interface IKillable
{
	void Kill();
}

public interface IMoveable
{
	void SetSpeed(Vector3 speedParam);
	Vector3 GetSpeed();
	void SetCanMove(bool canMoveParam);
}

public interface ICommand
{
	void Run();
}

public interface IDamageable
{
	void Damage(int damageTaken);
	int GetDamageTaken();
}

public interface ICollisionable
{
	void CollideWithBubble(GameObject collideObject);
	void CollideWithSpaceShip(GameObject collideObject);

}

public interface IBubbleMatrix
{
	Vector3 GetRowCol();
	void SetRowCol(Vector3 rowColParam);

	Enums.BUBBLECOLOR GetBubbleColor();
	void SetBubbleColor(Enums.BUBBLECOLOR bubbleColorParam);
}