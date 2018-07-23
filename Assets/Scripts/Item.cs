using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 1)]
public class Item : ScriptableObject
{
    public string Name;
    public string Description;
    public GameObject Model;
    public bool Common;
    public Sprite Image;

    private void Awake()
    {
        if (!Common)
            Model.GetComponent<MeshRenderer>().material.color = Color.yellow;
    }
}