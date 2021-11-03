using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject driverCamera;
    public string playerID;
    private float speed = 20f;
    private float turnSpeed = 40f;
    private float horizontalInput, verticalInput;

    void Update()
    {
        //This is where we get player input
        horizontalInput = Input.GetAxis("Horizontal" + playerID);
        verticalInput = Input.GetAxis("Vertical" + playerID);

        // Switch camera view if player presses the Z Key
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (mainCamera.activeInHierarchy)
            {
                mainCamera.SetActive(false);
                driverCamera.SetActive(true);
            }
            else
            {
                mainCamera.SetActive(true);
                driverCamera.SetActive(false);
            }
        }
    }

    void FixedUpdate()
    {
        //We move the vehicle forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
        //We rotate the vehicle
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
    }
}
