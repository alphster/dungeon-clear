using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; protected set; }


    public float speed = 5.0f;
    public float x;
    public float y;
    GameObject player;
    Rigidbody playerRb;
    Vector3? startMousePos;
    Vector3? endMousePos;
    Vector3 startWorldPos;
    Vector3 endWorldPos;
    LineRenderer lr;
    Vector2 startScreenPosKeyboard;
    Vector3 cameraOffset;
    Vector3? mouseDragDir;

    [SerializeField] AnimationCurve ac;

    public InputManager()
    {
        Instance = this;
    }

    private void Awake()
    {
        lr = gameObject.AddComponent<LineRenderer>();
        lr.positionCount = 2;
        lr.useWorldSpace = true;
        lr.enabled = false;
        lr.widthCurve = ac;
        lr.numCapVertices = 10;
        startScreenPosKeyboard = new Vector2(Camera.main.scaledPixelWidth / 2, Camera.main.scaledPixelHeight / 5);
        cameraOffset = Camera.main.transform.forward;
    }

    private void Start()
    {
        player = PlayerManager.Instance.Player;
        playerRb = player.GetComponent<Rigidbody>();
    }

    void Update()
    {
        GetInput();
        MovePlayer();
        DrawLine();
    }

    private void DrawLine()
    {
        if (endMousePos != null)
        {
            startWorldPos = Camera.main.ScreenToWorldPoint((Vector3)startMousePos) + cameraOffset;
            endWorldPos = Camera.main.ScreenToWorldPoint((Vector3)endMousePos) + cameraOffset;
            var worldDragDir = endWorldPos - startWorldPos;
            Vector3 adjustedEndWorldPos;
            if (worldDragDir.magnitude < 1.5f)
            {
                adjustedEndWorldPos = startWorldPos + worldDragDir;
            }
            else
            {
                adjustedEndWorldPos = startWorldPos + worldDragDir.normalized * 1.5f;
            }

            lr.enabled = true;
            lr.SetPosition(0, startWorldPos);
            lr.SetPosition(1, adjustedEndWorldPos);
        }
        else
        {
            lr.enabled = false;
        }
    }

    private void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startMousePos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            endMousePos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            startMousePos = null;
            endMousePos = null;
        }
        else
        {
            // Get the horizontal and vertical axis.
            // By default they are mapped to the arrow keys.
            // The value is in the range -1 to 1
            x = Input.GetAxisRaw("Horizontal");
            y = Input.GetAxisRaw("Vertical");

            if (x != 0 || y != 0)
            {
                startMousePos = startScreenPosKeyboard;
                endMousePos = startScreenPosKeyboard + new Vector2(x, y).normalized * 99;
            }
            else
            {
                startMousePos = null;
                endMousePos = null;
            }
        }

        if (endMousePos != null)
        {
            mouseDragDir = ((Vector3)endMousePos - (Vector3)startMousePos);
        }
        else
        {
            mouseDragDir = null;
        }
    }

    private void MovePlayer()
    {
        if (mouseDragDir != null)
        {
            var nDir = ((Vector3)mouseDragDir).normalized;

            float translateX = nDir.x * speed;
            float translateZ = nDir.y * speed;

            translateX *= Time.deltaTime;
            translateZ *= Time.deltaTime;

            //player.transform.Translate(translateX, 0, translateZ);
            playerRb.MovePosition(playerRb.position + new Vector3(translateX, 0, translateZ));
        }
    }

    public bool IsMoving()
    {
        return mouseDragDir != null;
    }
}

