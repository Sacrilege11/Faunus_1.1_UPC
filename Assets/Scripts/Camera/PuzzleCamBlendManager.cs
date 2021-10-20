using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;


public class PuzzleCamBlendManager : MonoBehaviour
{
    public GameObject _puzzleCam;
    public GameObject _thirdPersonCam;
    public GameObject refCamMirror;
    private PlayerController _playerController;
    private ParticleSystem _particleSystem;

    [SerializeField] private bool _isTouching;
    
    void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _particleSystem = GetComponent<ParticleSystem>();
        //_particleSystem = GetComponentInChildren<ParticleSystem>();


    }

    // Update is called once per frame
    void Update()
    {
        if (_isTouching)
        {
            if (Input.GetKeyDown(KeyCode.C) && _thirdPersonCam.activeInHierarchy)
            {
                //Debug.Log("Puzzle cam ON.");
                _playerController.enabled = false;
                _particleSystem.Stop();
                _puzzleCam.SetActive(true);
                _thirdPersonCam.SetActive(false);
                refCamMirror.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.C) && !_thirdPersonCam.activeInHierarchy)
            {
                //Debug.Log("Puzzle cam OFF.");
                _playerController.enabled = true;
                _particleSystem.Play();
                _puzzleCam.SetActive(false);
                _thirdPersonCam.SetActive(true);
            } 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isTouching = true;
        }
    }
    
    

 
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isTouching = false; 
        }
        
    }
}