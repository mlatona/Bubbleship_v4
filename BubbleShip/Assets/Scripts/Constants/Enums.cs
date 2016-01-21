using UnityEngine;
using System.Collections;

public class Enums {

	public enum BUBBLECOLOR
	{
		PILA=0,
		LATA=1,
		CARTON=2,
		PLASTICO=3

		
	};

	public static Enums.BUBBLECOLOR getRandomBubbleColor(){
		return (Enums.BUBBLECOLOR)Random.Range(0, 4);
	}

	public static int getRandomIntBubbleColor(){
		return Random.Range(0, 4);
	}

	public enum OWNER
	{
		ANY=0,
		ISENEMY=1,
		ISNOTENEMY=2
	}

}
