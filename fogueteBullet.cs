using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class fogueteBullet : MonoBehaviour
{
    
    [SerializeField] private Rigidbody fogueteRigidbody; //1
    
    [SerializeField] private float maxHeigth; //4

    [SerializeField] private GameObject firstPart;
    [SerializeField] private GameObject pqd;
    
    [SerializeField] private float droppingVelocity;

    [SerializeField] private AudioSource soundFoguete;

    private void Start()
    {
        fogueteRigidbody = GetComponent<Rigidbody>();
        pqd.SetActive(false);
        print(GetComponent<Rigidbody>());
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(0);
    }
    
    void FixedUpdate()
        {
            if (Time.timeSinceLevelLoad <= 5f)
            {
                fogueteRigidbody.AddForce(transform.up, ForceMode.Impulse);
            }
            else
            {
                this.gameObject.AddComponent<BoxCollider>();
            }
            
            //4
            if (fogueteRigidbody.velocity.y < 0)
            {
                if (maxHeigth == 0)
                {
                    maxHeigth = this.transform.position.y;
                }
                
            }
        }
    
    
}
