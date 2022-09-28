using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileDestruction = -15f;



    void Update()
    {
        transform.Translate(- projectileSpeed * Time.deltaTime * Vector3.forward, Space.World);

        if (transform.position.z < projectileDestruction)
        {
            Debug.Log(transform.position.z);
            Destroy(gameObject);
        }

    }
}
