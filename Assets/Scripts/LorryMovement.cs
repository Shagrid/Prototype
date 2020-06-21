using UnityEngine;

public sealed class LorryMovement : MonoBehaviour
{
    private CharacterController _characterController;
    private Vector3 _moveVector;
    private int _laneNumber = 1;
    private int _lanesCount = 2;
    private bool _didChangeLastFrame = false;
    public float Speed = 5;
    private float _currentSpeed = 0;
    private float _sideSpeed = 5;
    private readonly float _firstLanePos = 2f;
    private readonly float _laneDistance = -2f;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _moveVector = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        _moveVector.x = _currentSpeed;
        _moveVector *= Time.deltaTime;
        /* float input = Input.GetAxis("Horizontal");
 
         if (Mathf.Abs(input) > 0.1f)
         {
             if (!_didChangeLastFrame)
             {
                 _didChangeLastFrame = true;
                 _laneNumber += (int)Mathf.Sign(input);
                 _laneNumber = Mathf.Clamp(_laneNumber, 0, _lanesCount);
             }
         }
         else
         {
             _didChangeLastFrame = false;
         }
 
         Vector3 newPos = transform.position;
         newPos.z = Mathf.Lerp(newPos.z, _firstLanePos + (_laneNumber * _laneDistance), Time.deltaTime * _sideSpeed);
         transform.position = newPos;*/

        _characterController.Move(_moveVector);
        
    }

    public void StartMoving()
    {
        _currentSpeed = Speed;
    }

    public void StopMoving()
    {
        _currentSpeed = 0;
    }
}