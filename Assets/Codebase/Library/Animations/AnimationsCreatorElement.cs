using UnityEngine;
using UnityEngine.UI;

namespace Codebase.Library.Animations
{
    public class AnimationsCreatorElement : MonoBehaviour
    {
        public Transform Transform { get; private set; }
        public Image Image { get; private set; }

        private void Awake()
        {
            Transform = transform;
            Image = GetComponent<Image>();
        }
    }
}