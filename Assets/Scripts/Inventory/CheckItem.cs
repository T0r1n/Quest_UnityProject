using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckItem : MonoBehaviour
{
    public Inventory inventory;
    public string itemNameToCheck;

    // Update is called once per frame
    public void CheckNameItem()
    {
        if (inventory.HasItemByName(itemNameToCheck + "(Clone)"))
        {
            // Предмет с указанным именем найден в инвентаре
            Debug.Log("Item with name " + itemNameToCheck + " found in inventory!");
        }
        else
        {
            // Предмет с указанным именем не найден в инвентаре
            Debug.Log("Item with name " + itemNameToCheck + " not found in inventory.");
        }
    }
}
