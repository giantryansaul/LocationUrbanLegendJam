using System;
using UnityEngine;
using UnityEngine.UI;

public class PickupMenu : MonoBehaviour
{
    [SerializeField] private Text ItemNameObj;
    [SerializeField] private Text ItemDescriptionObj;
    [SerializeField] private Image ItemImageObj;
    [SerializeField] private GameObject PickupButton;
    [SerializeField] private GameObject DismissButton;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private ItemManager _itemManager;
    private int ItemId;
    private GameObject ItemObj;

    private void Start()
    {
        CloseMenu();
    }
    
    public void PickupItemMenu(int itemId, GameObject itemObj)
    {
        ItemId = itemId;
        ItemObj = itemObj;
        gameObject.SetActive(true);
        LoadItemIntoMenu(itemId);
        PickupButton.SetActive(true);
        DismissButton.SetActive(true);
    }

    private void LoadItemIntoMenu(int itemId)
    {
        var item = _itemManager.GetItemById(itemId);
        ItemNameObj.text = item.Name;
        ItemDescriptionObj.text = item.Description;
        ItemImageObj.sprite = item.Image;
    }

    public void CannotPickupItemMenu(int itemId)
    {
        gameObject.SetActive(true);
        LoadItemIntoMenu(itemId);
        DismissButton.SetActive(true);
    }

    public void CloseMenu()
    {
        gameObject.SetActive(false);
        PickupButton.SetActive(false);
        DismissButton.SetActive(false);
    }
    
    // Invoked through event - note that ItemId must be set
    public void PickupItem()
    {
        _inventory.AddToInventory(ItemId);
        Destroy(ItemObj);
        CloseMenu();
    }
}