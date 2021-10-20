using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class PuzzleResolve : MonoBehaviour
{

    
    private ObjectRotation _objectRotation;
    private ParticleSystem _particleSystem;
    private AudioSource _audio;
    private bool _itsResolve ;
    public GameObject allPuzzles;
    private AllPuzzlesResolve _allPuzzles;

    private void Start()
    {
        _objectRotation = GetComponent<ObjectRotation>();
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _audio = GetComponent<AudioSource>();
        _allPuzzles = allPuzzles.GetComponent<AllPuzzlesResolve>();

    }

    private void Update()
    {
        if (_itsResolve)
        {
            PuzzleItsResolve();
        }
            
        
    }

    public void SetResolution(bool itsResolve)
    {
        if(itsResolve)
        {
            Debug.Log("Me llegó el msj de que colisionó.");
            _itsResolve = true;
        }
        else
        {
            _itsResolve = false;
        }

    }


    private void PuzzleItsResolve()
    {
        _particleSystem.Play();
        _audio.Play();
        _objectRotation.enabled = false;
        _itsResolve = false;
        _allPuzzles.countPuzzlesSolved();



    }


    //--------------------------TRY WITH RAYCAST----------------------------

    //
    // public GameObject hitObjectResolution;
    // private float _rayMagnitud;
    //
    // public GameObject rayDirection;
    //
    // private ObjectRotation _objectRotation;
    //
    // private ParticleSystem _particleSystem;
    //
    //
    //
    //
    // void Start()
    // {
    //     _objectRotation = GetComponent<ObjectRotation>();
    //     _particleSystem = GetComponentInChildren<ParticleSystem>();
    //     
    //     _rayMagnitud = Vector3.Distance(transform.position, hitObjectResolution.transform.position) + 1f;
    // }


    // private void FixedUpdate()
    // {
    //     PuzzleItsResolve();
    //     
    // }

    // private void PuzzleItsResolve()
    // {
    //     RaycastHit hit;
    //     Ray ray = new Ray(transform.position, transform.right);
    //     Debug.DrawRay(transform.position, transform.forward, Color.red);
    //     if (Physics.Raycast(ray, out hit, _rayMagnitud))
    //     {
    //         if (hit.collider.gameObject.CompareTag("Resolve"))
    //         {
    //             
    //             _particleSystem.Play();
    //             _objectRotation.enabled = false;
    //             
    //         }
    //         
    //     }
    //     
    // }



}
