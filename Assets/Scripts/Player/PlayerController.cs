using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float speed = 13;
    private Vector2 moveDir;
    [SerializeField] private Rigidbody rb;
    [SerializeField] PlayerInventory inventory;
    [SerializeField] Weapon weapon;
    [SerializeField] private Image[] LoadOutUI;

    private Image selectedImage;


    // Start is called before the first frame update
    void Start()
    {
        selectedImage = LoadOutUI[0];
        SetImageColor(0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDir.x, 0, moveDir.y);
    }

    //converting input to a format readable to rb.velocity
    public void DoMovement(InputAction.CallbackContext context)
    {
        moveDir = context.ReadValue<Vector2>();  
        moveDir *= speed;
        transform.rotation = Quaternion.Slerp(Quaternion.identity, Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + (-30 * context.ReadValue<Vector2>().x)), 2);
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            weapon.Shoot();
        }
    }

    public void SelectFirstInv(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            
            inventory.EquipWeapon(1);
            weapon.SetData(inventory.equippedWeapon); // Hack
            SetImageColor(0);

        }
    }

    public void SelectSecondInv(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            inventory.EquipWeapon(2);
            weapon.SetData(inventory.equippedWeapon);
            SetImageColor(1);


        }
    }

    public void SelectThirdInv(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            inventory.EquipWeapon(3);
            weapon.SetData(inventory.equippedWeapon);
            SetImageColor(2);


        }
    }


    //showing your weapon selection on UI based on what you click
    private void SetImageColor(int imNumb)
    {
        selectedImage.color = Color.white;
        selectedImage = LoadOutUI[imNumb];
        selectedImage.color = Color.red;

    }
}

