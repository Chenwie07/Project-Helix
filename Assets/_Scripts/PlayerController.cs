using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Event bounceEvent;

    private Rigidbody _playerRb;
    [SerializeField] private float bounceForce = 6f;
    private AudioManager _audio;

    private void Awake()
    {
        _audio = FindObjectOfType<AudioManager>();
        _playerRb = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        _playerRb.velocity = new Vector3(transform.position.x, bounceForce, transform.position.z);
        var _material = collision.gameObject.GetComponent<MeshRenderer>().material.name;
        // print(collision.contacts[0].otherCollider.gameObject.name); // the first collision contact. 
        switch (_material)
        {
            case "mat_SafeFloor (Instance)":
                {
                    if (collision.gameObject.CompareTag("LiveTile")) // if it's a live tile. 
                        bounceEvent.Occurred(collision.contacts[0].otherCollider.gameObject);
                    _audio.Play("Bounce");
                    break;
                }
            case "mat_UnsafeFloor (Instance)":
                {
                    // bounceEvent.Occurred(collision.contacts[0].otherCollider.gameObject); 
                    _audio.Play("Game Over");
                    GameManager.instance.GameOver = true;
                    break;
                }
            case "mat_GoalRing (Instance)":
                {
                    // For Double mode, the partner can not complete the game, but the partner can cause you to fail. 
                    // So, we make sure only the main player (Tagged: Player) can trigger Complete. 
                    if (!GameManager.instance.isLevelComplete && gameObject.CompareTag("Player"))
                    {
                        _audio.Play("Success");
                        GameManager.instance.isLevelComplete = true;
                    }
                    break;
                }
            default:
                break;
        }
    }
}
