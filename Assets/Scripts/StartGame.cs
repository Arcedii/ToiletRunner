using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Game;
    public Button targetButton; // —сылка на нужную кнопку
    public Behaviour scriptToDisable;

    private void Start()
    {
        targetButton.onClick.AddListener(OnButtonClick);
        Menu.gameObject.SetActive(true);
        Game.gameObject.SetActive(false);
        scriptToDisable.enabled = false;
    }

    private void OnButtonClick()
    {
        Menu.gameObject.SetActive(false);
        Game.gameObject.SetActive(true);
        scriptToDisable.enabled = true;
        // ƒействи€, которые нужно выполнить при нажатии кнопки
        Debug.Log("Button clicked!");
        
    }
}
