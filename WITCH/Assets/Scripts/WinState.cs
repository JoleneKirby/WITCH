using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : MonoBehaviour
{
    public TextMeshProUGUI WinnerText1;
    public TextMeshProUGUI WinnerText2;

    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        GameObject.FindFirstObjectByType<Pausing>();
        WinnerText1.color = new Color(0.5f, 0.5f, 0.5f, 1);
        WinnerText2.color = new Color(1, 0, 0, 1);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Main Menu");
        Cursor.lockState = CursorLockMode.None;
    }
}

