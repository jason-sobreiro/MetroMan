using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D playerRb;
    [SerializeField]
    private float moveSpeed = 5f;
    private Vector2 movement;
    public InputSystem_Actions actions;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        actions = new InputSystem_Actions();
    }

    void OnEnable()
    {
        actions.Player.Enable();
        actions.Player.Move.performed += OnMovePerformed;
    }

    void OnDisable()
    {
        actions.Player.Move.performed -= OnMovePerformed;
        actions.Player.Disable();   
    }

    public void OnMovePerformed(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        playerRb.linearVelocity = movement * moveSpeed;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
