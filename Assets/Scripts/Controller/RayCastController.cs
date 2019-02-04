using UnityEngine;

namespace Geekbrains
{
    public sealed class RayCastController : BaseController
    {
        private RayCastModel _rayCastModel;
        private BaseObjectScene temp_obj;

        public RayCastController()
        {
            Debug.Log("I'm trying to work: finding!");
            _rayCastModel = MonoBehaviour.FindObjectOfType<RayCastModel>();
            //Debug.Log(_rayCastModel.GetInstanceID());
        }

        public override void OnUpdate()
        {
            if (!IsActive) return;

            temp_obj = _rayCastModel.SelectedObj();
            if (temp_obj != null)
            {
                Debug.Log("I'm trying to work: changing color!");
                temp_obj.Color = Color.red;
            }
        }
    }
}
