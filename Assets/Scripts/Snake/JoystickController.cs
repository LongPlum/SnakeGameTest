using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public Image joystickBase;    
    public Image joystickKnob;    
    public Vector2 InputVector { get; private set; }


    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {

        InputVector = Vector2.zero;
        joystickKnob.rectTransform.anchoredPosition = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
      

            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBase.rectTransform, eventData.position, eventData.pressEventCamera, out position);

            position.x = (position.x / joystickBase.rectTransform.sizeDelta.x);
            position.y = (position.y / joystickBase.rectTransform.sizeDelta.y);

            InputVector = new Vector2(position.x * 2, position.y * 2);
            InputVector = (InputVector.magnitude > 1.0f) ? InputVector.normalized : InputVector;

            joystickKnob.rectTransform.anchoredPosition = new Vector2(InputVector.x * (joystickBase.rectTransform.sizeDelta.x / 2), InputVector.y * (joystickBase.rectTransform.sizeDelta.y / 2));

        
    }
 
}
