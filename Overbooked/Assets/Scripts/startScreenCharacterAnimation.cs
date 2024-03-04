using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startScreenCharacterAnimation : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        anim = GetComponent<Animator>();

        while(true)
        {
            yield return new WaitForSeconds(3);

            anim.SetInteger("wave", Random.Range(0,4));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
