using UnityEngine;
using UnityEngine.UI;


namespace BottomlessCloset
{
    public sealed class GameMenuBehaviour : BaseUi
    {
        #region Fields
        
        [SerializeField] private Button _button;
        [SerializeField] private Vector3 _camOffset;
        [SerializeField] private float _camSizeInGame;

        private float _camSizeMenu;


        #endregion


        #region UnityMethods

        protected override void Awake() => _camSizeMenu = Camera.main.orthographicSize;

        private void OnEnable()
        {
            Camera.main.transform.position -= _camOffset;
            Camera.main.orthographicSize = _camSizeInGame;
            _button.onClick.AddListener(Call);
        }

        private void OnDisable()
        {
            if (!Camera.main) return;

            Camera.main.transform.position += _camOffset;
            Camera.main.orthographicSize = _camSizeMenu;
            _button.onClick.RemoveListener(Call);
        }

        #endregion
        

        #region Methods

        public override void Show()
        {
            gameObject.SetActive(true);
            ShowUI.Invoke();
        }

        public override void Hide()
        {
            gameObject.SetActive(false);
            HideUI.Invoke();
        }

        private void Call()
        {
            ScreenInterface.GetInstance().Execute(ScreenType.MainMenu);
        }

        #endregion
    }
}
