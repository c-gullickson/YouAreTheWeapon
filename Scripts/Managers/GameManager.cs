using UnityEngine;
using Weapon.Factory;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private async void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        
        // Initialize the Weapon Database
        await WeaponDatabase.Initialize();

        Debug.Log("Weapon Database Initialized!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
