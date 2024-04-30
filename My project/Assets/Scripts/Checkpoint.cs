using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public GameObject enemy;
    public GameObject enemy2;
    public GameObject player;




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerLife>().Heal(200);
            //nézd meg player attack
            enemy.SetActive(true);
            enemy2.SetActive(true);
            for (int i = 0; i < enemy.transform.childCount; i++)
            {
                enemy.transform.GetChild(i).gameObject.SetActive(true);
            }
            for (int i = 0; i < enemy2.transform.childCount; i++)
            {
                enemy2.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }

}
