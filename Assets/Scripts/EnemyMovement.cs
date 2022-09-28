using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float enemySpeed = 2f;
    [SerializeField] float period = 4f;
    [SerializeField] [Range(0,1)] float interval;
    [SerializeField] Transform enemyProjectile;
    [SerializeField] Transform enemyFiring1;
    [SerializeField] Transform enemyFiring2;

    float time;
    float destroyAt = -20f;
    int healthPoints = 5;

    void Start()
    {
        InvokeRepeating("Shoot1", 4f, 2f);
        InvokeRepeating("Shoot2", 5f, 2f);
    }

    void Update()
    {
        transform.Translate(- enemySpeed * Time.deltaTime * Vector3.forward, Space.World);

        Oscillate();


        if (transform.position.z < destroyAt)
        {
            Destroy(gameObject);
        }
    }

    void Shoot1()
    {
            Instantiate(enemyProjectile, enemyFiring1.position, enemyProjectile.rotation * Quaternion.Euler(0f, 0f, 0f));
    }
    void Shoot2()
    {
            Instantiate(enemyProjectile, enemyFiring2.position, enemyProjectile.rotation * Quaternion.Euler(0f, 0f, 0f));
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            healthPoints--;
            Destroy(collision.gameObject);
        }
        if (healthPoints == 0)
        {
            Destroy(gameObject);
        }
    }

    void Oscillate()
    {
        time += Time.deltaTime;
        interval = (time % period) / period;

        interval = SmoothStart(interval) + interval * (SmoothStop(interval) - SmoothStart(interval));

        if ((int)(time / period) % 2 == 0)
        {
            transform.Translate(Vector3.right * interval * Time.deltaTime);
        }
        else if ((int)(time / period) % 2 == 1)
        {
            transform.Translate(-Vector3.right * interval * Time.deltaTime);
        }
    }  
    float SmoothStop(float x)
    {
        return 1 - (1 - x) * (1 - x) * (1 - x) * (1 - x) * (1 - x);
    }

    float SmoothStart(float x)
    {
        return x * x * x * x * x; ;
    }
}
