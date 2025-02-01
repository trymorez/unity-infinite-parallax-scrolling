using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 inputVector;
    [SerializeField] float moveSpeed = 10.0f;
    bool facingRight = true;

    void Update()
    {
        ProcessMovement();
    }

    void ProcessMovement()
    {
        transform.Translate(inputVector * moveSpeed * Time.deltaTime);
        HandleRotation();
    }

    void HandleRotation()
    {
        if (facingRight && inputVector.x < 0)
        {
            facingRight = false;
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
        }
        else if (!facingRight && inputVector.x > 0)
        {
            facingRight = true;
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        inputVector = context.ReadValue<Vector2>();
    }
}
