using System;
using UnityEngine;

public class InputReader : IUpdatable
{
    public event Action OnClick;

    public void Update()
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
