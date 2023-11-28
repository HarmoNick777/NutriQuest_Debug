using NSubstitute;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerTests
{
    GameObject _player;
    Rigidbody _rb;
    IMove _move;
    IJump _jump;
    IGrounded _grounded;

    [SetUp]
    public void SetUp()
    {
        _player = new GameObject();
        _rb = _player.AddComponent<Rigidbody>();
        _move = Substitute.For<IMove>();
        _jump = Substitute.For<IJump>();
        _grounded = Substitute.For<IGrounded>();
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(_player);
    }
    
    [Test]
    public void PlayerControllerCanCallJump()
    {
        PlayerController controller = _player.AddComponent<PlayerController>();
        controller.Initialize(_move, _jump);
        controller.JumpControlActivated();
        _jump.Received().Jump();
    }

    [UnityTest]
    public IEnumerator PlayerCanJumpWhenGrounded()
    {
        PlayerJump playerJump = _player.AddComponent<PlayerJump>();
        _grounded.isGrounded.Returns(true);
        playerJump.Initialize(_rb, _grounded);

        float playerYVelocity = _rb.velocity.y;
        float playerYPosition = _rb.position.y;
        playerJump.Jump();
        yield return new WaitForSeconds(0.1f);

        Assert.That(_rb.velocity.y, Is.GreaterThan(playerYVelocity));
        Assert.That(_rb.position.y, Is.GreaterThan(playerYPosition));
    }

    [UnityTest]
    public IEnumerator PlayerCantJumpWhenNotGrounded()
    {
        PlayerJump playerJump = _player.AddComponent<PlayerJump>();
        _grounded.isGrounded.Returns(false);
        playerJump.Initialize(_rb, _grounded);

        float playerYVelocity = _rb.velocity.y;
        float playerYPosition = _rb.position.y;
        playerJump.Jump();
        yield return new WaitForSeconds(0.1f);

        Assert.That(_rb.velocity.y, Is.LessThanOrEqualTo(playerYVelocity));
        Assert.That(_rb.position.y, Is.LessThanOrEqualTo(playerYPosition));
    }

    [UnityTest]
    public IEnumerator PlayerCanMove()
    {
        PlayerMovement playerMovement = _player.AddComponent<PlayerMovement>();
        playerMovement.Initialize(_rb);

        float playerXPosition = _rb.position.x;
        float playerZPosition = _rb.position.z;
        playerMovement.Move(new Vector2(0.1f, 0.1f));
        yield return new WaitForSeconds(0.1f);

        Assert.That(_rb.position.x, Is.GreaterThan(playerXPosition));
        Assert.That(_rb.position.z, Is.GreaterThan(playerZPosition));
    }

    [UnityTest]
    public IEnumerator PlayerIsFallingWhenNotOnTheGround()
    {
        float playerYPosition = _rb.position.y;
        yield return new WaitForSeconds(0.1f);

        Assert.That(_rb.position.y, Is.LessThan(playerYPosition));
    }
    
    [UnityTest]
    public IEnumerator PlayerIsNotFallingWhenOnTheGround()
    {
        float playerYPosition = _rb.position.y;
        yield return new WaitForSeconds(0.1f);

        Assert.That(_rb.position.y, Is.LessThan(playerYPosition));
    }
}
