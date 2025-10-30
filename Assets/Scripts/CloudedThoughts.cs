using UnityEngine;

public class CloudedThoughts : MonoBehaviour
{
    public GameObject playerObject;

    private Camera mainCamera;
    public float moveSpeed, initialX,initialY, screenWidth, screenHeight;

    private Vector2 screenBounds;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        mainCamera = Camera.main;

        screenHeight = mainCamera.orthographicSize * 2;
        screenWidth = screenHeight * mainCamera.aspect;
        
        SpriteRenderer spriteRenderer = playerObject.GetComponent<SpriteRenderer>();
        
        Debug.Log("Screen bounds X coordinate: " + screenWidth.ToString());
    
    }

    void Update()
    {
        if (playerObject.transform.position.x < (initialX + (screenWidth / 2)))
        {

            Vector2 movement = Vector2.zero;


            // Check for 'W' or Up Arrow key press
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                movement.y += 1f;
            }

            // Check for 'S' or Down Arrow key press
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                movement.y -= 1f;
            }

            // Check for 'A' or Left Arrow key press
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                movement.x -= 1f;
            }

            // Check for 'D' or Right Arrow key press
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                movement.x += 1f;
            }

            // Normalize the movement vector to prevent faster diagonal movement
            if (movement.magnitude > 1f)
            {
                movement.Normalize();
            }

            // Apply movement to the object's position
            playerObject.transform.Translate(movement * moveSpeed * Time.deltaTime);
        }
            
       
    }

       

        
    
}
