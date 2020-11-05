using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController characterController;
    public IPlayerInput PlayerInput { get; set; } = new PlayerInput();

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 movementInput = new Vector3(0, 0, PlayerInput.Vertical);
        Vector3 movement = transform.rotation * movementInput;
        characterController.SimpleMove(movement);
    }
}

public class PlayerInput : IPlayerInput
{
    public float Vertical
    {
        get => Input.GetAxis("Vertical");
    }
}

public interface IPlayerInput
{
    float Vertical
    {
        get;
    }
}