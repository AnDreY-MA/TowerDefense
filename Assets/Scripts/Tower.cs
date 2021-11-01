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
        towerTop.LookAt(targetEnemy);
        var emission = bulletParticles.emission;
        if (targetEnemy)
            Fire();
        else
            Shoot(false);
    }
     
    private void Fire()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.position, transform.position);

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
