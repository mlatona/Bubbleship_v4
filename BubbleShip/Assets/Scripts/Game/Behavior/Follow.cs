using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
	
	public string followTag;
	public float decrementoCamara;

	public float minX, maxX;

	GameObject target;

	private Vector2 velocity;
	private Vector3 posCamera;

	void Start(){
		target = GameObject.FindGameObjectWithTag (followTag);
		posCamera = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(!isDestroyed(target.gameObject)){
			float posX = posCamera.x;
			if(target.transform.localPosition.x < minX || target.transform.localPosition.x > maxX){
				posX = Mathf.SmoothDamp(gameObject.transform.position.x, target.transform.position.x, ref velocity.x, 1f);
			}else{
				posX = Mathf.SmoothDamp(gameObject.transform.position.x, posCamera.x, ref velocity.x, 1f);
			}
			float posY = Mathf.SmoothDamp(gameObject.transform.position.y, target.transform.position.y- decrementoCamara, ref velocity.y, 0);

			transform.position = new Vector3(posX, posY, gameObject.transform.position.z);
		}
	}

	bool isDestroyed(GameObject gameObjectParam){
		return gameObjectParam == null && !ReferenceEquals (gameObjectParam, null);
	}
}
