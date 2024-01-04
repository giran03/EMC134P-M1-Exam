using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class PaddleScript : MonoBehaviour
{
    [Header("Configs")]
    public float movementSpeed;

    private CharacterController characterController;
    private Vector3 mouseOffset;
    private bool UseMouse;
    private float mouseZCords;

    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        rend.material.SetColor("_Color", Color.grey);
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (UseMouse) return;
        // keyboard controls
        Vector3 move = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        move = transform.TransformDirection(move);
        characterController.Move(movementSpeed * Time.deltaTime * move);
    }

    // mouse drag controls
    private void OnMouseDown()
    {
        mouseZCords = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mouseOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        // pixel cords (x,y)
        Vector3 mousePoint = Input.mousePosition;
        // z cords of game object on screen
        mousePoint.z = mouseZCords;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        // dragging the object and clamping it to the camera view
        Vector3 mousePos = GetMouseWorldPos() + mouseOffset;
        mousePos.z = -58f;
        Vector3 screenMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, mouseZCords));
        Vector3 screenMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, mouseZCords));
        mousePos.x = Mathf.Clamp(mousePos.x, screenMin.x, screenMax.x);
        mousePos.y = Mathf.Clamp(mousePos.y, screenMin.y, screenMax.y);
        transform.position = mousePos;
    }

    public void ChangeControls(bool toggle) {
        UseMouse = toggle;
    }
}
