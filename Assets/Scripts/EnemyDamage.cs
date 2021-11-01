using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int hitPoints = 10;

    

    private void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        Hit();
    }

    private void Hit()
    {
        hitPoints -= 1; 

        if (hitPoints <= 0)
            Destroy(gameObject);
    }
}
