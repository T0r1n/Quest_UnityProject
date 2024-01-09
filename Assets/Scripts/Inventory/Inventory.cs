using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;

    // Метод для проверки наличия предмета в инвентаре по имени
    public bool HasItemByName(string itemName)
    {
        foreach (GameObject slot in slots)
        {
            // Проверяем каждый слот на наличие предмета с определенным именем
            if (CheckSlotForItemName(slot, itemName))
            {
                return true;
            }
        }

        // Если ни в одном слоте не найдено предмета с указанным именем
        return false;
    }

    // Метод для проверки наличия предмета в конкретном слоте по имени
    private bool CheckSlotForItemName(GameObject slot, string itemName)
    {
        // Перебираем дочерние объекты слота
        foreach (Transform child in slot.transform)
        {
            // Если имя дочернего объекта совпадает с искомым именем
            if (child.name == itemName)
            {
                GameObject.Destroy(child.gameObject);
                return true;
            }
        }

        // Если в слоте не найдено дочернего объекта с указанным именем
        return false;
    }
}
