using UnityEngine;
using System.Collections;

public class Enums {

	public enum BUBBLECOLOR
	{
		BLUE=0,
		RED=1,
		PURPLE=2,
		GREEN=3,
		
		//Richard
		CARTON=4,
		LATA=5,
		PILA=6,
		PLASTICO=7
		
	};

	public static Enums.BUBBLECOLOR getRandomBubbleColor(){
		return (Enums.BUBBLECOLOR)Random.Range(0, 3);
	}

	public static int getRandomIntBubbleColor(){
		return Random.Range(4, 7);
	}

	public enum OWNER
	{
		ANY=0,
		ISENEMY=1,
		ISNOTENEMY=2
	}

}
