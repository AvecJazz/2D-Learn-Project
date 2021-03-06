using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] float timeToSpawn;

    public GameObject spawnObject;
    
    private float _timeToSpawn;
    private Vector2 offset;
    private Box box;
  
    // Update is called once per frame
    void Update()
    {
        SpawnObject();
    }


    public void SpawnObject()
    {
        _timeToSpawn += Time.deltaTime;
        if (_timeToSpawn >= timeToSpawn) 
        {
            box = Instantiate(spawnObject).GetComponent<Box>();
            offset = box.GetComponent<Collider2D>().bounds.size;
            box.transform.position = new Vector2(Random.Range(CameraController.sharedInstance.minXSize + offset.x/2, CameraController.sharedInstance.maxXSize - offset.x/2), Camera.main.orthographicSize);
            _timeToSpawn = 0;
        }
    }

}
