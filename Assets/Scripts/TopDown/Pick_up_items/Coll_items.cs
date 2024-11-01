using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coll_items : MonoBehaviour
{
    public string itemName;  // Name pick_item

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Inventory script on player
            Inventory playerInventory = other.GetComponent<Inventory>();
            if (playerInventory != null)
            {
                playerInventory.AddItem(itemName); // Add item to inventory
                Destroy(gameObject); // Destroy item after pick up 
            }
        }
    }
}