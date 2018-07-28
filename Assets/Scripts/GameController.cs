using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.UIElements.GraphView;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public GameObject Player;
	private ItemManager ItemManager;
	[SerializeField] private Inventory Inventory;
	[SerializeField] private PickupMenu ItemPickupMenu;
	[SerializeField] private LocationUI _locationUi;

	private bool _paused;

	private float _timeSinceItemSpawn;
	private float _nextSpawnTime;
	
	void Start ()
	{
		ItemManager = GetComponent<ItemManager>();
		_nextSpawnTime = 2f;
		_paused = false;
	}
	
	// Main game loop
	void Update () 
	{
		if (_paused)
		{
			return;
		}

		if (_timeSinceItemSpawn > _nextSpawnTime)
		{
			StartCoroutine(SpawnItemNearPlayer());
			_timeSinceItemSpawn = 0;
		}
		else
		{
			_timeSinceItemSpawn += Time.deltaTime;
		}
	
		// Mouse controls
		if (Input.GetMouseButtonDown(0))
		{
			var hit = new RaycastHit();
			var mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			Physics.Raycast(mouseRay, out hit, Mathf.Infinity);
			if (hit.collider != null)
				ObjectTouched(hit.collider.gameObject);
		}
		
		// Touch controls
//		for (int i = 0; i < Input.touchCount; ++i)
//		{
//			var touch = Input.GetTouch(i);
//			var ray = Camera.main.ScreenPointToRay(touch.position);
//			Physics.Raycast(ray, out hit, Mathf.Infinity);
//			ItemTouched(hit.collider.gameObject);
//		}
		
	}

	private void ObjectTouched(GameObject obj)
	{
		if (obj.CompareTag("item"))
		{
			PickupItemMenu(obj);
		}
		
		if (obj.CompareTag("location"))
		{
			EnterLocationMenu(obj);
		}
	}

	private void EnterLocationMenu(GameObject obj)
	{
		_paused = obj.GetComponent<LocationBehavior>().OpenLocationMenu();
		if (_paused)
			_locationUi.EnterLocation(obj.gameObject.GetComponent<LocationBehavior>().LocationReference);
	}
	
	// Access with event
	public void Unpause()
	{
		_paused = true;
	}

	private void PickupItemMenu(GameObject obj)
	{
		var item = obj.GetComponent<ItemBehavior>();
		// Pickup item UI goes here
		if (Inventory.CanAddToInventory())
		{
			ItemPickupMenu.PickupItemMenu(item.ItemStoreId, obj);
		}
		else
		{
			ItemPickupMenu.CannotPickupItemMenu(item.ItemStoreId);
		}
		// This would be where events are added, Ex:
		//EventManager.FoundItem()
	}

	private IEnumerator SpawnItemNearPlayer()
	{
		// Spawn sound effect goes here
		
		yield return new WaitForSeconds(0.1f);
		
		ItemManager.SpawnRandomItemNearPlayerPosition(Player.transform.position);
		_nextSpawnTime = Random.Range(2f, 4f); // Vary when the next object spawns
	}
}
