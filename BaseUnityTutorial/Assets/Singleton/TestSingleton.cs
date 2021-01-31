using Singleton;
using System;
using UnityEngine;

public class TestSingleton : MonoBehaviour
{
    private void Start()
    {
        Player.instance.Say();
        /*var player = new Player();
        player.Name = "Test";
        player.Say();*/
        /*var player = gameObject.AddComponent<Player>();
        player.Name = "Test2";
        player.Say();*/
        var player = (Player)Activator.CreateInstance(typeof(Player), true);
        player.Name = "Test3";
        player.Say();
    }
}
