using UnityEngine;
using UnityEngine.UI;

public class LocationUI : MonoBehaviour
{
    [SerializeField] private Text _locationNameObj;
    [SerializeField] private Text _locationDescriptionObj;
    [SerializeField] private GameObject _choicesObj;
    [SerializeField] private GameObject _buttonPrefab;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private ItemManager _itemManager;

    private void Start()
    {
        CloseMenu();
    }

    public void EnterLocation(Location location)
    {
        gameObject.SetActive(true);
        _locationNameObj.text = location.Name;
        _locationDescriptionObj.text = location.Description;
        
        foreach (var item in _inventory.GetAllItemIds())
        {
            var itemOption = Instantiate(_buttonPrefab, _choicesObj.transform);
            itemOption.GetComponentInChildren<Text>().text = _itemManager.GetItemById(item).Usage;
            itemOption.GetComponent<Button>().onClick.AddListener(delegate {OptionClicked(item); });
        }
    }

    private void CloseMenu()
    {
        gameObject.SetActive(false);
    }

    private void OptionClicked(int ItemId)
    {
        Debug.Log("option clicked " + ItemId);
        _itemManager.UseItem(ItemId);
    }
}