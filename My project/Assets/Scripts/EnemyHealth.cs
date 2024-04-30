using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private GameObject PointPrefab;
    [SerializeField] private GameObject DmgPrefab;

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
        if (gameObject.CompareTag("StartingEnemy"))
        {
            for (int i = 0; i < 2; i++)
            {
                var point = Instantiate(PointPrefab, transform.position, Quaternion.identity).GetComponent<Point>();
                point.SetValue(125);
            }

            Destroy(gameObject);
        }
        else if(gameObject.CompareTag("PlantEnemy"))
        {
            for (int i = 0; i < 2; i++)
            {
                var point = Instantiate(PointPrefab, transform.position, Quaternion.identity).GetComponent<Point>();
                point.SetValue(250);
            }

            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("DeadPlantEnemy"))
        {
            for (int i = 0; i < 2; i++)
            {
                var point = Instantiate(PointPrefab, transform.position, Quaternion.identity).GetComponent<Point>();
                point.SetValue(375);
            }

            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("DeadPlantEnemyBig"))
        {
            for (int i = 0; i < 2; i++)
            {
                var point = Instantiate(PointPrefab, transform.position, Quaternion.identity).GetComponent<Point>();
                point.SetValue(450);
            }

            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("CrystalEnemy"))
        {
            for (int i = 0; i < 2; i++)
            {
                var point = Instantiate(PointPrefab, transform.position, Quaternion.identity).GetComponent<Point>();
                point.SetValue(500);
            }

            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("CrystalEnemyBig"))
        {
            for (int i = 0; i < 2; i++)
            {
                var point = Instantiate(PointPrefab, transform.position, Quaternion.identity).GetComponent<Point>();
                point.SetValue(575);
            }

            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("LightEnemy"))
        {
            for (int i = 0; i < 2; i++)
            {
                var point = Instantiate(PointPrefab, transform.position, Quaternion.identity).GetComponent<Point>();
                point.SetValue(375);
            }

            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("LightEnemyBig"))
        {
            for (int i = 0; i < 2; i++)
            {
                var point = Instantiate(PointPrefab, transform.position, Quaternion.identity).GetComponent<Point>();
                point.SetValue(450);
            }

            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("DarkEnemy"))
        {
            for (int i = 0; i < 2; i++)
            {
                var point = Instantiate(PointPrefab, transform.position, Quaternion.identity).GetComponent<Point>();
                point.SetValue(875);
            }

            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("DarkEnemyBig"))
        {
            for (int i = 0; i < 2; i++)
            {
                var point = Instantiate(PointPrefab, transform.position, Quaternion.identity).GetComponent<Point>();
                point.SetValue(1000);
            }

            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("EndEnemy"))
        {
            for (int i = 0; i < 2; i++)
            {
                var point = Instantiate(PointPrefab, transform.position, Quaternion.identity).GetComponent<Point>();
                point.SetValue(1125);
            }

            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("EndEnemyBig"))
        {
            for (int i = 0; i < 2; i++)
            {
                var point = Instantiate(PointPrefab, transform.position, Quaternion.identity).GetComponent<Point>();
                point.SetValue(1375);
            }

            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("DarkMiniBoss"))
        {
            for (int i = 0; i < 5; i++)
            {
                var point = Instantiate(PointPrefab, transform.position, Quaternion.identity).GetComponent<Point>();
                point.SetValue(4000);
            }
            var dmg = Instantiate(DmgPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("LightMiniBoss"))
        {
            for (int i = 0; i < 5; i++)
            {
                var point = Instantiate(PointPrefab, transform.position, Quaternion.identity).GetComponent<Point>();
                point.SetValue(2000);
            }
            var dmg = Instantiate(DmgPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("PlantMiniBoss"))
        {
            for (int i = 0; i < 5; i++)
            {
                var point = Instantiate(PointPrefab, transform.position, Quaternion.identity).GetComponent<Point>();
                point.SetValue(2000);
            }
            var dmg = Instantiate(DmgPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("Boss"))
        {
            for (int i = 0; i < 10; i++)
            {
                var point = Instantiate(PointPrefab, transform.position, Quaternion.identity).GetComponent<Point>();
                point.SetValue(5000);
            }
            var dmg = Instantiate(DmgPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            SceneManager.LoadScene(4);
        }
        // on player death heal boss
    }
}
