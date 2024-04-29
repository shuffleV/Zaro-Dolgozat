using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests : MonoBehaviour
{
    [SerializeField] private GameObject PointPrefab;
    public void ChestBreak()
    {
        if (gameObject.CompareTag("StartingChest"))
        {
            for (int i = 0; i < 5; i++)
            {
                var point = Instantiate(PointPrefab, transform.position, Quaternion.identity).GetComponent<Point>();
                point.SetValue(100);
            }

            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("PlantChest"))
        {
            for (int i = 0; i < 5; i++)
            {
                var point = Instantiate(PointPrefab, transform.position, Quaternion.identity).GetComponent<Point>();
                point.SetValue(200);
            }

            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("DeadPlantChest"))
        {
            for (int i = 0; i < 5; i++)
            {
                var point = Instantiate(PointPrefab, transform.position, Quaternion.identity).GetComponent<Point>();
                point.SetValue(250);
            }

            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("CrystalChest"))
        {
            for (int i = 0; i < 5; i++)
            {
                var point = Instantiate(PointPrefab, transform.position, Quaternion.identity).GetComponent<Point>();
                point.SetValue(225);
            }

            Destroy(gameObject);
        }
    }
}
