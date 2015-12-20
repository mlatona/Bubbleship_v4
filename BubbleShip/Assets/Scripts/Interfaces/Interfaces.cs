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
}

public interface ICommand
{
	void Run();
}

public interface ICollideCommand : IParam<Collider2D>,ICommand{

}

public interface IOwner : IParam<GameObject>{

}

public interface IState{
	void updateState();
	IState changeState();
}

public interface IParam<T>
{
	void Set(T t);
	T Get();
}

public interface IDamageable
{
	void Damage(int damageTaken);
	int GetDamageTaken();
}

public interface IBubbleMatrix
{
	Vector3 GetRowCol();
	void SetRowCol(Vector3 rowColParam);

	Enums.BUBBLECOLOR GetBubbleColor();
	void SetBubbleColor(Enums.BUBBLECOLOR bubbleColorParam);
}