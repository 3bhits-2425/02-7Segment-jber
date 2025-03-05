using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public GameObject targetObject; // Das Prefab oder Objekt, das gedreht werden soll
    public Vector3 rotationSpeed = new Vector3(0, 100, 0); // Rotation in Grad pro Sekunde
    public bool rotateContinuously = true; // Soll sich das Objekt immer drehen?
    public KeyCode rotateKey = KeyCode.Space; // Taste zum Drehen, falls nicht kontinuierlich

    void Update()
    {
        if (targetObject == null) return;

        if (rotateContinuously)
        {
            targetObject.transform.Rotate(rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(rotateKey))
        {
            targetObject.transform.Rotate(rotationSpeed * Time.deltaTime);
        }
    }
}