using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : MonoBehaviour
{
    public TextMeshProUGUI WinnerText;

    private IEnumerator OnTriggerEnter(Collider other)
    {
        GameObject.FindFirstObjectByType<Pausing>();
        WinnerText.color = new Color(0.75f, 1, 0, 1);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Main Menu");
        Cursor.lockState = CursorLockMode.None;
    }
}

