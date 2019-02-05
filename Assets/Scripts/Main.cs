﻿using UnityEngine;

namespace Geekbrains
{
	public class Main : MonoBehaviour
	{
		public FlashLightController FlashLightController { get; private set; }
		public InputController InputController { get; private set; }
		public PlayerController PlayerController { get; private set; }
		public RayCastController RayCastController { get; private set; }

        private BaseController[] Controllers;

		public static Main Instance { get; private set; }

		private void Awake()
		{
            Cursor.lockState = CursorLockMode.Locked;
            Instance = this;
			PlayerController = new PlayerController(new UnitMotor(
				GameObject.FindObjectOfType<CharacterController>().transform));
			PlayerController.On();
			FlashLightController = new FlashLightController();
			InputController = new InputController();
			InputController.On();
            RayCastController = new RayCastController();

            Controllers = new BaseController[4];
			Controllers[0] = FlashLightController;
			Controllers[1] = InputController;
			Controllers[2] = PlayerController;
			Controllers[3] = RayCastController;
        }

		private void Update()
		{
            
			for (var index = 0; index < Controllers.Length; index++)
			{
                
				var controller = Controllers[index];
                controller.OnUpdate();
			}
		}
	}
}