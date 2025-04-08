using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action OnClick;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                Character character;
                
                if (hit.collider.TryGetComponent<Character>(out character))
                {
                    OnClick?.Invoke();
                }
            }
        }
    }
}
