using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{

    public Transform FireballSourceTransform;
    public Fireball fireballPrefab;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(fireballPrefab, FireballSourceTransform.position, FireballSourceTransform.rotation);
        }
    }
}
