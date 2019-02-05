using UnityEngine;

namespace Geekbrains
{
	public class InputController : BaseController
	{
		private KeyCode _codeFlashLight = KeyCode.F;
        private const int _codeChoosePKM = 1;
		public override void OnUpdate()
		{
			if (!IsActive) return;
			if (Input.GetKeyDown(_codeFlashLight))
			{
				Main.Instance.FlashLightController.Switch();
			}
            if (Input.GetMouseButtonDown(_codeChoosePKM))
            {
                Main.Instance.RayCastController.On();
            }
            if (Input.GetMouseButtonUp(_codeChoosePKM))
            {
                Main.Instance.RayCastController.Off();
            }
        }
	}
}