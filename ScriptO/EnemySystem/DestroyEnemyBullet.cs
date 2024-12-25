using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyBullet : MonoBehaviour
{
    float timeDelete;
    private void Start()
    {
        timeDelete = Time.time + 3f;
    }
    private void Update()
    {
        if (Time.time > timeDelete)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Enemy")
        {
            gameObject.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            Destroy(gameObject, 0.3f);
        }
        else{
            Destroy(collision.gameObject);
            Destroy(gameObject);
            print("ggg");

        }
        
    }

}
