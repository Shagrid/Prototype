using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObject : MonoBehaviour
{
    [SerializeField] private MeshRenderer _anotherObject;
    [SerializeField] private Animator _afterErrorObject;
    [SerializeField] private MeshRenderer _kuzov;
    [SerializeField] private Animator _nextAnimation;
    [SerializeField] private Material _newMaterial;
    [SerializeField] private LorryMovement _lorryMovement;
    [SerializeField] private bool _lastAnim = false;
    [SerializeField] private bool _endLvl = false;
    
    public void DisableCubik(int nextError = 0)
    {
        _anotherObject.material = GetComponent<MeshRenderer>().material;
        _kuzov.material = _newMaterial;
        if (!_lastAnim)
        {
            if (nextError == 1)
            {
                _nextAnimation.SetTrigger("StartTriggerError");
            }
            else
            {
                _nextAnimation.SetTrigger("StartTrigger");
            }
        }
        else
        {
            int napravlenie = 1;
            if (_lorryMovement.Speed < 0) napravlenie = -1;
            _lorryMovement.Speed = 10 * napravlenie;
            
            _lorryMovement.StartMoving();
            if (!_endLvl)
            {
                _nextAnimation.SetTrigger("StartTrigger");
            }
        }

        gameObject.SetActive(false);
    }

    public void Error()
    {
        Debug.Log(1);
         _afterErrorObject.SetTrigger("StartTrigger");
    }

    
    
}
