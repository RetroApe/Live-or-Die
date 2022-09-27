using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float enemySpeed = 2f;
    [SerializeField] float period = 5f;
    [SerializeField] [Range(0,1)] float interval;
     
    float time;
    float destroyAt = -20f;
    int healthPoints = 5;

    void Start()
    {
        
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            healthPoints--;
            Destroy(collision.gameObject);
            Debug.Log("Enemy Hit");
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
