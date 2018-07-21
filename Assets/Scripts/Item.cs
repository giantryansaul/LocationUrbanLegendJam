using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 1)]
public class Item : ScriptableObject
{
    public string Name;
    public string Description;
    public GameObject Prefab;
}