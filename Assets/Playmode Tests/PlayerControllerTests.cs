using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerControllerTests
{
    [Test]
    public void PlayerControllerCanCallJumpTest()
    {
        GameObject go = new GameObject();
        PlayerController controller = go.AddComponent<PlayerController>();
        IJump jump = Substitute.For<IJump>();
        controller.Initialize(jump);
        controller.JumpControlActivated();
        jump.Received().Jump();
    }

    
}
