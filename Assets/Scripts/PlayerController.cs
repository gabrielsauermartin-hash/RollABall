using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections;
using NUnit.Framework;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    public float speed = 0;
    public TextMeshProUGUI countText;

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int count;
    private Vector3 jump;
    private float jumpForce = 2.0f;
    private bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        jump = new Vector3(0.0f, 2.0f, 0.0f);

        SetCountText();

        gameManager = FindFirstObjectByType<GameManager>();
    }

    void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        //Function body
        Vector2 movementVector = context.ReadValue<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 12)
        {
            gameManager.EndGame(true);

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameManager.EndGame(false);
            Destroy(gameObject);
        }
    }

    public void RestartGame()
    {
        Debug.Log("Botón fue pulsado! Reiniciando...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
