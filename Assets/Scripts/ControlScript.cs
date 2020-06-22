using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Dorojka;
    public LorryMovement[] Cars;
    public GameObject BlueCube;
    private LorryMovement _lorryMovement;
    private bool _isStartingCars;
    private bool _isStartDorojka;
    private Animator _animator;
    [SerializeField] private float _dorPosition = 20;

    void Start()
    {
        _lorryMovement = Dorojka.GetComponent<LorryMovement>();
        Dorojka.GetComponent<LorryMovement>().StartMoving();
        _isStartingCars = false;
        _isStartDorojka = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isStartDorojka)
        {
            if (Dorojka.transform.position.x <= _dorPosition)
            {
                _lorryMovement.StopMoving();
                _isStartDorojka = false;
                foreach (var car in Cars)
                {
                    car.StartMoving();
                }

                _animator = BlueCube.GetComponent<Animator>();
                _animator.SetTrigger("StartTrigger");
                _isStartingCars = true;
            }
        }
    }
}
