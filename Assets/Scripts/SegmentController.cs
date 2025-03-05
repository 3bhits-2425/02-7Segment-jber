using UnityEngine;
using UnityEngine.UI;

public class SegmentController : MonoBehaviour
{
    public GameObject[] segments; // 7 Segmente (a-g) in richtiger Reihenfolge
    public GameObject prefab;
    public Button rotateButton; // UI-Button zum Drehen
    public Color activeColor = Color.red;
    public Color inactiveColor = Color.black;
    private bool isRotated = false;

    private readonly bool[,] numberPatterns = new bool[10, 7]
    {
        { true,  true,  true,  true,  true,  true,  false }, // 0
        { false, true,  true,  false, false, false, false }, // 1
        { true,  true,  false, true,  true,  false, true  }, // 2
        { true,  true,  true,  true,  false, false, true  }, // 3
        { false, true,  true,  false, false, true,  true  }, // 4
        { true,  false, true,  true,  false, true,  true  }, // 5
        { true,  false, true,  true,  true,  true,  true  }, // 6
        { true,  true,  true,  false, false, false, false }, // 7
        { true,  true,  true,  true,  true,  true,  true  }, // 8
        { true,  true,  true,  true,  false, true,  true  }  // 9
    };

    void Start()
    {
        if (rotateButton != null)
        {
            rotateButton.onClick.AddListener(RotateObject);
        }
    }

    void Update()
    {
        for (int i = 0; i <= 9; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                SetNumber(i);
            }
        }
    }

    void RotateObject()
    {
        if (prefab == null) return;
        float rotationAngle = isRotated ? -180f : 180f;
        prefab.transform.Rotate(0, rotationAngle, 0);
        isRotated = !isRotated; // Zustand umkehren
        Debug.Log("RotateObject aufgerufen!");
    }

    void SetNumber(int number)
    {
        if (number < 0 || number > 9) return;

        for (int i = 0; i < 7; i++)
        {
            segments[i].GetComponent<Renderer>().material.color = numberPatterns[number, i] ? activeColor : inactiveColor;
        }
    }
}
