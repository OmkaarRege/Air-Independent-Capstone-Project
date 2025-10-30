using UnityEngine;

public class CloudedThoughts : MonoBehaviour
{
    public GameObject playerObject;

    private Camera mainCamera;
    public float moveSpeed, upspeed, initialX,initialY, screenWidth, screenHeight;

    private Vector2 screenBounds;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        mainCamera = Camera.main;
        screenHeight = mainCamera.orthographicSize * 2;
        screenWidth = screenHeight * mainCamera.aspect;
        SpriteRenderer spriteRenderer = playerObject.GetComponent<SpriteRenderer>();
        initialX = playerObject.transform.position.x;
       
    }

    void Update()
    {
        Move();
        
        Vector3 playertransform = playerObject.transform.position;
        playertransform.x = Mathf.Clamp(playertransform.x, initialX - (screenWidth/2), initialX + (screenWidth/2));
        playerObject.transform.position = playertransform;
    }
    
    void Move()
    {
        Vector2 movement = new Vector2(0,upspeed);

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
