using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dying : MonoBehaviour
{
    public GameObject DeathScreen;
    private float Timer = 3;

    void Start()
    {
        Timer = 3;
        DeathScreen.SetActive(false);
    }

    void Update()
    {
        if (gameObject.GetComponent<HealthBar>().Health <= 0)
        {
            DeathScreen.SetActive(true);
            Timer -= Time.deltaTime;
            if (Timer < 0)
            {
                SceneManager.LoadScene("Level");
            }
        }
    }
}

