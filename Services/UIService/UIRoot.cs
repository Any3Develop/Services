using UnityEngine;

namespace Services.UIService
{
    public class UIRoot : MonoBehaviour
    {
        [SerializeField] private RectTransform _container;
        [SerializeField] private Camera _uiCamera;
        [SerializeField] private Canvas _uiCanvas;
        [SerializeField] private RectTransform _poolContainer;
        [SerializeField] private RectTransform _deactivatedContainer;
        [SerializeField] private RectTransform _topContainer;
        
        public Camera UICamera => _uiCamera;
        public Canvas UICanvas => _uiCanvas;
        public RectTransform Container => _container;
        public RectTransform PoolContainer => _poolContainer;
        public RectTransform DeactivatedContainer => _deactivatedContainer;
        public RectTransform TopContainer => _topContainer;
    }
}