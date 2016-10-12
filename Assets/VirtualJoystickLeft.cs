using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class VirtualJoystickLeft : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image bgImg;
    private Image joystickImg;
    private Vector3 inputVector;
    public GameObject paddle;
    public GameObject center;
    private Vector3 paddleCircPos;      // paddle position if it moves in a circular path


    private void Start()
    {
        bgImg = GetComponent<Image>();
        joystickImg = transform.GetChild(0).GetComponent<Image>();
        paddleCircPos = paddle.transform.position;
        paddle.transform.position = new Vector3((float)(paddleCircPos.x + (float)((Mathf.Abs(paddleCircPos.x) - 100) * 0.7)), paddle.transform.position.y);
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

            inputVector = new Vector3(pos.x * 2 + 1, 0, pos.y * 2 - 1).normalized;

            Vector3 joystickDir = new Vector2(0, 0) - joystickImg.rectTransform.anchoredPosition;
            float angle = Mathf.Atan2(joystickDir.y, joystickDir.x) * Mathf.Rad2Deg;

            // Move Joystick IMG
            joystickImg.rectTransform.anchoredPosition = new Vector3(inputVector.x * (bgImg.rectTransform.sizeDelta.x / 2), inputVector.z * (bgImg.rectTransform.sizeDelta.y / 2));

            if (joystickImg.rectTransform.anchoredPosition.x > 0)
            {
                if ((joystickImg.rectTransform.anchoredPosition.y > -52 & joystickImg.rectTransform.anchoredPosition.y <= 0))
                {
                    joystickImg.rectTransform.anchoredPosition = new Vector3(0, -52);
                }
                else if ((joystickImg.rectTransform.anchoredPosition.y > 0 & joystickImg.rectTransform.anchoredPosition.y < 52))
                {
                    joystickImg.rectTransform.anchoredPosition = new Vector3(0, 52);
                }
            }

            Debug.Log(joystickImg.rectTransform.anchoredPosition);

            if (inputVector.magnitude >= 1.0f)
            {
                Vector3 paddleDir = paddle.transform.position - center.transform.position;
                float angle2 = Mathf.Atan2(paddleDir.y, paddleDir.x) * Mathf.Rad2Deg;
                //paddle.transform.rotation = Quaternion.LookRotation (joystickDir);
                ///paddle.transform.RotateAround(center.transform.position, Vector3.forward, 180 + (angle - angle2));

                // Add rotation to paddle according to paddleCircPos and then update paddleCircPos
                paddle.transform.position = paddleCircPos;
                paddle.transform.RotateAround(center.transform.position, Vector3.forward, 180 + (angle - angle2));
                paddleCircPos = paddle.transform.position;

                // Multiplier of x position increases the distance from paddle to center while paddle approaches to center of left/right side of screen
                // 		to make sure that the paddle moves in an elliptic path 
                // Debug.Log((paddle.transform.position.y - 100.0f) * 0.6f + 100.0f);
                paddle.transform.position = new Vector3((float)(paddleCircPos.x + (float)((Mathf.Abs(paddleCircPos.x) - 100) * 0.7)), paddle.transform.position.y);
            }
        }
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector3.zero;
        joystickImg.rectTransform.anchoredPosition = Vector3.zero;
    }


}
