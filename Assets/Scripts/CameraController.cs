using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{

    public static CameraController sharedInstance;

    [HideInInspector]
    public float cameraSizeX;
    [HideInInspector]
    public float ratio;
    [HideInInspector]
    public float minXSize;
    [HideInInspector]
    public float maxXSize;

    

    // Start is called before the first frame update
    private void Awake()
    {

        sharedInstance = this;

        ratio = (float)Screen.width / (float)Screen.height;
        cameraSizeX = ratio * Camera.main.orthographicSize*2;

        minXSize = Camera.main.transform.position.x - cameraSizeX/2;
        maxXSize = Camera.main.transform.position.x + cameraSizeX / 2;
        

       // Debug.Log($"{minXSize} min, {maxXSize} max, {cameraSizeX},{ratio},{Camera.main.orthographicSize},{Screen.width},{Screen.height}");
    }

}
