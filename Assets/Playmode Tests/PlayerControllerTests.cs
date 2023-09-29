using NSubstitute;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerControllerTests
{
    [SetUp]
    public void Setup()
    {
        EditorSceneManager.LoadScene("Assets/Scenes/GameScene.unity");
    }
    
    [Test]
    public void LayerMaskIsProperlySet()
    {
        GameObject go = GameObject.Find("Ground");
        Assert.AreEqual(LayerMask.LayerToName(go.layer), "Ground");
    }
    
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
