using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

	public GameObject Player;
	private ItemManager ItemManager;


	private float _timeSinceItemSpawn;
	private float _nextSpawnTime;
	
	void Start ()
	{
		ItemManager = GetComponent<ItemManager>();
		_nextSpawnTime = 2f;

	}
	
	// Main game loop
	void Update () {

		if (_timeSinceItemSpawn > _nextSpawnTime)
		{
			StartCoroutine(SpawnItemNearPlayer());
		}
		else
		{
			_timeSinceItemSpawn += Time.deltaTime;
		}
		
	}

	private IEnumerator SpawnItemNearPlayer()
	{
		// Spawn sound effect goes here
		Debug.Log("SpawnItemNearPlayer");
		_timeSinceItemSpawn = 0;
		
		yield return new WaitForSeconds(0.1f);
		
		ItemManager.SpawnItemNearPlayerPosition(Player.transform.position);
		_nextSpawnTime = Random.Range(1f, 3f); // Vary when the next object spawns
	}
}
