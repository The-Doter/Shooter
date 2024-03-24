﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeCaster : MonoBehaviour
{
    public float damage = 50;

    public Rigidbody grenadePrefab;
    public Transform grenadeSourceTransform;

    public float force;

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            var grenade = Instantiate(grenadePrefab);
            grenade.transform.position = grenadeSourceTransform.position;
            grenade.GetComponent<Rigidbody>().AddForce(grenadeSourceTransform.forward * force);
            grenade.GetComponent<GranadeCaster>().damage = damage;
        }
    }
}
