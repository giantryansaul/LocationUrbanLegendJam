using System;
using UnityEngine;
using UnityEngine.UI;

public class PickupMenu : MonoBehaviour
{
    [SerializeField] private Text ItemNameObj;
    [SerializeField] private Text ItemDescriptionObj;
    [SerializeField] private Image ItemImageObj;
    [SerializeField] private GameObject ChoicesObj;
    [SerializeField] private GameObject ButtonPreFab;

    public void PickupItem(Item item)
    {
        gameObject.SetActive(true);
        LoadItemIntoMenu(item);
        var pickup = Instantiate(ButtonPreFab, ChoicesObj.transform);
        pickup.GetComponentInChildren<Text>().text = "Pickup";
        var dismiss = Instantiate(ButtonPreFab, ChoicesObj.transform);
        dismiss.GetComponentInChildren<Text>().text = "Dismiss";
    }

    private void LoadItemIntoMenu(Item item)
    {
        ItemNameObj.text = item.Name;
        ItemDescriptionObj.text = item.Description;
        ItemImageObj.sprite = item.Image;
    }

    public void CannotPickupItem(Item item)
    {
        gameObject.SetActive(true);
        LoadItemIntoMenu(item);
        var dismiss = Instantiate(ButtonPreFab, ChoicesObj.transform);
        dismiss.GetComponentInChildren<Text>().text = "Dismiss";
    }

    public void CloseMenu()
    {
        gameObject.SetActive(false);
    }
}