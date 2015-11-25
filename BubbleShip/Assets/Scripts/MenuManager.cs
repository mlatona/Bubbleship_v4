using UnityEngine;
using System.Collections;
public class MenuManager : MonoBehaviour {
	// Currently open menu. Set the initial reference in the Inspector
	public Menu currentMenu;
	void Start () {
		ShowMenu (currentMenu); // For showing the main menu
	}
	// Activate the given menu and deactivate the current
	// Invokable by the Inspector
	public void ShowMenu(Menu menu) {
		if (currentMenu != null)
			currentMenu.IsOpen = false;
		currentMenu = menu;
		currentMenu.IsOpen = true;
	}

	public void ShowScene(int level) {
		if (currentMenu != null)
			currentMenu.IsOpen = false;
		currentMenu = null;
		Application.LoadLevel (level);
	}

	public void Exit(){
		Debug.Log("Quit");
		//UnityEditor.EditorApplication.isPlaying = false;
		Application.Quit();
	}
}