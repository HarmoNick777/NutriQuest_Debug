using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;

public class SceneWellConfiguredTests
{
    [SetUp]
    public void Setup()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/GameScene.unity");
    }

    [Test]
    public void PlayerTagIsSet()
    {
        GameObject player = GameObject.Find("Player");
        Assert.AreEqual(player.tag, "Player");
    }
    
    [Test]
    public void PlayerIsWellPositioned()
    {
        GameObject player = GameObject.Find("Player");
        Assert.AreEqual(player.transform.position, new Vector3(0, 0.75f, 0));
    }

    [Test]
    public void CameraIsFollowingThePlayer()
    {
        GameObject player = GameObject.Find("Player");
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        Assert.AreEqual(camera.GetComponent<CameraFollow>().target, player.transform);
    }

    [Test]
    public void PlayerCanReachPlatform()
    {
        PlayerJump playerJump = GameObject.FindObjectOfType<PlayerJump>();
        Assert.IsTrue(playerJump.GetJumpForce() > 7.25);
    }

    [Test]
    public void GroundLayerIsSet()
    {
        GameObject ground = GameObject.Find("Ground");
        Assert.AreEqual(LayerMask.LayerToName(ground.layer), "Ground");
    }

    [Test]
    public void ScoreUIIsPresentAndSetUp()
    {
        ScoreUI scoreText = GameObject.FindObjectOfType<ScoreUI>();
        Assert.IsTrue(scoreText.GetComponent<TextMeshProUGUI>() != null);
    }

    [Test]
    public void AtLeastTwoCollectibleFoodsArePresent()
    {
        FoodCollectible[] collectibleFoods = GameObject.FindObjectsOfType<FoodCollectible>();
        Assert.IsTrue(collectibleFoods.Length > 1);
    }

    [Test]
    public void CollectiblesCanBeCollected()
    {
        Assert.IsTrue(new FoodCollectible() is ICollect);
    }

    [Test]
    public void DeathIsManagedAndScoreIsReset()
    {
        Assert.IsNotNull(GameObject.FindObjectOfType<PlayerDeath>());
    }

    [Test]
    public void AllFoodScoreValuesAreCoherent()
    {
        Assert.IsTrue(GameObject.Find("Apple").GetComponent<FoodScoreEffect>().getScoreValue() > 0);
        Assert.IsTrue(GameObject.Find("Bananas").GetComponent<FoodScoreEffect>().getScoreValue() > 0);
        Assert.IsTrue(GameObject.Find("Pizza").GetComponent<FoodScoreEffect>().getScoreValue() < 0);
        Assert.IsTrue(GameObject.Find("Burger").GetComponent<FoodScoreEffect>().getScoreValue() < 0);
        Assert.IsTrue(GameObject.Find("Grapes").GetComponent<FoodScoreEffect>().getScoreValue() > 0);
        Assert.IsTrue(GameObject.Find("Candy Bar").GetComponent<FoodScoreEffect>().getScoreValue() < 0);
        Assert.IsTrue(GameObject.Find("Fries").GetComponent<FoodScoreEffect>().getScoreValue() < 0);
    }

    [Test]
    public void ExitOnTriggerEnterIsSet()
    {
        GameObject exit = GameObject.FindObjectOfType<ExitLevel>().gameObject;
        OnTrigger onTrigger = exit.GetComponent<OnTrigger>();
        Assert.AreEqual(onTrigger.GetOnTriggerEnter().GetPersistentMethodName(0), "Exit");
    }

    [TearDown]
    public void TearDown()
    {
        EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Single);
    }
}
