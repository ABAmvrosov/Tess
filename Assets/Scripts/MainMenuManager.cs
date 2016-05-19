/*Base script taken from Game Development for Modern Platforms MSU course*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenuManager : MonoBehaviour {
	
	// Submenus
	public GameObject mainMenu;
	//public GameObject optionsMenu;
	//public GameObject aboutMenu;
	public Text titleText;

	private string _mainTitle;

	void Awake()
	{
		_mainTitle = titleText.text;
		// determine if Quit button should be shown
		ShowMenu("mainMenu");
	}

	public void ShowMenu(string name)
	{
		mainMenu.SetActive (false);
		//aboutMenu.SetActive(false);
		//optionsMenu.SetActive(false);

		switch(name) {
		case "mainMenu":
			mainMenu.SetActive (true);
			titleText.text = _mainTitle;
			break;
		case "optionsMenu":
			//optionsMenu.SetActive(true);
			titleText.text = "Options";
			break;
		case "About":
			//aboutMenu.SetActive(true);
			titleText.text = "About";
			break;
		}
	}

	public void loadLevel(string leveltoLoad)
	{
		Application.LoadLevel (leveltoLoad);
	}

	public void QuitGame()
	{
		Application.Quit ();
	}
}
