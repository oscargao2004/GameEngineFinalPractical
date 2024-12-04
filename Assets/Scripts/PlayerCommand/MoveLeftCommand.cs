using UnityEngine;

public class MoveLeftCommand : IPlayerCommand
{
    public MoveLeftCommand(Player player)
    {
        rb = player.GetComponent<Rigidbody2D>();
        _player = player;
    }

    private Rigidbody2D rb;
    private Player _player;
    public void Execute(bool invert)
    {
        switch (invert)
        {
            //normal movement
            case false:
            {
                rb.linearVelocity = new Vector2(-1 * _player.speed, rb.linearVelocity.y) ;
            }
                break;
            //inverted movement
            case true:
                rb.linearVelocity = -new Vector2(-1 * _player.speed, rb.linearVelocity.y);
                break;
            default:
                break;
        }
    }
}
