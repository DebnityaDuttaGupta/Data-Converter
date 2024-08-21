using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorManager : MonoBehaviour
{
    public Button[] buttons;
    private GameObject currentGreenBox;
    private Button[] disabledButtons;

    public GameObject[] doors;

    //public Dictionary<Button, GameObject> buttonToDoorMap;

    private void Start()
    {
        for (int i = 0; i < doors.Length; i++) 
        {
            doors[i].SetActive(false);
        }
    }

    public void OnButtonClick(Button clickedButton)
    {
        if (currentGreenBox != null)
        {
            Destroy(currentGreenBox);
            ToggleDoor(clickedButton, false);
            RestoreButtons();
            return;
        }

        disabledButtons = new Button[buttons.Length];
        int index = 0;
        foreach (Button button in buttons)
        {
            if(button != clickedButton && !button.interactable)
            {
                disabledButtons[index++] = button;
            }

            if (button != clickedButton)
            {
                button.interactable = false;
            }
        }

        RectTransform buttonRect = clickedButton.GetComponent<RectTransform>();
        currentGreenBox = new GameObject("GreenBox");
        currentGreenBox.transform.SetParent(clickedButton.transform, false);

        Image image = currentGreenBox.AddComponent<Image>();
        image.color = Color.green;

        RectTransform boxRect = currentGreenBox.GetComponent<RectTransform>();
        boxRect.sizeDelta = buttonRect.sizeDelta * 0.5f;
        boxRect.anchoredPosition = Vector2.zero;

        ToggleDoor(clickedButton, true);
    }

    private void ToggleDoor(Button clickedButton, bool state)
    {
        int index = System.Array.IndexOf(buttons, clickedButton);
        if (index >= 0 && index < doors.Length)
        {
            doors[index].SetActive(state);
        }
    }

    private void RestoreButtons()
    {
        foreach (Button button in buttons)
        {
            button.interactable = true;
        }
    }

    public void OpenDoors()
    {
        foreach (var door in doors)
        {
            door.SetActive(true);
        }
    }
}
