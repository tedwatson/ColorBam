using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class enemyController : MonoBehaviour {

    //public Material[] materials;//Allows input of material colors in a set size of array;
    private Renderer Rend; //What are we rendering? Input object(Sphere,Cylinder,...) to render.

    private int index = 1;//Initialize at 1, otherwise you have to hit the object twice to change colors at first.

	public GameObject target;
	public Text countText;
	private static int count; 
	public AudioClip[] soundFiles;
	public AudioSource soundSource;
	private List<string> doneColors = new List<string>();
    // Use this for initialization
    void Start()
    {
        Rend = GetComponent<Renderer>();//Gives functionality for the renderer
        Rend.enabled = true;//Makes the rendered 3d object visable if enabled;
		count = 0;
		SetCountText();
    }


    void OnTriggerEnter(Collider c) {
		
		string bulletTag = c.GetComponent<Renderer> ().material.name.Replace ("(Instance)", "").ToString ().Trim();
		Debug.Log (bulletTag);
		// if the bullet is the same color, we've scored!
		if (bulletTag == target.gameObject.tag) {
			//if one color is done then hitting the same target wont increase the score.
			if (!doneColors.Contains(bulletTag))
			{
				doneColors.Add (bulletTag);
				target.GetComponent<Renderer> ().material = c.GetComponent<Renderer> ().material;
				//poof sound
				//soundSource.PlayOneShot(soundFiles[0]);
				Debug.Log ("collided");
				count = count + 1;
				Debug.Log (count);
				SetCountText ();
			}

		} 
		else {
			//bullet hitting a hard surface sound 
			//soundSource.PlayOneShot(soundFiles[0]);
			//Debug.Log ("Not collided");
		}
    }

	void SetCountText()
	{
		countText.text = "Score: " + count.ToString ();
		//Winning score
		if (count == 7)
			//"You win!"
			//Restart?
			//SceneManager.LoadScene("Main Scene");
		{

		}
	}
}
