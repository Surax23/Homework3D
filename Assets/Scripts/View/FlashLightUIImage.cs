using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    public class FlashLightUIImage : MonoBehaviour
    {
        private RawImage _img;
        float width_max;

        private void Start()
        {
            _img = GetComponent<RawImage>();
        }

        public void Size(float curr_max, float curr)
        {
            _img.rectTransform.localScale = new Vector3(curr / curr_max, _img.rectTransform.localScale.y);
        }
    }
}