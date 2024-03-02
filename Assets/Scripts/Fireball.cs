using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float damage = 10f;

    void Start()
    {
        Invoke("DestroyFireball", lifeTime);
    }

    void FixedUpdate()
    {
        MoveFixedUpdate();
    }


    void MoveFixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }


    void OnCollisionEnter(Collision collision)
    {
        DamageEnemy(collision);
        DestroyFireball();
    }

    private void DestroyFireball()
    {
        Destroy(gameObject);
    }
    private void DamageEnemy(Collision collision)
    {
        var EnemyHealth =  collision.gameObject.GetComponent<EnemyHealth>();
        if(EnemyHealth != null)
        {
            EnemyHealth.DealDamage(damage);
        }
    }
}
