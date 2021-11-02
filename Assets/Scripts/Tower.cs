using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform towerTop;

    [SerializeField] private Transform targetEnemy;

    [SerializeField] ParticleSystem bulletParticles;

    [SerializeField] private float shootRange;

    private void Update()
    {
        SetTargetEnemy();
        var emission = bulletParticles.emission;
        if (targetEnemy)
        {
            towerTop.LookAt(targetEnemy.transform);
            Fire();
        }           
        else
            Shoot(false);
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();

        if (sceneEnemies.Length > 0)
        {
            Transform closestEnemy = sceneEnemies[0].transform;

            foreach (EnemyDamage test in sceneEnemies)
            {
                closestEnemy = GetClosestEnemy(closestEnemy.transform , test.transform);
            }

            targetEnemy = closestEnemy;
        }
    }

    private Transform GetClosestEnemy(Transform enemy1, Transform enemy2)
    {
        var distToOne = Vector3.Distance(enemy1.position, transform.position);
        var distToTwo = Vector3.Distance(enemy2.position, transform.position);

        if (distToOne < distToTwo)
            return enemy1;
        else 
            return enemy2;
    }
     
    private void Fire()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, transform.position);

        if (distanceToEnemy <= shootRange)
            Shoot(true);
        else 
            Shoot(false);
    }

    private void Shoot(bool isActive)
    {
        var emission = bulletParticles.emission;
        emission.enabled = isActive;
    }

}
