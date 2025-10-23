using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform cameraLocation;

    public float movementspeed;
    Vector2 look;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateLook();
        
    }
    void UpdateLook()
    {
        look.x += Input.GetAxis("Mouse X");
        look.y += Input.GetAxis("Mouse Y");
        look.y = Mathf.Clamp(look.y, -89f, 89f);
        cameraLocation.localRotation = Quaternion.Euler(-look.y, 0, 0);
        transform.localRotation = Quaternion.Euler(0, look.x, 0);
    }
    void UpdateMovement()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        var input = new Vector3();
        input += transform.forward * y;
        input += transform.right * x;
        input = Vector3.ClampMagnitude(input, 1f);
        transform.Translate(input * movementspeed * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Interactable")
        {
            GameObject canvas = GameObject.Find("PlayerCanvas");
            if (canvas != null)
            {
                GameObject text = canvas.transform.Find("InteractText").gameObject;
                text.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
     {
        if (other.tag == "Interactable")
        {
            GameObject canvas = GameObject.Find("PlayerCanvas");
            if (canvas != null)
            {
                GameObject text = canvas.transform.Find("InteractText").gameObject;
                text.SetActive(false);
            }
        }
    }
}
