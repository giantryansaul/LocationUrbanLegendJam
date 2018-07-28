using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

	[SerializeField] private Item[] _itemStore; // List of Item objects (look in the Items folder)
	private List<int> _availableItems;
	[SerializeField] private GameObject _itemPrefab;
	
	void Start ()
	{
		PopulateAvailableItems();
	}

	public void SpawnRandomItemNearPlayerPosition(Vector3 playerPosition, float minDist = 10f, float maxDist = 20.0f)
	{
		var itemIndex = _availableItems[Random.Range(0, _availableItems.Count)];
		var item = Instantiate(_itemPrefab);
		item.GetComponent<ItemBehavior>().InitizlizeItem(itemIndex, _itemStore[itemIndex]);
		if (!_itemStore[itemIndex].Common) // Only show uncommon items once
			_availableItems.Remove(itemIndex);
		if (!_availableItems.Any()) // This is just for safety, not really needed
			PopulateAvailableItems();
		item.transform.position = GameUtils.CreatePositionInCircle(playerPosition, minDist, maxDist);
	}

	private void PopulateAvailableItems()
	{
		_availableItems = Enumerable.Range(0, _itemStore.Length).ToList();
	}

	public Item GetItemById(int id)
	{
		return _itemStore[id];
	}

	public void UseItem(int id)
	{
		
	}
}
