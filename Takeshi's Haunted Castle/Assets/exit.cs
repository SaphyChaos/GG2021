using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    public class exit : MonoBehaviour
    {
        public Collider[] findPlayer;
        int layerId;
        int mask;
        // Start is called before the first frame update
        void Start()
        {
            layerId = LayerMask.NameToLayer("Player");
            mask = 1 << layerId;
        }

        // Update is called once per frame
        void Update()
        {
            findPlayer = Physics.OverlapSphere(transform.position, 5, mask);
            SceneManager.LoadScene("onlineScene", LoadSceneMode.Additive);
    }
    }
