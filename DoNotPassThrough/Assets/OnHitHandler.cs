using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitHandler : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource == null)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Played");
            audioSource.Play();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (audioSource != null && other.tag == "stick")
        {
            Debug.Log("Played");
            audioSource.Play();
        }
    }
}
