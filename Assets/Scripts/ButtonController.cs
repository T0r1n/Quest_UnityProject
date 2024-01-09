using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonManager : MonoBehaviour
{
    public List<Button> buttonsToManage;

    private Button lastButtonPressed;

    void Start()
    {
        // Добавляем обработчики событий для каждой кнопки
        foreach (Button button in buttonsToManage)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
    }

    void OnButtonClick(Button clickedButton)
    {
        // Обновляем последнюю нажатую кнопку
        lastButtonPressed = clickedButton;
    }

    public void DisableLastButton()
    {
        if (lastButtonPressed != null && buttonsToManage.Contains(lastButtonPressed))
        {
            // Отключаем последнюю нажатую кнопку
            lastButtonPressed.interactable = false;
        }
    }
}

