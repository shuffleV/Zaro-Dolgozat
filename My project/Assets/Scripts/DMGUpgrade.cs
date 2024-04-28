using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMGUpgrade : MonoBehaviour
{
    private GameObject player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AttackArea.damage += 10;
            Debug.Log(AttackArea.damage);
            Destroy(gameObject);
        }
    }
}
