using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box")) 
        {
            if (collision.gameObject.GetComponent<Loot>() != null) 
            {
                collision.gameObject.GetComponent<Loot>().CalculateAndDropItem();
            }
            Destroy(collision.gameObject);
        }
    }
}
