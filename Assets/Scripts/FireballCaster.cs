using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public float damage = 10f;

    public Transform FireballSourceTransform;
    public Fireball fireballPrefab;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var fireball = Instantiate(fireballPrefab, FireballSourceTransform.position, FireballSourceTransform.rotation);
            fireball.damage = damage;
        }
    }
}
