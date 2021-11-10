using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField] private Quaternion _currentRotation;
    public int counterTab;
    private bool _isSelected = false; 
    [SerializeField] private bool _axisSelector = true;
    [SerializeField] private bool _axisX = true;
    [SerializeField] private bool _axisY = true;
    [SerializeField] private bool _axisZ = true;
    [SerializeField] float _degreesToRotate;
    [SerializeField] private float _speedRotation = 2f;
    [SerializeField] private float sidesOfThePiece;
    private bool _rotationLock;
    
    
    
    
    

    private void Start()
    {
        
        _degreesToRotate = 360.0f/sidesOfThePiece;
        counterTab = 0;
        Selectors();
        PuzzleResolve _puzzleResolve = transform.GetComponent<PuzzleResolve>();
        _puzzleResolve.OnPuzzleResolve.AddListener(lockRotation);
}

    void Update()
    {
        
        
        if (_isSelected)
        {
            
            CounterReset();
            InputRotationManager();
            RotationX();
            RotationY();
            RotationZ();
  
        }
        


    }

    void CounterReset()
    {
        if (counterTab == 3)
        {
            counterTab = 0;
        }
    }

    void InputRotationManager()
    {
        if (_axisSelector && Input.GetKeyDown(KeyCode.R))
        {
            counterTab++;
        }
        
    }
    
    


    private void RotationX()
    {
        if (counterTab == 0 && _axisX)
        {
            if ( Input.GetKeyDown(KeyCode.E))
            {
                //transform.Rotate( _currentRotation.x + Time.deltaTime * velocity, _currentRotation.y, _currentRotation.z);
                //transform.rotation = Quaternion.Euler(_currentRotation.x++, _currentRotation.y, _currentRotation.z);
                LeanTween.rotateAroundLocal(gameObject, Vector3.right, _degreesToRotate,_speedRotation);
                
                
            } 
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                //transform.Rotate(_currentRotation.x - Time.deltaTime * velocity, _currentRotation.y, _currentRotation.z);
                //transform.rotation = Quaternion.Euler(_currentRotation.x--, _currentRotation.y, _currentRotation.z);
                LeanTween.rotateAroundLocal(gameObject, Vector3.left, _degreesToRotate,_speedRotation);
            }
            
        }
        
    }

    

    private void RotationY()
    {
        if (counterTab == 1 && _axisY)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                LeanTween.rotateAroundLocal(gameObject, Vector3.up, _degreesToRotate,_speedRotation);
                
                
            } 
            else if (Input.GetKeyDown(KeyCode.Q)) 
            {
                
                LeanTween.rotateAroundLocal(gameObject, Vector3.down, _degreesToRotate,_speedRotation);
            }
        }
        
    }

        private void RotationZ()
    {
        if (counterTab == 2 && _axisZ)
        {
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                
                RotateControll(Vector3.forward);
                

            } 
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                
                RotateControll(Vector3.back);
            }
        }
    }

        private void Selectors()
        {
            if (!_axisSelector && !_axisX && !_axisZ)
            {
                counterTab = 1;
            }
            else if(!_axisSelector && !_axisX && !_axisY)
            {
                counterTab = 2;
            }
        }
        
        public void MouseSelected (bool isSelected)
        {
            if(isSelected)
            {
                _isSelected = true;
            }
            else
            {
                _isSelected = false;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            _isSelected = false;
        }

        private void RotateControll(Vector3 vec3)
        {
            if (_rotationLock)
            {
                return;
            }

            _rotationLock = true;
            LeanTween.rotateAroundLocal(gameObject, vec3, _degreesToRotate,_speedRotation).setOnComplete(() => { _rotationLock = false; });
            
        }

        public void lockRotation(PuzzleResolve arg0)
        {
            Destroy(this);
        }
}
