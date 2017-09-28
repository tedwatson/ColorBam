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
	public GameObject target;//reference for target object
	public static int count; //Keeping the score static so that changes are reflected everywhere
	public AudioClip[] soundFiles;//reference to audio files to be used
	public AudioSource soundSource;//reference to Audio Source
	private List<string> doneColors = new List<string>(); //A list to store the colors that have been already matched

    // Use this for initialization
    void Start()
    {
        Rend = GetComponent<Renderer>();//Gives functionality for the renderer
        Rend.enabled = true;//Makes the rendered 3d object visable if enabled;
		count = 0;//initializing the count to zero
    }


    void OnTriggerEnter(Collider c) {
		string bulletTag = c.GetComponent<Renderer> ().material.name.Replace ("(Instance)", "").ToString ().Trim();//A bullet's tag would be the name of the material of the renderer
		// if the bullet is the same color, we've scored!
		if (bulletTag == target.gameObject.tag) {
			//if one color is done then hitting the same target wont increase the score.
			if (!doneColors.Contains(bulletTag))
			{
				doneColors.Add (bulletTag);//Matched colors are added to the list of colors that are done
				target.GetComponent<Renderer> ().material = c.GetComponent<Renderer> ().material;//Giving the target the same color as the color matched.
				//poof! sound
				//soundSource.PlayOneShot(soundFiles[0]);
				count = count + 1;//Incrementing the count
				Debug.Log (count);
				if (count == 7) {
					uiHandling.instance.toggleRestartUI();
				}
			}

		} 
		else {
			//bullet hitting a hard surface sound 
			//soundSource.PlayOneShot(soundFiles[0]);
			//Debug.Log ("Not collided");
		}
    }

}
