using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObject : MonoBehaviour
{
    [SerializeField] private MeshRenderer _anotherObject;
    [SerializeField] private MeshRenderer _kuzov;
    [SerializeField] private Animator _nextAnimation;
    [SerializeField] private Material _newMaterial;
    [SerializeField] private LorryMovement _lorryMovement;
    [SerializeField] private bool _lastAnim = false;
    // Start is called before the first frame update
    public void DisableCubik()
    {
        _anotherObject.material = gameObject.GetComponent<MeshRenderer>().material;
        _kuzov.material = _newMaterial;
        if (!_lastAnim)
        {
            _nextAnimation.SetTrigger("StartTrigger");
        }
        else
        {
            _lorryMovement.Speed = 10;
            _lorryMovement.StartMoving();
        }

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    
}
