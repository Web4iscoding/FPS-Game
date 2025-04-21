using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatManager : MonoBehaviour
{
    // BatManager Singleton

    public static BatManager Instance { get; set; }
    public int damage = 0;
    public float attackDistance = 0.4f;
    public LayerMask attackLayer;
    public Camera cam;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Bat attack
    public void Attack() {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, attackDistance, attackLayer))
        {
            if (hit.transform.TryGetComponent<Enemy>(out Enemy T) && hit.transform.GetComponent<Enemy>().isDead == false)
            {
                T.TakeDamage(damage);
            }
        }
    }
}



