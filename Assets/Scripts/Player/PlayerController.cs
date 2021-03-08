using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed;

    private float xAxis;
    private bool isLookingLeft;
    private Vector2 offset;

    // Start is called before the first frame update

    private void Awake()
    {
        offset = GetComponent<Collider2D>().bounds.size;
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    private void Moving() 
    {
        xAxis = Input.GetAxisRaw("Horizontal");


        if (xAxis > 0 && isLookingLeft)
        {
            TurnThePlayer();
        }

        if (xAxis < 0 && !isLookingLeft)
        {
            TurnThePlayer();
        }

        if (xAxis > 0 && transform.position.x < CameraController.sharedInstance.maxXSize - offset.x/2)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

        }
        if (xAxis < 0 && transform.position.x > CameraController.sharedInstance.minXSize + offset.x / 2)
        {

            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        
    }

    private void TurnThePlayer() 
    {
        isLookingLeft = !isLookingLeft;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
}
