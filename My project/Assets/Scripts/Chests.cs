using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests : MonoBehaviour
{
    [SerializeField] private GameObject PointPrefab;
    public void ChestBreak()
    {
        if (gameObject.CompareTag("PlantChest"))
        {
            for (int i = 0; i < 5; i++)
            {
                var point = Instantiate(PointPrefab, transform.position, Quaternion.identity).GetComponent<Point>();
                point.SetValue(200);
            }

            Destroy(gameObject);
        }
    }
}
