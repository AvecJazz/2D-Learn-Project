using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCreator : MonoBehaviour
{
    [SerializeField] GameObject[] backGroundVariants;
    [SerializeField] GameObject[] groundVariants;
    [SerializeField] GameObject player;

    private GameObject[] ground;
    private int groundSizeX;
    private float minPointX;
    private float maxPointX;
    private Vector2 offset;


    private void Start()
    {
        groundSizeX = (int)CameraController.sharedInstance.cameraSizeX;
        minPointX = CameraController.sharedInstance.minXSize;
        maxPointX = CameraController.sharedInstance.maxXSize;

        CreateWorld();
    }


    private void CreateWorld() 
    {
        BackGroundGenerate();
        GroundGenerate();
        SpawnPlayer();
    }

    private void BackGroundGenerate() 
    {
        GameObject obj = Instantiate(backGroundVariants[Random.Range(0, backGroundVariants.Length)]);
    }

    private void GroundGenerate() 
    {
        ground = new GameObject[groundSizeX + 1];

         for (int x = 0; x < groundSizeX + 1; x++) 
         {
             GameObject obj = Instantiate(groundVariants[Random.Range(0, groundVariants.Length)]);
             offset = obj.GetComponent<SpriteRenderer>().bounds.size;
             obj.transform.position = new Vector2(minPointX + offset.x/2 + x, -Camera.main.orthographicSize + offset.y/2);

         }
    }

    private void SpawnPlayer() 
    {
        GameObject obj = Instantiate(player);
        offset = obj.GetComponent<Collider2D>().bounds.size;
        obj.transform.position = new Vector2((Random.Range(minPointX + offset.x/2, maxPointX - offset.x/2)), -Camera.main.orthographicSize + 2);
    }

}
