using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class EasingTPCC : MonoBehaviour
{
    private static readonly int Speed = Animator.StringToHash("Speed");
    public float walkingSpeed = 2f;
    public float sprintSpeed = 8f;
    public float rotationSpeed = 60f;
    [Range(0.1f, 2f)] public float easingFactor = 0.5f;
    private bool isSprinting;
    private float rotation;
    private float currentSpeed;
    private CharacterController characterController;
    private Animator anim;
    
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        // Rotate with A-D
        float turnInput = Input.GetAxis("Horizontal");
        float turn = turnInput * rotationSpeed;
        transform.Rotate(0, turn * Time.deltaTime, 0);

        // Move with W-S
        // Sprint with Left Shift
        float pace = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkingSpeed;
        float targetSpeed = pace * Input.GetAxis("Vertical");
        if (targetSpeed < -walkingSpeed) targetSpeed = -walkingSpeed;
        
        // ease from currentSpeed to targetSpeed
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, Time.deltaTime / easingFactor);
        
        Vector3 movement = currentSpeed * transform.forward;
        characterController.SimpleMove(movement);
        anim.SetFloat(Speed, currentSpeed);
    }
}