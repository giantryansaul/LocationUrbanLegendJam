using UnityEngine;

[CreateAssetMenu(fileName = "Location", menuName = "Location", order = 1)]
public class Location : ScriptableObject
{
    public string Name;
    public string Description;
    public GameObject Model;
}