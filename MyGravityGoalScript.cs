using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Gorl : MonoBehaviour
{
    public AudioClip victory;
    AudioSource audioSource;
    [SerializeField] Text text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.enabled = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            text.enabled = false;
            audioSource.Stop();
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            text.enabled = true;
            audioSource.Play();
        }
    }
}