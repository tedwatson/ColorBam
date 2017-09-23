using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class CollisionDetector : MonoBehaviour {

	public GameObject target;
	public Text countText;
	private static int count; 
	public AudioClip[] soundFiles;
	public AudioSource soundSource;
	void Start()
	{
		count = 0;
		SetCountText();
	}
	void OnCollisionEnter(Collision collision)
 	{
		
		if (collision.gameObject.tag == target.gameObject.tag) {
			//poof sound
			//soundSource.PlayOneShot(soundFiles[0]);
			Debug.Log ("collided with redMesh");
			count = count + 1;
			Debug.Log (count);
			Destroy (collision.gameObject);
			SetCountText ();
		} 
		else {
			//bullet hitting a hard surface sound 
			soundSource.PlayOneShot(soundFiles[0]);
		}
 }
	//Sets the text of the score for the Score Board
	void SetCountText()
	{
		countText.text = "Score: " + count.ToString ();
		//Winning score
		if (count >= 500)
			//"You win!"
			//Restart?
			//SceneManager.LoadScene("Maze");
		{
			
		}
	}
}
