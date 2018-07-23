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

	public void SpawnItemNearPlayerPosition(Vector3 playerPosition, float minDist = 10f, float maxDist = 20.0f)
	{
		var itemIndex = _availableItems[Random.Range(0, _availableItems.Count)];
		var item = Instantiate(_itemPrefab);
		item.GetComponent<ItemBehavior>().InitizlizeItem(itemIndex, _itemStore[itemIndex]);
		if (!_itemStore[itemIndex].Common) // Only show uncommon items once
			_availableItems.Remove(itemIndex);
		if (!_availableItems.Any()) // This is just for safety, not really needed
			PopulateAvailableItems();
		item.transform.position = CreatePositionInCircle(playerPosition, minDist, maxDist);
	}

	private void PopulateAvailableItems()
	{
		_availableItems = Enumerable.Range(0, _itemStore.Length).ToList();
	}
	
	private Vector3 CreatePositionInCircle (Vector3 center, float minRadius, float maxRadius)
	{
		float ang = Random.value * 360;
		Vector3 pos;
		pos.x = center.x + Random.Range(minRadius, maxRadius) * Mathf.Sin(ang * Mathf.Deg2Rad);
		pos.y = 5;
		pos.z = center.y + Random.Range(minRadius, maxRadius) * Mathf.Cos(ang * Mathf.Deg2Rad);
		return pos;
	}
}
