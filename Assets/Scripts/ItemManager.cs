using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

	[SerializeField] private int _maxItemsInView;
	[SerializeField] private Item[] _itemStore;
	private int[] _itemIdsInView;
	
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnItemNearPlayerPosition(Vector3 playerPosition, float minDist = 10f, float maxDist = 20.0f)
	{
		var item = Instantiate(_itemStore[0].Prefab);
		item.transform.position = CreatePositionInCircle(playerPosition, maxDist);
//		item.transform.position = playerPosition + new Vector3(Random.Range(minDist, maxDist) , 5, Random.RandomRange(minDist, maxDist));
		item.GetComponentInChildren<MeshRenderer>().material.color = Color.red; // for debugging
	}
	
	private Vector3 CreatePositionInCircle (Vector3 center, float radius)
	{
		float ang = Random.value * 360;
		Vector3 pos;
		pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
		pos.y = 5;
		pos.z = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
		return pos;
	}
}
