using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject nimbleCharacter;  // The nimble, repairing character
    [SerializeField] private GameObject heavyCharacter;   // The heavy, robot character
    private GameObject activeCharacter;                   // The currently active character
    private PlayerMovement nimbleMovement;                // Reference to nimble character's PlayerMovement script
    private PlayerMovement heavyMovement;                 // Reference to heavy character's PlayerMovement script

    private PlayerMovement activeMovement;

    public float flightForce = 10f;

    private void Awake()
    {
        // Ensure character references are valid
        if (nimbleCharacter == null || heavyCharacter == null)
        {
            Debug.LogError("Character references are not assigned in the Inspector.");
            return;
        }

        // Initially set the nimble character as active
        SwitchToCharacter(nimbleCharacter);
    }

    private void Update()
    {
        // Switch between characters when Tab is pressed
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (activeCharacter == nimbleCharacter)
            {
                SwitchToCharacter(heavyCharacter);
            }
            else
            {
                SwitchToCharacter(nimbleCharacter);
            }
        }
    }

    private void SwitchToCharacter(GameObject newCharacter)
    {
        // Disable the current character's movement
        if (activeCharacter != null)
        {
            activeCharacter.GetComponent<PlayerMovement>().enabled = false;
        }

        // Set the new active character and get its movement component
        activeCharacter = newCharacter;
        activeMovement = activeCharacter.GetComponent<PlayerMovement>();

        // Ensure the movement component is found
        if (activeMovement == null)
        {
            Debug.LogError("PlayerMovement component is missing on the active character.");
            return;
        }

        // Enable the new character's movement
        activeMovement.enabled = true;

        // Update the camera target
        Camera.main.GetComponent<CameraController>().SetTarget(activeCharacter.transform);
    }
    public void StartFlight()
    {
        // Implement flight mechanics, e.g., applying an upward force or modifying gravity
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * flightForce, ForceMode.Impulse);
    }

}
