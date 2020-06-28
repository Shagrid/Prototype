using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Dorojka;
    public LorryMovement[] Cars;
    public GameObject StartFigure;
    private LorryMovement[] _lorryMovements;
    private bool _isStartingCars;
    private bool _isStartDorojka;
    private Animator _animator;
    [SerializeField] private float _dorPosition = 20;

    void Start()
    {
        _animator = StartFigure.GetComponent<Animator>();
        _lorryMovements = new LorryMovement[Dorojka.Length];
        for (int i = 0; i < _lorryMovements.Length; i++)
        {
            _lorryMovements[i] = Dorojka[i].GetComponent<LorryMovement>();
        }

        foreach (var lorryMovement in _lorryMovements)
        {
            lorryMovement.StartMoving();
        }
        _isStartingCars = false;
        _isStartDorojka = true;
        
        foreach (var car in Cars)
        {
            car.StartMoving();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_isStartDorojka)
        {
            if (Dorojka[0].transform.position.x <= _dorPosition)
            {
                for (int i = 0; i < _lorryMovements.Length; i++)
                {
                    _lorryMovements[i].StopMoving();
                }
                _isStartDorojka = false;
                _animator.SetTrigger("StartTrigger");
                _isStartingCars = true;
            }
        }
    }
}
