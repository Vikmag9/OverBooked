using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pedestrian : MonoBehaviour
{
    public List<GameObject> waypoints;
    private float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int index = 1;
        Vector3 newPos = Vector3.MoveTowards(transform.position, waypoints[index].transform.position, speed * Time.deltaTime);
        transform.position = newPos;
    }
}
