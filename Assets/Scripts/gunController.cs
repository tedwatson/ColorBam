using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunController : MonoBehaviour {

	public GameObject bullet;
	public GameObject bulletSpawnPoint;

	public void fireGun() 
	{
		// instantiate a new bullet at the spawn point
		Instantiate(bullet, bulletSpawnPoint.transform.position, transform.rotation);
	}
}
