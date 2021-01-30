using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navMeshAgent : MonoBehaviour
{
    public Transform target;
    public Transform tempTarget;
    public Transform playerTarget;
    public GameObject player;
    NavMeshAgent myAgent;
    public float difficulty;//this should be .0 to .1
    private float timer;
    private int targetNumCompare;
    public float timeToMove;
    public bool canSee;
    // Start is called before the first frame update
    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        target = playerTarget;
        targetNumCompare = 1000000;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (canSee)//(player.GetComponent<playerScript>().seen)
        {
            myAgent.destination = playerTarget.position;
            print("I SEE YOU");
        }
        else
        {
            if (timer > timeToMove)
            {
                timer = 0f;
                if (Random.Range(0f, 1f) <= difficulty)
                {
                    target = playerTarget;
                    print("hard");
                }
                else
                {
                    int layerId = LayerMask.NameToLayer("wayPoints");
                    int mask = 1 << layerId;
                    Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10, mask);
                    if (hitColliders.Length != 0)
                    {
                        tempTarget = hitColliders[Random.Range(0, hitColliders.Length)].transform;
                        if (tempTarget.GetComponent<targetedNum>().number < targetNumCompare)
                        {
                            targetNumCompare = tempTarget.GetComponent<targetedNum>().number;
                            tempTarget = hitColliders[Random.Range(0, hitColliders.Length)].transform;
                        }
                        tempTarget.GetComponent<targetedNum>().number += 1;
                        target = tempTarget;
                    }
                    target.transform.localScale = new Vector3(2f, 2f, 2f);
                    print("easy");
                }
                myAgent.destination = target.position;
            }
        }
        /*
        print(hitColliders.Length);
        for (int i = 0; i < hitColliders.Length; i++)
            print(hitColliders[i].name);
        
        */
    }
    private void FixedUpdate()
    {
        
        int layerMask = 1 << 6;
        layerMask = ~layerMask;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            if (hit.collider.tag == "Player")
                canSee = true;
            else
                canSee = false;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
        }
        else
        {
            //canSee = false;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            //Debug.Log("Did not Hit");
        }
        
    }

    /*
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(this.transform.position, 10);
    }
    */
}
