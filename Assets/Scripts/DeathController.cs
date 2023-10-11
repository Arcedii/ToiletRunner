using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathController : MonoBehaviour
{
    public Button targetButton; // ������ �� ������ ������
    public Canvas MenuDeath;
    public static int Controller = 0;
    public AudioSource audioSource;

    private void Start()
    {
        MenuDeath.gameObject.SetActive(false);
        // ����������� �����-���������� � ������� ������� ������
        targetButton.onClick.AddListener(OnButtonClick);
    }

    private void Update()
    {
        if(Controller == 1)
        {
            MenuDeath.gameObject.SetActive(true);          
            audioSource.mute = true;
            Controller = 0;
        }
    }

    private void OnButtonClick()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // ������������� �����
        SceneManager.LoadScene(currentSceneIndex);

        // ��������, ������� ����� ��������� ��� ������� ������
        Debug.Log("Button clicked!");
        MenuDeath.gameObject.SetActive(false);  
        Time.timeScale = 1f;
    }
}
