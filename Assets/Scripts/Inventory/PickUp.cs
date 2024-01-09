using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Inventory inventory;
    public GameObject slotButton;

    public void PickUpItem(){
        for (int  i = 0; i < inventory.slots.Length; i++){
            if(inventory.isFull[i] == false){
                inventory.isFull[i] = true;
                Instantiate(slotButton,inventory.slots[i].transform);
                Destroy(gameObject);
                break;
            }
        }
    }
}