using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int MaxItems;
    [SerializeField] private List<int> items;
    [SerializeField] private GameObject ItemsUi;
    private List<GameObject> ItemsUiStore;
    [SerializeField] private GameObject ItemPrefab;

    private void Start()
    {
        ItemsUiStore = new List<GameObject>();
        for (var i = 0; i < MaxItems; i++)
        {
            var itemUi = Instantiate(ItemPrefab, ItemsUi.transform);
            ItemsUiStore.Add(itemUi);
        }
    }

    public bool CanAddToInventory()
    {
        return items.Count != MaxItems;
    }

    public void IncreaseInventorySpace()
    {
        MaxItems++;
    }

    public void DecreaseInventorySpace()
    {
        MaxItems--;
    }
    
    public void AddToInventory(int id, Item item)
    {
        items.Add(id);
        var storeIndex = items.Count - 1;
        ItemsUiStore[storeIndex].GetComponent<ItemUi>().SetItem(item);
    }
    
    
}