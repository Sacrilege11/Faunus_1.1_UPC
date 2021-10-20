using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TargetPlatform : MonoBehaviour

{
   // private Renderer _renderer;
    public GameObject puzzleManager;
    private ObjectRotation _objectRotation;
    private Color _currentColor;
    //[SerializeField] private int _clicksCount;
    private Transform _selection;
    [SerializeField] private LayerMask _layerMaks;


    private void Update()
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material.color = _currentColor;
            _selection = null;
        }
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _layerMaks))
        {
            var selection = hit.transform;
            if (selection.CompareTag("Selectable"))
            {
                _objectRotation.MouseSelected(true);
                var selectionRenderer = selection.GetComponent<Renderer>();
                selectionRenderer.material.color = Color.yellow;
                _selection = selection;
            }
        }
        else
        {
            _objectRotation.MouseSelected(false); 
        }
    }

    void Start()
    {
        _objectRotation = puzzleManager.GetComponent<ObjectRotation>();

        //_clicksCount = 0;
        //_renderer = GetComponentInChildren<Renderer>();
        
        //_currentColor = _renderer.material.color;
        

    }

    // private void Update()
    // {
    //     if (/*!ObjectRotation.somePlatformIsSelected  && */ _clicksCount == 0 && Input.GetMouseButtonDown(0))
    //     {
    //         
    //         _clicksCount += 1;
    //         //ObjectRotation.somePlatformIsSelected = true;
    //
    //     }else if (_clicksCount == 1 && Input.GetMouseButtonDown(0))
    //     {
    //         _objectRotation.MouseSelected(false);
    //         _renderer.material.color = _currentColor;
    //         _clicksCount -= 1;
    //         //ObjectRotation.somePlatformIsSelected = false;
    //         
    //         
    //     }
    // }

    // private void OnMouseDown()
    // {
    //     _objectRotation.MouseSelected(true);
    //     _renderer.material.color = Color.yellow;
    // }
    //
    // private void OnMouseExit()
    // {
    //     _objectRotation.MouseSelected(false);
    //     _renderer.material.color = _currentColor;
    // }
}
