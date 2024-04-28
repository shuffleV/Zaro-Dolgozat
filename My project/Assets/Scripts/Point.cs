using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] private int value;
    private GameObject player;

    public void SetValue(int newValue)
    {
        value = newValue;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerLife>().ScoreCount(value);
            Destroy(gameObject);
        }
    }
}
