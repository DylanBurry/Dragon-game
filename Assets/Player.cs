using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player player;
    public float speed = 1;
    public Transform oculusCamera;
    public float rotationSpeed = 1;
    private CharacterController playerControl;
    public int jumpCount = 2;
    public int jumpsLeft;
    public float jumpForce;
    public float jumpTime;
    public float jumpTimeCounter;
    public float terminal;
    private bool pressed;
    public bool isGrounded;
    public bool jumpButton;
    public bool pauseButton;
    private bool jumpButtonPressed;
    private bool jumpButtonReleased;
    private Vector3 moveDirection;
    public float gravityScale;
    public GameObject Ending;
    public GameObject PauseMenu;
    public UnityEngine.UI.Button btn;

    public int coinCount;
    public int FragCount;

    // Start is called before the first frame update
    void Awake()
    {
        playerControl = GetComponent<CharacterController>();
        jumpTimeCounter = jumpTime;
        jumpsLeft = jumpCount;
        player = this;
    }


    void Update()
    {

        if (controlScript.controlscript.mouseControl == false)
        {
            jumpButton = OVRInput.Get(OVRInput.RawButton.A);
            jumpButtonPressed = OVRInput.GetDown(OVRInput.RawButton.A);
            jumpButtonReleased = OVRInput.GetUp(OVRInput.RawButton.A);
            pauseButton = OVRInput.GetDown(OVRInput.RawButton.Start);
        }
        else
        {
            jumpButton = Input.GetKey(KeyCode.Space);
            jumpButtonPressed = Input.GetKeyDown(KeyCode.Space);
            jumpButtonReleased = Input.GetKeyUp(KeyCode.Space);
            pauseButton = Input.GetKeyDown(KeyCode.Escape);
        }
        
        isGrounded = playerControl.isGrounded;

        float xAxis; 
        float yAxis; 

        if(controlScript.controlscript.mouseControl == false)
        {
            xAxis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch).x;
            yAxis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch).y;
        }
        else
        {
            xAxis = Input.GetAxis("Horizontal");
            yAxis = Input.GetAxis("Vertical");
        }
        
        float moveAngle = Mathf.Atan2(yAxis, xAxis) * Mathf.Rad2Deg - 90;

        Debug.Log(xAxis);



        /*
        if (isGrounded)
        {
            //currentJump = 0;

        }

        if (isGrounded == false)
        {
            if (jumpButtonReleased)
            {
                jumpTimeCounter = 0;
                jumpsLeft--;
                
            }
            else if (jumpButtonPressed)
            {
                jumpTimeCounter = jumpTime;
            }
        }

        if (jumpTimeCounter > 0 && jumpsLeft >= 0)
        {
            if (jumpButton)
            {
                moveDirection.y += jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
        }*/
        if (Time.timeScale != 0)
        {
            if (jumpTimeCounter > 0 && jumpsLeft >= 0)
            {
                if (jumpButton)
                {
                    moveDirection.y = jumpForce;
                    jumpTimeCounter -= Time.deltaTime;
                }
            }

            if (isGrounded)
            {
                jumpTimeCounter = jumpTime;
                jumpsLeft = jumpCount;
            }
            else
            {
                if (jumpButtonReleased)
                {
                    jumpTimeCounter = 0;

                }
                moveDirection.y += (Physics.gravity.y * gravityScale);
                if(moveDirection.y < terminal)
                {
                    moveDirection.y = terminal;
                }
            }

            if (jumpButtonPressed && jumpsLeft > 0)
            {
                jumpTimeCounter = jumpTime;
                jumpsLeft--;
            }



            if (xAxis != 0 || yAxis != 0)
            {
                float cameraAngle = Mathf.Atan2(transform.position.y - oculusCamera.position.y, transform.position.x - oculusCamera.position.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -moveAngle + oculusCamera.rotation.eulerAngles.y, 0), rotationSpeed);
            }
            //Debug.Log(Mathf.Abs(xAxis) + Mathf.Abs(yAxis));
            //transform.position += transform.forward * (Mathf.Max(Mathf.Abs(xAxis), Mathf.Abs(yAxis))) * speed * Time.deltaTime;
            float yStore = moveDirection.y;
            moveDirection = (transform.forward * (Mathf.Max(Mathf.Abs(xAxis), Mathf.Abs(yAxis))));
            moveDirection = moveDirection * speed;
            moveDirection.y = yStore;
            playerControl.Move(moveDirection * Time.deltaTime);
        }


        /*if (currentJump != 0)
        {
            playerControl.velocity = Vector3.Scale(playerControl.velocity, new Vector3(1, 0, 1));
            playerControl.angularVelocity = Vector3.Scale(playerControl.velocity, new Vector3(1, 0, 1));
        }

        jumpForce += jumpAcceleration;


        if (currentJump != jumpCount)
        {

             playerControl.AddForce(new Vector3(0, jumpForce, 0));
             currentJump++;
        }*/
        //}
        if (GameData.Instance.FragCount == 4)
        {
            if (GameData.Instance.Ending == true)
            {
                Ending.SetActive(true);
                if (Ending.activeSelf == true)
                {
                    Time.timeScale = 0;
                }
                else
                {
                    Time.timeScale = 1;
                }

                if (jumpButton)
                {
                    Time.timeScale = 1;
                    Ending.SetActive(false);
                    GameData.Instance.Ending = false;
                }
            }
        }

        if (pauseButton)
        {
            if (PauseMenu.activeSelf == false)
            {
                PauseMenu.SetActive(true);
                
                btn.Select();
            }
        }

        if (PauseMenu.activeSelf == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
