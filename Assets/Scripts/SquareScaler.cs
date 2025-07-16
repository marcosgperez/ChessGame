using UnityEngine;

public class SquareScaler : MonoBehaviour {
    public Camera mainCamera;
    public Transform squareTransform;

    void Start() {
        AdjustSquare();
    }

    void AdjustSquare() {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float orthoHeight = mainCamera.orthographicSize * 2f;
        float orthoWidth = orthoHeight * screenRatio;

        float squareSize = Mathf.Min(orthoWidth, orthoHeight) * 0.5f; // 50% del lado más corto
        squareTransform.localScale = new Vector3(squareSize, squareSize, 1f);
    }
}
