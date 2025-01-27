using UnityEngine;
using UnityEngine.UI;

namespace UserInterface.Common
{
    public class Fillbar_UserInterface: MonoBehaviour
    {
        private RectTransform _fillbarContainer;
        private Image _fillbarImage;
        private Image _fillbarBackgroundImage;

        private void Awake()
        {
            _fillbarContainer = GetComponent<RectTransform>();
            
            _fillbarImage = _fillbarContainer.GetComponentsInChildren<Image>()[1];
            _fillbarBackgroundImage = _fillbarContainer.GetComponentsInChildren<Image>()[0];
        }

        /// <summary>
        /// Set the Color of the fillbar
        /// </summary>
        /// <param name="color"></param>
        public void SetFillColor(Color color)
        {
            _fillbarImage.color = color;
        }
        
        /// <summary>
        /// Calculate and Set the fill amount of the main fillbar
        /// </summary>
        /// <param name="currentValue"></param>
        /// <param name="targetValue"></param>
        public void Fill(float currentValue, float targetValue)
        {
            var fillAmount = currentValue / targetValue;
            _fillbarImage.fillAmount = fillAmount;
        }
        
    }
}