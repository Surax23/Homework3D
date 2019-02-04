using System;
using UnityEngine;

namespace Geekbrains
{
    class RayCastModel : BaseObjectScene
    {
        private Ray ray;
        private RaycastHit hit;

        protected override void Awake()
        {
            base.Awake();
            ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            Debug.Log("I'm trying to work: creating ray!");
        }

        public BaseObjectScene SelectedObj()
        {
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 50f, Color.red);
            Debug.Log("I'm trying to work: trying to hit an object!");
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.Log("I'm trying to work: hitting object!");
                return hit.transform.gameObject.GetComponent<BaseObjectScene>();
            }
            return null;
        }
    }
}