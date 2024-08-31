using System;
using UnityEngine;
using UnityEngine.UI;

namespace ScaleSpace
{
    public class Scale : MonoBehaviour
    {
        private Image _image;
        private RectTransform _rectTransform;

        private void Start()
        {
            _image = GetComponent<Image>();
            _rectTransform = GetComponent<RectTransform>();
        }

        private void Update()
        {
            float scrollDirection = Input.GetAxis("Mouse ScrollWheel");

            if (scrollDirection != 0)
            {
                ScaleImage(scrollDirection, Input.mousePosition);
            }
        }

        private void ScaleImage(float scrollDirection, Vector3 mousePosition)
        {
            float sign = Mathf.Sign(scrollDirection);
            
            float x = _rectTransform.localScale.x * (1 + sign * 0.1f);
            float y = _rectTransform.localScale.y * (1 + sign * 0.1f);

            _rectTransform.localScale = new Vector3( 
                Mathf.Clamp(x, 0.1f, 10f), 
                Mathf.Clamp(y, 0.1f, 10f), 
                1
            );
            
            _rectTransform.pivot = new Vector2(mousePosition.x / Screen.width, mousePosition.y / Screen.height);
        }
    }
}
