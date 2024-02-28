using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.current.questDeactive += DestroyItem;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground")){
            Destroy(this.gameObject);
        }
    }

    private void DestroyItem()
    {
        if(this.gameObject != null)
        {
            Destroy(this.gameObject);
            
        }
        EventManager.current.questDeactive -= DestroyItem;

    }
}
