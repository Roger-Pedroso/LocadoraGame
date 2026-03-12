using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    [Header("References")]
    public Camera cam;

    [Header("Pan")]
    public float panSpeed = 1f;

    [Header("Zoom")]
    public float zoomSpeed = 0.5f;
    public float minZoom = 3f;    // orthographicSize
    public float maxZoom = 8f;

    [Header("Bounds")]
    public Rect bounds = new Rect(-10f, -10f, 20f, 20f);

    [Header("Double Tap")]
    public float doubleTapTime = 0.35f;
    public float doubleTapMoveSpeed = 10f;

    Vector3 lastPanPosition;
    int panFingerId; // Touch mode only
    bool isPanning;

    float lastTapTimestamp = 0f;

    Vector3 targetPosition;
    bool isMovingToTarget = false;

    void Awake()
    {
        if (cam == null) cam = Camera.main ?? GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.touchSupported && Input.touchCount > 0)
            HandleTouch();
        else
            HandleMouse();

        if (isMovingToTarget)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, targetPosition, Time.deltaTime * doubleTapMoveSpeed);
            if (Vector3.Distance(cam.transform.position, targetPosition) < 0.05f)
                isMovingToTarget = false;
        }
    }

    void HandleTouch()
    {
        if (Input.touchCount == 1)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                lastPanPosition = t.position;
                panFingerId = t.fingerId;
                isPanning = true;
            }
            else if (t.phase == TouchPhase.Moved && isPanning && t.fingerId == panFingerId)
            {
                PanCamera(t.position);
                lastPanPosition = t.position;
            }
            else if (t.phase == TouchPhase.Ended)
            {
                isPanning = false;
                // double tap detection
                if (Time.time - lastTapTimestamp < doubleTapTime)
                {
                    OnDoubleTap(t.position);
                    lastTapTimestamp = 0f;
                }
                else
                {
                    lastTapTimestamp = Time.time;
                }
            }
        }
        else if (Input.touchCount == 2)
        {
            isPanning = false;
            Touch t1 = Input.GetTouch(0);
            Touch t2 = Input.GetTouch(1);

            Vector2 t1Prev = t1.position - t1.deltaPosition;
            Vector2 t2Prev = t2.position - t2.deltaPosition;

            float prevDist = (t1Prev - t2Prev).magnitude;
            float currentDist = (t1.position - t2.position).magnitude;

            float delta = currentDist - prevDist;
            ZoomCamera(delta * zoomSpeed * 0.01f);
        }
    }

    void HandleMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastPanPosition = Input.mousePosition;
            isPanning = true;
        }
        else if (Input.GetMouseButton(0) && isPanning)
        {
            PanCamera(Input.mousePosition);
            lastPanPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isPanning = false;
            if (Time.time - lastTapTimestamp < doubleTapTime)
            {
                OnDoubleTap(Input.mousePosition);
                lastTapTimestamp = 0f;
            }
            else
            {
                lastTapTimestamp = Time.time;
            }
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scroll) > 0.0001f)
        {
            ZoomCamera(-scroll * zoomSpeed * 5f);
        }
    }

    void PanCamera(Vector3 newPanPosition)
    {
        if (cam == null) return;
        // Convert screen movement to world movement
        Vector3 lastWorld = cam.ScreenToWorldPoint(new Vector3(lastPanPosition.x, lastPanPosition.y, cam.nearClipPlane));
        Vector3 newWorld = cam.ScreenToWorldPoint(new Vector3(newPanPosition.x, newPanPosition.y, cam.nearClipPlane));
        Vector3 worldDelta = lastWorld - newWorld;

        Vector3 desired = cam.transform.position + worldDelta;
        cam.transform.position = ClampCameraPosition(desired);
    }

    void ZoomCamera(float delta)
    {
        if (cam == null || !cam.orthographic) return;
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - delta, minZoom, maxZoom);
        cam.transform.position = ClampCameraPosition(cam.transform.position);
    }

    void OnDoubleTap(Vector2 screenPosition)
    {
        if (cam == null) return;
        Vector3 worldPoint = cam.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, cam.nearClipPlane));
        targetPosition = ClampCameraPosition(new Vector3(worldPoint.x, worldPoint.y, cam.transform.position.z));
        isMovingToTarget = true;
    }

    Vector3 ClampCameraPosition(Vector3 target)
    {
        if (cam == null || !cam.orthographic) return target;

        float vertExtent = cam.orthographicSize;
        float horzExtent = vertExtent * cam.aspect;

        float minX = bounds.xMin + horzExtent;
        float maxX = bounds.xMax - horzExtent;
        float minY = bounds.yMin + vertExtent;
        float maxY = bounds.yMax - vertExtent;

        float clampedX = Mathf.Clamp(target.x, minX, maxX);
        float clampedY = Mathf.Clamp(target.y, minY, maxY);

        return new Vector3(clampedX, clampedY, cam.transform.position.z);
    }
}
