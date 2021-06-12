using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{

    [SerializeField] GameObject shootingPosition;
    [SerializeField] Projectile projectile;
    AttackerSpawner myLaneSpawner;
    Animator animator;
    const string PROJECTILE_PARENT = "Projectiles";
    GameObject projectileParent;

    void Start()
    {
        animator = GetComponent<Animator>();
        SetLaneSpawner();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT);

        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT);
        }
    }

    private void Update()
    {
        if(IsAttackerInLane())
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }


    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void Shoot()
    {
               
        Projectile currentProjectile = Instantiate(projectile, shootingPosition.transform.position, Quaternion.identity);
        currentProjectile.transform.parent = projectileParent.transform;
    }
}
