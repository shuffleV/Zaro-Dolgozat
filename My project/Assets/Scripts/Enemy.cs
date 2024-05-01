using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 5;
    [SerializeField]
    private float speed = 1.5f;

    [SerializeField]
    private EnemyData data;

    public float cooldown = 0;
    private float cdtime = 0.99f;

    private GameObject player;

    private float horizontal;
    private bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetEnemyValues();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < transform.position.x)
        {
            horizontal = 1;
        }
        else if (player.transform.position.x > transform.position.x)
        {
            horizontal = -1;
        }
        Attack();
        Flip();
    }

    private void SetEnemyValues()
    {
        GetComponent<EnemyHealth>().SetHealth(data.hp);
        damage = data.damage;
        speed = data.speed;
    }

    private void Attack()
    {
        if (Mathf.Abs(player.transform.position.x - transform.position.x)<9 && Mathf.Abs(player.transform.position.y - transform.position.y) < 3.5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        if (Mathf.Abs(player.transform.position.x - transform.position.x) < 1.5f && Mathf.Abs(player.transform.position.y - transform.position.y) < 1.5f)
        {
            if (Time.time > cooldown)
            {
                cooldown = Time.time + cdtime;
                player.GetComponent<PlayerLife>().Damage(damage);
            }
        }
        if (gameObject.CompareTag("Boss"))
        {
            if (Mathf.Abs(player.transform.position.x - transform.position.x) < 9 && Mathf.Abs(player.transform.position.y - transform.position.y) < 3.5f)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
            if (Mathf.Abs(player.transform.position.x - transform.position.x) < 3f && Mathf.Abs(player.transform.position.y - transform.position.y) < 3.9f)
            {
                if (Time.time > cooldown)
                {
                    cooldown = Time.time + cdtime;
                    player.GetComponent<PlayerLife>().Damage(damage);
                }
            }
        }
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
