﻿using UnityEngine;

namespace Geekbrains
{
	public class FlashLightController : BaseController
	{
		private FlashLightModel _flashLight;
		private FlashLightUiText _flashLightUi;
		private FlashLightUIImage _flashLightUIImage;

        public FlashLightController()
		{
			_flashLight = MonoBehaviour.FindObjectOfType<FlashLightModel>();
			_flashLightUi = MonoBehaviour.FindObjectOfType<FlashLightUiText>();
            _flashLightUIImage = MonoBehaviour.FindObjectOfType<FlashLightUIImage>();
            Off();
		}

		public override void OnUpdate()
		{
			if (!IsActive) return;

			if (_flashLight == null)return;
			_flashLight.Rotation();
			if (_flashLight.EditBatteryCharge())
			{
				_flashLightUi.Text = _flashLight.BatteryChargeCurrent;
                _flashLightUIImage.Size(10, _flashLight.BatteryChargeCurrent);
            }
			else
			{
				//Off();
			}
		}

		public override void On()
		{
			if (IsActive)return;
			base.On();
			_flashLight.Switch(true);
			_flashLightUi.SetActive(true);
		}

		public sealed override void Off()
		{
			if (!IsActive) return;
			base.Off();
			_flashLight.Switch(false);
			_flashLightUi.SetActive(false);
		}
	}
}