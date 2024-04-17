using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public int health = 100;
    private int MAX_HEALTH = 100;
    //private int MAX_HEALTH = 100 + (healthupgrade*20)
    public int score = 0;

    private IEnumerator DamageIndicator(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private Rigidbody2D rb;
    //private Animator anim;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    private void Update()
    {
        
    }

    /* int healthupgrade = 0;
     * if(hpupgrade)
     * {
     *      healthupgrade += 1;
     * }
    */

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }
        this.health -= amount;
        StartCoroutine(DamageIndicator(Color.red));

        if (health <= 0)
        {
            PlayerDeath();
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Healing");
        }

        if (health + amount > MAX_HEALTH)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }
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
