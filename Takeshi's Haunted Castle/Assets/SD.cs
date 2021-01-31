using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SD : NetworkBehaviour
{
    public float timer;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > time)
        {
            Destroy(this.gameObject);
        }
    }
}
