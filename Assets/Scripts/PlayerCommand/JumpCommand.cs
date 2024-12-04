using UnityEngine;

public class JumpCommand : IPlayerCommand
{
    public JumpCommand(Player player)
    {
        rb = player.GetComponent<Rigidbody2D>();
        _player = player;
    }

    private Rigidbody2D rb;
    Player _player;
    public void Execute(bool invert)
    {
        switch (invert)
        {
            //normal movement
            case false:
            {
                rb.AddForce(Vector2.up * _player.jumpForce, ForceMode2D.Impulse);
            }
                break;
            //inverted movement
            case true:
            {
                Debug.Log("Jump Disabled");
                //disable jump
            }
                break;
            default:
                break;
        }
    }
}
