using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public Transform muzzle;
    public Camera cam;
    public float range = 100f;
    public int damage = 1;
    private InputAction shootAction;

    void OnEnable()
    {
        shootAction = new InputAction(type: InputActionType.Button, binding: "<Mouse>/leftButton");
        shootAction.Enable();
    }

    void OnDisable()
    {
        shootAction.Disable();
    }

    void Update()
    {
        if (shootAction.triggered)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("“G‚Éƒqƒbƒg");

                Target target = hit.collider.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }

            }
        }
    }
}