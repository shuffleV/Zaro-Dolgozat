using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUpgrade : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HPCollected();
        }
    }

    public void HPCollected()
    {
        Destroy(gameObject);
    }
}
