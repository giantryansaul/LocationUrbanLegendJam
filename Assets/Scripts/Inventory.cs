using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int MaxItems;
    [SerializeField] private List<int> _items;
    [SerializeField] private GameObject _itemsUi;
    private List<GameObject> _itemsUiStore;
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private ItemManager _itemManager;

    private void Start()
    {
        _itemsUiStore = new List<GameObject>();
        for (var i = 0; i < MaxItems; i++)
        {
            var itemUi = Instantiate(_itemPrefab, _itemsUi.transform);
            _itemsUiStore.Add(itemUi);
        }
    }

    public bool CanAddToInventory()
    {
        return _items.Count != MaxItems;
    }

    public void IncreaseInventorySpace()
    {
        // Create another inventory slot
        MaxItems++;
    }

    public void DecreaseInventorySpace()
    {
        // Drop last item or prompt user to drop an item
        // Drop the last inventory slot
        MaxItems--;
    }
    
    public void AddToInventory(int id)
    {
        _items.Add(id);
        var storeIndex = _items.Count - 1;
        var item = _itemManager.GetItemById(id);
        _itemsUiStore[storeIndex].GetComponent<ItemUi>().SetItem(item);
    }
}