using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    public int ItemStoreId;
    private GameObject _itemModel;
    public Item ItemReference;

    public void InitizlizeItem(int id, Item item)
    {
        _itemModel = Instantiate(item.Model, transform);
        ItemStoreId = id;
        ItemReference = item;
    }

    public void SetColor(Color color)
    {
        GetComponentInChildren<MeshRenderer>().material.color = color;
    }
    
}