using System;
using DG.Tweening;
using UnityEngine;

namespace Services.UIService
{
    public class UIWindowAppearAnimation : UIBaseAnimation
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        
        private Tween _t;
        private Tween _t2;

        // todo: temp solution for check  animation 
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Play();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Backward();
            }
        }

        public override void Play(Action onEnd = null)
        {
            Stop();
            
            _t = _body
                .DOAnchorPos(_to, _settings.durationIn)
                .SetDelay(_settings.delay)
                .SetEase(_settings.easeIn)
                .OnComplete(() =>
                {
                    onEnd?.Invoke();
                });

            if (_canvasGroup != null)
            {
                _t2 = _canvasGroup.DOFade(1.0f, _settings.durationIn)
                    .SetDelay(_settings.delay)
                    .SetEase(_settings.easeIn);
                _t2.SetAutoKill(false);
            }
            
            _t.SetAutoKill(false);
        }

        public override void Backward(Action onEnd = null)
        {
            if (_t == null)
            {
                return;
            }
            
            Stop();
            
            _t = _body
                .DOAnchorPos(_from, _settings.durationOut)
                .SetDelay(_settings.delay)
                .SetEase(_settings.easeOut)
                .OnComplete(() =>
                {
                    onEnd?.Invoke();
                });
            
            if (_canvasGroup != null)
            {
                _t2 = _canvasGroup.DOFade(1.0f, _settings.durationOut)
                    .SetDelay(_settings.delay)
                    .SetEase(_settings.easeOut);
            }
        }

        public override void ResetValues()
        {
            Stop();
            
            if (_t != null)
            {
                _t.Kill();
            }
            
            if (_t2 != null)
            {
                _t2.Kill();
            }
            
            _body.anchoredPosition = _from;
            _t = null;
            _t2 = null;
        }

        private void Stop()
        {
            if (_t != null)
            {
                _t.Pause();
            }
            
            if (_t2 != null)
            {
                _t2.Pause();
            }
        }
    }
}