using UnityEngine;
using UnityEngine.UI;

public class ItemUi : MonoBehaviour
{
    [SerializeField] private GameObject ItemImg;
    
    private void Start()
    {
        ItemImg.SetActive(false);
    }

    public void SetItem(Item item)
    {
        ItemImg.SetActive(true);
        ItemImg.GetComponent<Image>().sprite = item.Image;
    }

}