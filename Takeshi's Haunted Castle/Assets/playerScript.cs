using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public bool seen;
    // Start is called before the first frame update
    void Start()
    {
        seen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnBecameVisible()
    {
        seen = true;
    }
    void OnBecameInvisible()
    {
        seen = false;
    }
}
