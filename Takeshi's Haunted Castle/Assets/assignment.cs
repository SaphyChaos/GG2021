using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class assignment : NetworkBehaviour
{
    public GameObject myNetworkManager;
    public GameObject myEnemy;
    public GameObject[] cameraPositions;
    public bool isCamera;
    public int currentCam;
    public int playerNum;
    public bool playerDie;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCamera)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (currentCam == cameraPositions.Length - 1)
                    currentCam = 0;
                else
                    currentCam += 1;
                this.gameObject.transform.position = new Vector3(cameraPositions[currentCam].transform.position.x, cameraPositions[currentCam].transform.position.y, cameraPositions[currentCam].transform.position.z);
                this.gameObject.transform.eulerAngles = (new Vector3(cameraPositions[currentCam].transform.eulerAngles.x, cameraPositions[currentCam].transform.eulerAngles.y, cameraPositions[currentCam].transform.eulerAngles.z));
            }
            if (Input.GetButtonDown("Fire2"))
            {
                if (currentCam == 0)
                    currentCam = cameraPositions.Length - 1;
                else
                    currentCam -= 1;
                this.gameObject.transform.position = new Vector3(cameraPositions[currentCam].transform.position.x, cameraPositions[currentCam].transform.position.y, cameraPositions[currentCam].transform.position.z);
                this.gameObject.transform.eulerAngles = (new Vector3(cameraPositions[currentCam].transform.eulerAngles.x, cameraPositions[currentCam].transform.eulerAngles.y, cameraPositions[currentCam].transform.eulerAngles.z));
            }
        }
    }
    private void Awake()
    {
        myNetworkManager = GameObject.Find("networkManager");
        myNetworkManager.GetComponent<playerCount>().playercount += 1;
        playerNum = myNetworkManager.GetComponent<playerCount>().playercount;
        if ((myNetworkManager).GetComponent<playerCount>().playercount > 1)//u a camera
        {
            this.gameObject.GetComponent<FirstPersonAIO>().enabled = false;
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            this.gameObject.tag = "playerCam";
            cameraPositions = GameObject.FindGameObjectsWithTag("camera");
            this.gameObject.transform.position = new Vector3(cameraPositions[myNetworkManager.GetComponent<playerCount>().playercount - 2].transform.position.x, cameraPositions[myNetworkManager.GetComponent<playerCount>().playercount - 2].transform.position.y, cameraPositions[myNetworkManager.GetComponent<playerCount>().playercount - 2].transform.position.z);
            //this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(cameraPositions[myNetworkManager.GetComponent<playerCount>().playercount - 2].transform.rotation.x, cameraPositions[myNetworkManager.GetComponent<playerCount>().playercount - 2].transform.rotation.y, cameraPositions[myNetworkManager.GetComponent<playerCount>().playercount - 2].transform.rotation.z));
            this.gameObject.transform.eulerAngles = (new Vector3(cameraPositions[myNetworkManager.GetComponent<playerCount>().playercount - 2].transform.eulerAngles.x, cameraPositions[myNetworkManager.GetComponent<playerCount>().playercount - 2].transform.eulerAngles.y, cameraPositions[myNetworkManager.GetComponent<playerCount>().playercount - 2].transform.eulerAngles.z));
            currentCam = myNetworkManager.GetComponent<playerCount>().playercount - 2;
            isCamera = true;
            //myNetworkManager.GetComponent<playerCount>().playercount - 2
        }
        else//u a player
        {
            this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
            myEnemy = GameObject.Find("enemy");
            myEnemy.GetComponent<navMeshAgent>().playerTarget = this.gameObject.transform;
            myEnemy.GetComponent<navMeshAgent>().active = true;
            isCamera = false;
        }
    }
}
