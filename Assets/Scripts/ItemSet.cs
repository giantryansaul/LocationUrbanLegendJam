using UnityEngine;
using UnityEngine.UI;

public class ItemSet : ScriptableObject
{
    // Place items in this class that will become a set for game ending

    public string Name;
    public Image CharacterImage;
    public Item[] ItemsNeeded;
}