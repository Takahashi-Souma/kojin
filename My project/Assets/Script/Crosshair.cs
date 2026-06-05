using UnityEngine;
using UnityEngine.InputSystem;

public class Crosshair : MonoBehaviour
{
    RectTransform rect;

    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        rect.position = mousePos;
    }
}

