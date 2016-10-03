﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class VirtualJoystick : MonoBehaviour , IDragHandler, IPointerUpHandler, IPointerDownHandler
{
	private Image bgImg;
	private Image joystickImg;
	private Vector3 inputVector;
	public GameObject paddle;
	public GameObject center;


	private void Start()
	{
		bgImg = GetComponent<Image> ();
		joystickImg = transform.GetChild (0).GetComponent<Image> ();
	}

	public virtual void OnDrag(PointerEventData ped)
	{
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos)) 
		{
			pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
			pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

			inputVector = new Vector3 (pos.x * 2 + 1, 0, pos.y * 2 - 1);
			inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

			Vector3 joystickDir = new Vector2(0,0) - joystickImg.rectTransform.anchoredPosition;
			float angle = Mathf.Atan2(joystickDir.y, joystickDir.x) * Mathf.Rad2Deg;

			// Move Joystick IMG
			joystickImg.rectTransform.anchoredPosition = new Vector3(inputVector.x * (bgImg.rectTransform.sizeDelta.x/2), inputVector.z * (bgImg.rectTransform.sizeDelta.y/2));
			if (inputVector.magnitude >= 1.0f) 
			{
				Vector3 paddleDir = paddle.transform.position - center.transform.position;
				float angle2 = Mathf.Atan2 (paddleDir.y, paddleDir.x) * Mathf.Rad2Deg;
				
				Debug.Log (joystickDir);
				//paddle.transform.rotation = Quaternion.LookRotation (joystickDir);
				paddle.transform.RotateAround(center.transform.position, Vector3.forward, 180 + (angle - angle2));
			}
		}
	}

	public virtual void OnPointerDown(PointerEventData ped)
	{
		OnDrag (ped);
	}

	public virtual void OnPointerUp(PointerEventData ped)
	{
		inputVector = Vector3.zero;
		joystickImg.rectTransform.anchoredPosition = Vector3.zero;
	}
		

}
