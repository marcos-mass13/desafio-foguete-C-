using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class fogueteForce : MonoBehaviour
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
            //3
            if (Time.timeSinceLevelLoad <= 5f)
                //2
                fogueteRigidbody.AddForce(transform.up, ForceMode.Impulse);
            
            //4
            if (fogueteRigidbody.velocity.y < 0)
            {
                if (maxHeigth == 0)
                {
                    maxHeigth = this.transform.position.y;
                }
                foguteDropping();
            }
        }

    void foguteDropping()//5 e 6
    {
        fogueteRigidbody.drag = 1.5f;// 1 e 2 bom ! maior q 3  
            //5
        firstPart.transform.SetParent(null);//6
        
        firstPart.AddComponent<Rigidbody>();
        firstPart.AddComponent<BoxCollider>();
        
        soundFoguete.Stop();

        if (pqd.activeSelf == false)
        {
            pqd.SetActive(true);
        }

        if (pqd.activeSelf == true)
        {
            Vector3 _droppingVelocity = fogueteRigidbody.velocity;
            if(_droppingVelocity.y<droppingVelocity)
            {
                _droppingVelocity.y = droppingVelocity;
                fogueteRigidbody.velocity = _droppingVelocity;
            }
        }

        
    }
    
    
}
