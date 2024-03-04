using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pedestrian : MonoBehaviour
{
    public List<GameObject> waypoints;
    private float speed = 2f;

    public bool isDestroyable = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("StartCall");
        if(isDestroyable)
        {
            Debug.Log("isDestoryable");
            StartCoroutine(killObject());
        }
    }

    private void OnEnable()
    {

    }

    IEnumerator killObject()
    {
        while(true)
        {
            yield return new WaitForSeconds(30);
            
            Destroy(this.gameObject);
            Debug.Log("Destroyed");
        }
    }

    // Update is called once per frame
    void Update()
    {
        int index = 1;
        Vector3 newPos = Vector3.MoveTowards(transform.position, waypoints[index].transform.position, speed * Time.deltaTime);
        transform.position = newPos;
    }

    public void setDestroyable()
    {
        isDestroyable = true;
    }
}
