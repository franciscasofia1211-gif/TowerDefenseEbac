using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class AdminToques : MonoBehaviour
{
    public InputActionAsset inputs;

    private InputAction toque;
    private InputAction posicionToque;
    private Camera mainCamera;

    public delegate void PlataformaTocada(GameObject plataforma);
    public event PlataformaTocada enPlataformaTocada;

    private void OnEnable()
    {
        TouchSimulation.Enable();
        inputs.Enable();
        toque = inputs.FindAction("Toque");
        posicionToque = inputs.FindAction("PosicionToque");
        toque.performed += Toque;
    }

    private void OnDisable()
    {
        inputs.Disable();
        TouchSimulation.Disable();
        toque.performed -= Toque;
    }
    private void Start()
    {
        mainCamera = Camera.main;
    }
    private void Toque(InputAction.CallbackContext obj)
    {
        Vector2 poseToque2D = posicionToque.ReadValue<Vector2>();
        Vector3 poseToque3D = new Vector3(poseToque2D.x, poseToque2D.y, mainCamera.farClipPlane);
        Ray rayoPantalla = mainCamera.ScreenPointToRay(poseToque3D);
        RaycastHit hit;
        if (Physics.Raycast(rayoPantalla,out hit, Mathf.Infinity))
        {
            if (hit.transform.gameObject.tag == "Plataforma")
            {
                if (enPlataformaTocada != null)
                {
                    enPlataformaTocada(hit.transform.gameObject);
                }
            }
        }
    }
}
