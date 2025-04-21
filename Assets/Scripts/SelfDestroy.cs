using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SelfDestroy : MonoBehaviour
{
    public float destructionTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroySelf(destructionTime));     
    }

    // Destroy assigned gameobject
    private IEnumerator DestroySelf(float destructionTime)
    {
        yield return new WaitForSeconds(destructionTime);

        Destroy(gameObject);
    }
}
