using UnityEngine;
using UnityEngine.Events;
using System.Collections;

// Unity Event Handler. This is super important. Memorize!
[System.Serializable]
public class PlayerEntered : UnityEvent<Character, ZoneCheck> { };

public class ZoneCheck : MonoBehaviour
{
    // Have a collision check
    public bool collides = false;

	public PlayerEntered onPlayerEnter;

	public Character chaw;

	void OnEnable()
	{
		if (chaw == null)
			Debug.LogError ("what the heck dude");
	}
		                    
    // If Player enters collision zone, return true
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
			onPlayerEnter.Invoke(other.gameObject.GetComponent<Character>(), this);

            collides = true;
        }
    }
    // If the player leaves, return false
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            collides = false;
        }
    }

}
