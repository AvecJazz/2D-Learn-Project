using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{

    [SerializeField] float lifeTime;
    private int addToHealth = 1;

    private void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0) 
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            if (collision.gameObject.GetComponent<Health>() != null) 
            {
                if (collision.gameObject.GetComponent<Health>().RestoreHealth(addToHealth) == true) 
                {
                    Destroy(gameObject);
                }
                
            }
        }
    }

}
