using System.Linq;
using UnityEngine;

public class ItemSetManager : MonoBehaviour
{
    [SerializeField] private ItemSet[] _itemSetStore;
    [SerializeField] private Inventory _inventory;

    public ItemSet LookForMatchingSet()
    {
        var itemsInInventory = _inventory.GetAllItems();
        foreach (var set in _itemSetStore)
        {
            var match = true;
            foreach (var item in set.ItemsNeeded)
            {
                if (!itemsInInventory.Contains(item))
                {
                    match = false;
                    break;
                }
            }
            if (match)
                return set;
        }

        return null;
    }
}