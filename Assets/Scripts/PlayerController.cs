using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player player;
    private IPlayerCommand _jumpCommand;
    private IPlayerCommand _moveRightCommand;
    private IPlayerCommand _moveLeftCommand;

    private bool _isMovementInverted;
    private bool _isGrounded;

    private void Awake()
    {
        _jumpCommand = new JumpCommand(player);
        _moveRightCommand = new MoveRightCommand(player);
        _moveLeftCommand = new MoveLeftCommand(player);
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded|| Input.GetKeyDown(KeyCode.W) && _isGrounded)
        {
            _jumpCommand.Execute(_isMovementInverted);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _moveLeftCommand.Execute(_isMovementInverted);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _moveRightCommand.Execute(_isMovementInverted);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleMovementInvert();
        }
    }

    public void ToggleMovementInvert()
    {
        _isMovementInverted = !_isMovementInverted;
        Debug.Log("Player movement inverted");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
            Debug.Log("isGrounded true");
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
            Debug.Log("isGrounded false");

        }
    }
}
