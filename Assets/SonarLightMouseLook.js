#pragma strict

var lookSensitivity : float = 5;
var yRotation : float;
var xRotation : float;
var currentYRotation : float;
var currentXRotation : float;
var YRotationV : float;
var XRotationV : float;
var lookSmoothDamp : float = 0.1;


function Start () {

}

function Update () {

xRotation += Input.GetAxis("Mouse X") * lookSensitivity;
yRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;


transform.rotation = Quaternion.Euler(yRotation,xRotation,0);

}