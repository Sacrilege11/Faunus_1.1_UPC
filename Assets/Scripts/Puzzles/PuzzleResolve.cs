using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using Debug = UnityEngine.Debug;

public class PuzzleResolve : MonoBehaviour
{

    
    private ObjectRotation _objectRotation;
    private ParticleSystem _particleSystem;
    private AudioSource _audio;
    
    public GameObject allPuzzles;
    private AllPuzzlesResolve _allPuzzles;
    public PuzzleResolveEvent OnPuzzleResolve = new PuzzleResolveEvent();

    private void Start()
    {
        _objectRotation = GetComponent<ObjectRotation>();
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _audio = GetComponent<AudioSource>();
        _allPuzzles = allPuzzles.GetComponent<AllPuzzlesResolve>();

    }



    public void SetResolution(bool itsResolve)
    {
        if(itsResolve)
        {
            OnPuzzleResolve.Invoke(this);
            PuzzleItsResolve();
        }


    }


    private void PuzzleItsResolve()
    {
        _particleSystem.Play();
        _audio.Play();
        //_objectRotation.enabled = false;
        
        //_allPuzzles.countPuzzlesSolved();



    }

    public class PuzzleResolveEvent : UnityEvent<PuzzleResolve> {}


}
