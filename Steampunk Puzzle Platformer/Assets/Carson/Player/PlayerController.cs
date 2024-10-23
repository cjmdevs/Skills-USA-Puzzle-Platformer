using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject nimbleCharacter;  // The nimble, repairing character
    [SerializeField] private GameObject heavyCharacter;   // The heavy, robot character
    private GameObject activeCharacter;                   // The currently active character
    private PlayerMovement nimbleMovement;                // Reference to nimble character's PlayerMovement script
    private PlayerMovement heavyMovement;                 // Reference to heavy character's PlayerMovement script

    private void Awake()
    {
        // Get references to PlayerMovement scripts
        nimbleMovement = nimbleCharacter.GetComponent<PlayerMovement>();
        heavyMovement = heavyCharacter.GetComponent<PlayerMovement>();

        // Initially set the nimble character as active
        SwitchToCharacter(nimbleCharacter);
    }

    private void Update()
    {
        // Switch between characters when Tab is pressed
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (activeCharacter == nimbleCharacter)
                SwitchToCharacter(heavyCharacter);
            else
                SwitchToCharacter(nimbleCharacter);
        }
    }

    private void SwitchToCharacter(GameObject character)
    {
        // Disable the currently active character's movement script
        if (activeCharacter != null)
        {
            activeCharacter.GetComponent<PlayerMovement>().enabled = false;
        }

        // Set the new active character
        activeCharacter = character;
        activeCharacter.GetComponent<PlayerMovement>().enabled = true;

        // Optionally, reposition the camera or adjust other gameplay elements here.
    }
}
