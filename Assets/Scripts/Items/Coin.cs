using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] int addToScore;
    [SerializeField] float addToTimer;
    [SerializeField] float lifeTime;
 
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
            Score.sharedInstance.AddScore(addToScore);
            Timer.sharedInstance.time += addToTimer;
            Destroy(gameObject);
          }
      }

}
