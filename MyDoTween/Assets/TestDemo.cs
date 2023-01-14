using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using myTween;

public class TestDemo : MonoBehaviour
{
    Tween tween;

    // Start is called before the first frame update
    void Start()
    {
        transform.DoMove(new Vector3(5f, 5f, 5f), 5f);
        transform.DoScale(new Vector3(5f, 5f, 5f), 5f);
        transform.DoRotate(new Vector3(150f, 0f, 0f), 5f);
        //GetComponent<Renderer>().material.DoColor(transform, Color.blue, 5);
        transform.DoMove(new Vector3(-10f, -10f, -10f), 10f);
        transform.DoScale(new Vector3(1f, 1f, 1f), 10f);
        transform.DoRotate(new Vector3(0f, 150f, 150f), 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
