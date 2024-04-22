using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 25;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<EnemyHealth>() !=null)
        {
            EnemyHealth health = collider.GetComponent<EnemyHealth>();
            health.Damage(damage);
        }
        else if (collider.GetComponent<BreakableWall>() != null)
        {
            BreakableWall isBroken = collider.GetComponent<BreakableWall>();
            isBroken.WallBreak();
        }
    }
}
