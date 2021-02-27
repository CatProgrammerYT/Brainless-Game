using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotTouchFloor : MonoBehaviour
{
    
    [SerializeField]
    private Transform particlePoint;
    [SerializeField]
    private ParticleSystem particleSystem;
    private GameObject MainCamera;

    private void Start()
    {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            MainCamera.SetActive(true);
        }
        else if (collision.gameObject.tag != "Player")
        {
            particlePoint.position = collision.gameObject.transform.position;
            particleSystem.gameObject.transform.position = particlePoint.transform.position;
            particleSystem.Play();
            StartCoroutine(coolDown(5f));
            Destroy(collision.gameObject);
            particleSystem.Stop();
        }
    }

    IEnumerator coolDown(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
    }

}
