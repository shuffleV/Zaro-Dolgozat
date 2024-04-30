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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetEnemyValues();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void SetEnemyValues()
    {
        GetComponent<EnemyHealth>().SetHealth(data.hp);
        damage = data.damage;
        speed = data.speed;
    }

    private void Attack()
    {
        if (Mathf.Abs(player.transform.position.x - transform.position.x)<10 && Mathf.Abs(player.transform.position.y - transform.position.y) < 3.5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        if (Mathf.Abs(player.transform.position.x - transform.position.x) < 2 && Mathf.Abs(player.transform.position.y - transform.position.y) < 2)
        {
            if (Time.time > cooldown)
            {
                cooldown = Time.time + cdtime;
                player.GetComponent<PlayerLife>().Damage(damage);
            }
        }
    }
}
