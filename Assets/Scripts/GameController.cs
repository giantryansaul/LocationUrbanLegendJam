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
			ItemTouched(hit.collider.gameObject);
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

	private void LocationTouched(GameObject obj)
	{
		if (obj.CompareTag("location"))
		{
			var location = obj.GetComponent<Location>();
		}
	}

	private void ItemTouched(GameObject obj)
	{
		if (obj.CompareTag("item"))
		{
			var item = obj.GetComponent<ItemBehavior>();
			// Pickup item UI goes here
//			if (Inventory.CanAddToInventory())
//			{
//				ItemPickupMenu.PickupItem(item.ItemReference);
//			}
//			else
//			{
//				ItemPickupMenu.CannotPickupItem(item.ItemReference);
//			}
			Inventory.AddToInventory(item.ItemStoreId, item.ItemReference);
			//EventManager.AddEvent("added item " + item.name)
			Destroy(obj);
		}
	}

	private IEnumerator SpawnItemNearPlayer()
	{
		// Spawn sound effect goes here
		
		yield return new WaitForSeconds(0.1f);
		
		ItemManager.SpawnItemNearPlayerPosition(Player.transform.position);
		_nextSpawnTime = Random.Range(2f, 4f); // Vary when the next object spawns
	}
}
