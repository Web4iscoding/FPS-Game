using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            print(collision.gameObject);
        }

        // Destroy bullet when hit target
        if (collision.gameObject.CompareTag("Target"))
        {
            print("hit " + collision.gameObject.name);
            Destroy(gameObject);
            CreateBulletImpact(collision);
        }

        // Destroy bullet when hit wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            print("hit a wall");
            Destroy(gameObject);
            CreateBulletImpact(collision);
        }

        // Collision with Enemy, destroy bullet when hit enemy
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("PrisonRealm")
        || collision.gameObject.CompareTag("MannequinHand") || collision.gameObject.CompareTag("ZombieHand"))
        {
            print("hit enemy");
            if (collision.gameObject.GetComponent<Enemy>().isDead == false)
                collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            CreateBloodSprayEffect(collision);
            Destroy(gameObject);
        }
    }

    // Create bloodSprayEffct when bullet collides with object
    private void CreateBloodSprayEffect(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];

        GameObject bloodSprayPrefab = Instantiate(GlobalReferences.Instance.bloodSprayEffect,
        contact.point,
        Quaternion.LookRotation(contact.normal));

        bloodSprayPrefab.transform.SetParent(collision.gameObject.transform);
    }

    // Create bulletImpactPrefab when bullet collides with object
    private void CreateBulletImpact(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];

        GameObject hole = Instantiate(GlobalReferences.Instance.bulletImpactPrefab,
        contact.point,
        Quaternion.LookRotation(contact.normal));

        hole.transform.SetParent(collision.gameObject.transform);
    }
}
