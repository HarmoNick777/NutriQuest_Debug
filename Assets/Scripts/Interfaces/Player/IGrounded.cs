using System;

public interface IGrounded
{
    bool isGrounded { get; }

    event Action OnGrounded;
}
