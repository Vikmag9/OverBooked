using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.current.littleTimeLeft += ChangePitch;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangePitch()
    {
        this.GetComponent<AudioSource>().pitch = 1.5f;
    }
}
