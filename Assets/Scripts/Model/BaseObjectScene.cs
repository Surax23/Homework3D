using System;
using UnityEngine;

namespace Geekbrains
{
	public abstract class BaseObjectScene : MonoBehaviour
	{
		private int _layer;
        private Color _color;
        public Renderer Renderer { get; private set; }
		public Rigidbody Rigidbody { get; private set; }
		public Transform Transform { get; private set; }
		public int Layer
		{
			get => _layer;
			set
			{
				_layer = value;
				AskLayer(Transform, _layer);
			}
		}

        public Color Color { get => _color; set { _color = value; SetColor(Transform, Renderer, _color); } }

        private void SetColor(Transform obj, Renderer rend, Color _color)
        {
            //throw new NotImplementedException();
            rend.material.color = _color;
            foreach (Transform child in obj)
            {
                SetColor(child, child.GetComponent<Renderer>(), _color);
            }
        }

        private void AskLayer(Transform obj, int layer)
		{
			obj.gameObject.layer = layer;
			if (obj.childCount <= 0)return;

			foreach (Transform child in obj)
			{
				AskLayer(child, layer);
			}
		}

		protected virtual void Awake()
		{
			Rigidbody = GetComponent<Rigidbody>();
            Renderer = GetComponent<Renderer>();
			Transform = transform;
		}
	}
}