using NSubstitute;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerControllerTests
{
    [Test]
    public void PlayerControllerCanCallJump()
    {
        GameObject go = new GameObject();
        PlayerController controller = go.AddComponent<PlayerController>();
        IJump jump = Substitute.For<IJump>();
        controller.Initialize(jump);
        controller.JumpControlActivated();
        jump.Received().Jump();
    }

    
}
