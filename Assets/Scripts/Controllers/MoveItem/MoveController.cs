using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace BottomlessCloset
{
    public sealed class MoveController : IExecute, IListenerScreen
    {
        #region Fields
        
        private List<ItemBehaviour> _itemBehaviours;
        private CameraServices _cameraServices;
        private PhysicsService _physicsService;
        private Vector3 _startPosition;
        private ItemBehaviour _selectItem;
        private float _dragTime;
        private float _dragDelay;
        private bool _isDrag;
        private bool _isActive;
        private bool _isItemSelected;

        #endregion


        #region ClassLifeCycles

        public MoveController()
        {
            _dragDelay = 0.1f;

               _itemBehaviours = ItemExtensions.Items;
            _cameraServices = Services.Instance.CameraServices;
            _physicsService = Services.Instance.PhysicsService;
            ScreenInterface.GetInstance().AddObserver(ScreenType.GameMenu, this);
        }
        
        #endregion  
        
        
        #region IExecute

        public void Execute()
        {
            if (!_isActive) { return; }
            
            if (_isDrag)
            {
                OnDrag();
                if (Input.GetMouseButtonUp(0))
                {
                    OnPointerUp();
                }
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                var idObject = _physicsService.GetIdObject(GetMousePosition());
                if (idObject != -1)
                {
                    _selectItem = _itemBehaviours.SingleOrDefault(behaviour => behaviour.gameObject.GetInstanceID() == idObject);
                    if (_selectItem)
                    {
                        OnPointerDown();
                    }
                }
            }
        }

        #endregion

        #region Methods

        private void OnDrag()
        {
            _dragTime += Time.deltaTime;

            if (_dragTime > _dragDelay)
            {
                if(_isItemSelected)
                {
                    foreach (var item in _itemBehaviours)
                    {
                        item.DisablePhysics(_selectItem.gameObject.GetInstanceID());
                    }
                    _isItemSelected = false;
                }

                _selectItem.ItemPhysics.MovePosition(GetMousePosition());
                _selectItem.SetColor(!_selectItem.ItemPhysics.IsCollision
                    ? Data.Instance.ItemData.SelectColor
                    : Data.Instance.ItemData.CollisionColor);
            }
        }

        private void OnPointerDown()
        {
            _isDrag = true;
            _isItemSelected = true;
            _startPosition = _selectItem.transform.position;
            _selectItem.SetColor(Data.Instance.ItemData.SelectColor);
        }

        private void OnPointerUp()
        {
            if (_selectItem.ItemPhysics.IsCollision)
            {
                _selectItem.transform.position = _startPosition;
            }

            if (_dragTime < _dragDelay)
            {
                _selectItem.ItemPhysics.MoveRotation();
            }
            else
            {
                foreach (var item in _itemBehaviours)
                {
                    item.EnablePhysics(_selectItem.gameObject.GetInstanceID());
                }
            }

            _selectItem.SetDefaultColor();
            _selectItem = null;
            _isDrag = false;
            _dragTime = 0;
        }

        private Vector3 GetMousePosition()
        {
            return _cameraServices.CameraMain.ScreenToWorldPoint(Input.mousePosition);
        }
        
        #endregion
        
        

        #region IListenerScreen

        public void ShowScreen()
        {
            _isActive = true;
        }

        public void HideScreen()
        {
            _isActive = false;
        }

        #endregion
    }
}
