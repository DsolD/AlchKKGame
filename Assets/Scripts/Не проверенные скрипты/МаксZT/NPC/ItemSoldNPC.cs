using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSoldNPC : MonoBehaviour
{

    public List<ItemSold> items = new List<ItemSold>();

}

[System.Serializable]
public class ItemSold
{

    public int id;
    public string name;
    public Sprite img;
    public float Price;

}

