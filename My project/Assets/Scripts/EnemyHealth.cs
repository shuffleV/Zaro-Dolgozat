using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private GameObject PointPrefab;

    private IEnumerator DamageIndicator(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void SetHealth(int health)
    {
        this.health = health;
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }
        this.health -= amount;
        StartCoroutine(DamageIndicator(Color.clear));

        if (health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            var point = Instantiate(PointPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("MiniBoss"))
        {
            for (int i = 0; i < 5; i++)
            {
                var point = Instantiate(PointPrefab, transform.position, Quaternion.identity).GetComponent<Point>();
                point.SetValue(200);
            }
            
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("Boss"))
        {
            SceneManager.LoadScene(2);
        }
    }
}
