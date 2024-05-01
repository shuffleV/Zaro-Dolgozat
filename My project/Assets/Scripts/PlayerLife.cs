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

    public Healthbar healthbar;

    public static Action OnPlayerDeath;

    public TMP_Text scoreText;

    public int score = 0;

    public static Vector2 respawn = new Vector2(-77.887f, -283.871f);

    public GameObject StrartingEnemies;
    public GameObject PlantEnemies;
    public GameObject DeadPlantEnemies;
    public GameObject CrystalEnemies;
    public GameObject LightEnemies;
    //public GameObject DarkEnemies;
    //public GameObject EndEnemies;

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
        StrartingEnemies.gameObject.SetActive(false);
        PlantEnemies.gameObject.SetActive(false);
        DeadPlantEnemies.gameObject.SetActive(false);
        CrystalEnemies.gameObject.SetActive(false);
        LightEnemies.gameObject.SetActive(false);
        //DarkEnemies.gameObject.SetActive(false);
        //EndEnemies.gameObject.SetActive(false);

        health = MAX_HEALTH;
        healthbar.SetMaxHealth(MAX_HEALTH);
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    private void Update()
    {
        scoreText.text = $"Score: {score}";
        EndUI.score = score + 50000;
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
        healthbar.SetHealth(health);
    }

    public void ScoreCount(int points)
    {
        score += points;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            respawn = gameObject.transform.position;
        }
        else if (collision.gameObject.CompareTag("HP"))
        {
            MAX_HEALTH += 20;
            healthbar.SetMaxHealth(MAX_HEALTH);
            health = MAX_HEALTH;
        }
        else if (collision.gameObject.CompareTag("Spikes"))
        {
            health = 0;
            PlayerDeath();
        }
    }

    private void PlayerDeath()
    {
        score -= 200;
        transform.position = respawn;
        health = MAX_HEALTH;
        healthbar.SetMaxHealth(MAX_HEALTH);
    }
}
