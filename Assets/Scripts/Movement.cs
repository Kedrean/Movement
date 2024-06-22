using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    public float rotSpeed;
    public float jumpForce;
	
    public int score;
	
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * moveSpeed;
        float rotation = Input.GetAxis("Horizontal") * rotSpeed; 

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (Input.GetButton("Jump"))
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
		
		Debug.Log($"Current moveSpeed: {moveSpeed}");

        /* if (Input.GetKeyDown(KeyCode.W))
        {
            // Vector3.forward = (0, 0, 1)
            // transform.Translate(Vector3.forward * (Time.deltaTime * moveSpeed));
            // transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
            transform.Rotate(Vector3.forward, Time.deltaTime * rotSpeed);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            // Vector3.forward = (0, 0, 1)
            // transform.Translate(Vector3.back * (Time.deltaTime * moveSpeed));
            // transform.position += Vector3.back * moveSpeed * Time.deltaTime;
            transform.Rotate(Vector3.back, Time.deltaTime * rotSpeed);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            // Vector3.forward = (0, 0, 1)
            // transform.Translate(Vector3.left * (Time.deltaTime * moveSpeed));
            // transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            transform.Rotate(Vector3.left * Time.deltaTime * rotSpeed);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            // Vector3.forward = (0, 0, 1)
            // transform.Translate(Vector3.right * (Time.deltaTime * moveSpeed));
            // transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            transform.Rotate(Vector3.right, Time.deltaTime * rotSpeed);
        } */
    }
	
	public void ApplyBoost(float boostAmount, float duration)
    {
        StartCoroutine(SpeedBoost(boostAmount, duration));
    }

    private IEnumerator SpeedBoost(float boostAmount, float duration)
    {
        moveSpeed += boostAmount;
        Debug.Log($"Speed boosted! New move speed: {moveSpeed}");
        yield return new WaitForSeconds(duration);
        moveSpeed -= boostAmount;
        Debug.Log($"Speed boost ended. New move speed: {moveSpeed}");
    }
}
