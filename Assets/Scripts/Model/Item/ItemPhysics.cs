using UnityEngine;


namespace BottomlessCloset
{
    [DisallowMultipleComponent]
    public sealed class ItemPhysics : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float _angle;
        private Collider2D _collider2D;
        private Rigidbody2D _rigidbody2D;
        private int _gameObjectId;
        private bool _isCollision;
        private bool _isFloor;

        #endregion


        #region Propertes
        
        public bool IsCollision => _isCollision;

        public bool IsFloor => _isFloor;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _collider2D = GetComponent<Collider2D>();
        }

        private void OnEnable()
        {
            _gameObjectId = gameObject.GetInstanceID();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(TagManager.GetTag(TagType.Floor)))
            {
                _isFloor = true;
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(TagManager.GetTag(TagType.Floor)))
            {
                _isFloor = true;
                _isCollision = false;
            }
            else
            {
                _isFloor = false;
            }

            if (!IsFloor)
            {
                _isCollision = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!IsFloor)
            {
                _isCollision = false;
            }
        }

        #endregion
        
        
        #region Methods

        public void MovePosition(Vector3 position)
        {
            _rigidbody2D.MovePosition(position);
        }

        public void MoveRotation()
        {
            if (IsFloor)
            {
                transform.Rotate(0, 0, _angle);
            }
        }

        public void EnablePhysics(int gameObjectId = -1)
        {
            if (IsFloor)
            {
                _collider2D.isTrigger =  true;
                _rigidbody2D.bodyType = RigidbodyType2D.Static;
            }
            else
            {
                _collider2D.isTrigger = false;
                _rigidbody2D.constraints = RigidbodyConstraints2D.None;
                _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            }
        }

        public void DisablePhysics(int gameObjectId = -1)
        {
            if (gameObjectId == _gameObjectId)
            {
                _collider2D.isTrigger =  true; 
                _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
                _rigidbody2D.constraints = RigidbodyConstraints2D.None;
            }
            else
            {
                _collider2D.isTrigger = false;
                _rigidbody2D.constraints = RigidbodyConstraints2D.FreezePosition;
                _rigidbody2D.bodyType = RigidbodyType2D.Static;
            }
        }

        #endregion
    }
}
