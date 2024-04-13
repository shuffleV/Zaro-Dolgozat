using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public int health = 100;

    private Rigidbody2D rb;
    //private Animator anim;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            PlayerDeath();
        }
    }

    private void PlayerDeath()
    {
        rb.bodyType = RigidbodyType2D.Static;
        //anim.SetTrigger("death");
        Restart();
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
