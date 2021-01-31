using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class sideFinder : NetworkBehaviour
{
    public GameObject temp;
    public GameObject[] sides;
    public GameObject imageF;
    public GameObject imageB;
    public GameObject imageL;
    public GameObject imageR;
    public float timer;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        sides = GameObject.FindGameObjectsWithTag("sides");
        
        //print(temp);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= time)
        {
            timer = 0f;
            float minDist = Mathf.Infinity;
            Vector3 currentPos = transform.position;
            foreach (GameObject t in sides)
            {
                float dist = Vector3.Distance(t.transform.position, currentPos);
                if (dist < minDist)
                {
                    temp = t;
                    minDist = dist;
                }
            }
            if (temp.name == "front")
            {
                Instantiate(imageF, temp.transform.position, temp.transform.rotation);
            }
            else if (temp.name == "back")
            {
                Instantiate(imageB, temp.transform.position, temp.transform.rotation);
            }
            else if (temp.name == "left")
            {
                Instantiate(imageL, temp.transform.position, temp.transform.rotation);
            }
            else if (temp.name == "right")
            {
                Instantiate(imageR, temp.transform.position, temp.transform.rotation);
            }
        }
    }
}
