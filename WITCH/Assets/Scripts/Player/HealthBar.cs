using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public int Health = 5;
    public float InvincibiltyTimer = 0;
    public SpriteRenderer Sprite;
    public TextMeshProUGUI HealthText;

    void Update()
    {
        InvincibiltyTimer -= Time.deltaTime;
        if (InvincibiltyTimer > 0)
        {
            Sprite.color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            Sprite.color = new Color(1, 1, 1, 1);
        }
        HealthText.SetText(Health.ToString() + "/5");
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Harmful") && InvincibiltyTimer < 0)
        {
            Health -= 1;
            Debug.Log("Ow!");
            InvincibiltyTimer = 1;
        }
    }
}
