
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]

public class ClickHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent upEvent;
     public UnityEvent downEvent;
   
    private void OnMouseDown()
    {
        Debug.Log("down");
        downEvent?.Invoke();


    }

    private void OnMouseUp()
    {
             Debug.Log("Up");
             upEvent?.Invoke();
    }

   
}
