/*Base script taken from Game Development for Modern Platforms MSU course*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
	
	// Submenus
	public GameObject MainMenu;
	//public GameObject optionsMenu;
	//public GameObject aboutMenu;
	public Text TitleText;

	private string mainTitle;

	void Awake()
	{
		mainTitle = TitleText.text;
		// determine if Quit button should be shown
		ShowMenu("mainMenu");
	}

	public void ShowMenu(string name)
	{
		MainMenu.SetActive (false);
		//aboutMenu.SetActive(false);
		//optionsMenu.SetActive(false);

		switch(name) {
		case "mainMenu":
			MainMenu.SetActive (true);
			TitleText.text = mainTitle;
			break;
		case "optionsMenu":
			//optionsMenu.SetActive(true);
			TitleText.text = "Options";
			break;
		case "About":
			//aboutMenu.SetActive(true);
			TitleText.text = "About";
			break;
		}
	}

	public void LoadLevel(string leveltoLoad)
	{
		SceneManager.LoadScene(leveltoLoad);
	}

	public void QuitGame()
	{
		Application.Quit ();
	}
}
