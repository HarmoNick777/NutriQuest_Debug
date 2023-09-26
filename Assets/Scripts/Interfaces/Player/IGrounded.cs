using System;

public interface IGrounded
{
    bool Grounded { get; }

    event Action OnGrounded;
}
