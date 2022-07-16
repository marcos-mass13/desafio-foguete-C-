using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class fogueteForceHard : MonoBehaviour
{
    [SerializeField] private Rigidbody fogueteRigidbody;
    [SerializeField] private GameObject firstPart;
    [SerializeField] private GameObject pqd;
    [SerializeField] private float droppingVelocity;
    [SerializeField] private AudioSource soundFoguete;
    [SerializeField] private float velocityDrag;
    [SerializeField] private GameObject particlesScoundStep;
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
            fogueteRigidbody.AddForce(transform.up, ForceMode.Impulse);

        fogueteRigidbody.AddForce(transform.right);

        if (fogueteRigidbody.velocity.y < 0) firstStep();
    }

    void firstStep()
    {
        disconectionModule();
        secoundStep();
    }

    void secoundStep()
    {
        
        if (Time.timeSinceLevelLoad <= 25f)
        {
            fogueteRigidbody.AddForce(transform.up*2, ForceMode.VelocityChange);
            particlesScoundStep.SetActive(true);
        }
        else
        {
            particlesScoundStep.SetActive(false);
            soundFoguete.Stop();
            pqdAtivation();
        }
        
        
    }

    void disconectionModule()
    {
        //desaclopagem
        firstPart.transform.SetParent(null);
        firstPart.AddComponent<Rigidbody>();
        firstPart.AddComponent<BoxCollider>();
    }

    void pqdAtivation()
    {
        pqd.SetActive(true);
        fogueteRigidbody.drag = velocityDrag;
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
