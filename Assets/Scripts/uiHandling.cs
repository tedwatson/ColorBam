using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//singleton class
public class uiHandling : MonoBehaviour {

	public GameObject startUI; // reference to the Start UI canvas
	public Text countText;//refernece for Score Text 
	public GameObject restartUI; //reference to the restart UI canvas

	private static uiHandling s_Instance;
	private static bool applicationQuit = false;
	public static uiHandling instance {
		get {
			if (s_Instance == null) {
				s_Instance = FindObjectOfType (typeof(uiHandling)) as uiHandling;
			}
			// If it is still null, create a new instance
			if (s_Instance == null) {
				GameObject obj = new GameObject ("uiHandling");
				s_Instance = obj.AddComponent (typeof(uiHandling)) as uiHandling;
			}

			return s_Instance;
		}
	}

	void OnApplicationQuit() {
			s_Instance = null;
	}
	//toggling the start UI 
	public void toggleStartUI(){
			startUI.SetActive (!startUI.activeSelf);
		}
	//toggling the restart UI 
	public void toggleRestartUI(){
		restartUI.SetActive (!restartUI.activeSelf);
	}
	//when restart is clicked the scene is loaded back again
	public void ReloadScene(){
			SceneManager.LoadScene("Main Scene");
		}
}
