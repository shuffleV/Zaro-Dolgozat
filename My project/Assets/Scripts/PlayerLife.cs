using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class PlayerLife : MonoBehaviour
{
    public int health;
    private int MAX_HEALTH = 100;
    //private int MAX_HEALTH = 100 + (healthupgrade*20)

    public Healthbar healthbar;

    public static Action OnPlayerDeath;

    public TMP_Text scoreText;

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
        health = MAX_HEALTH;
        healthbar.SetMaxHealth(MAX_HEALTH);
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    private void Update()
    {
        scoreText.text = $"Score: {score}";
        EndUI.score = score;

        

    }

     

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }
        this.health -= amount;
        healthbar.SetHealth(health);
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
        if (collision.gameObject.CompareTag("HP"))
        {
            MAX_HEALTH += 20;
            healthbar.SetMaxHealth(MAX_HEALTH);
            health = MAX_HEALTH;
        }
        else if (collision.gameObject.CompareTag("Spikes"))
        {
            PlayerDeath();
        }
    }

    private void PlayerDeath()
    {
        rb.bodyType = RigidbodyType2D.Static;
        //anim.SetTrigger("death");
        if (this.CompareTag("Player"))
        {
            Time.timeScale = 0;
            OnPlayerDeath?.Invoke();
        }
        Restart();
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
}
