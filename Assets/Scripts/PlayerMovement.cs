using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Transform projectile;
    [SerializeField] Transform fire1;

    float depth = 10f;

    void Start()
    {
    }

    void Update()
    {
        MovePlayer();
        Shoot();

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }


    void MovePlayer()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 mousePos3D = new Vector3(mousePos.x, mousePos.y, depth);
        Vector3 correctedPos = Camera.main.ScreenToWorldPoint(mousePos3D);
        transform.position = correctedPos;
    }
    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(projectile, fire1.position, projectile.rotation * Quaternion.Euler(0f, 0f, 0f));
        }
    }
}
