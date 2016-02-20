using System;
using UnityEditor;
using UnityEngine;


namespace Camera {
//    public class RTSCamera : MonoBehaviour {
//
//        public LayerMask groundLayer;
//        public Settings SETTINGS = new Settings();
//
//        Vector3 destination = Vector3.zero;
//        Vector3 camVel = Vector3.zero;
//        Vector3 previousMousePos = Vector3.zero;
//        Vector3 currentMousePos = Vector3.zero;
//        float panInput;
//        float orbitInput;
//        float zoomInput;
//
//
//        void Start() {
//            panInput = 0f;
//            orbitInput = 0f;
//            zoomInput = 0f;
//        }
//
//        void Update() {
//            panInput = Input.GetAxis(SETTINGS.INPUT.panInputName);
//            orbitInput = Input.GetAxis(SETTINGS.INPUT.orbitYInputName);
//            zoomInput = Input.GetAxis(SETTINGS.INPUT.zoomInputName);
//
//            previousMousePos = currentMousePos;
//            currentMousePos = Input.mousePosition;
//
//            Zoom();
//            Rotate();
//            PanWorld();
//
//        }
//
//        void FixedUpdate() {
//            HandleCameraDistance();
//        }
//
//        float GetPanDirection() {
//            return SETTINGS.POSITION.invertPan ? -1f : 1f;
//        }
//
//        void PanWorld() {
//            if (panInput > 0f) {
//                Vector3 targetPos = transform.position;
//
//                targetPos += transform.right
//                * (currentMousePos.x - previousMousePos.x)
//                * SETTINGS.POSITION.panSmooth
//                * GetPanDirection()
//                * Time.deltaTime;
//
//                targetPos +=
//                Vector3.forward
//                * (currentMousePos.y - previousMousePos.y)
//                * SETTINGS.POSITION.panSmooth
//                * GetPanDirection()
//                * Time.deltaTime;
//
//                transform.position = targetPos;
//            }
//        }
//
//        void HandleCameraDistance() {
//            Ray ray = new Ray(transform.position, transform.forward);
//            RaycastHit hit;
//            if (Physics.Raycast(ray, out hit, 100, groundLayer))
//            {
//                destination = Vector3.Normalize(transform.position - hit.point) * SETTINGS.POSITION.distanceFromGround;
//                destination += hit.point;
//
//                transform.position = Vector3.SmoothDamp(transform.position, destination, ref camVel, 0.3f);
//            }
//
//
//        }
//
//        void Zoom() {
//            if (!SETTINGS.POSITION.allowZoom)
//            {
//                return;
//            }
//
//
//
//            SETTINGS.POSITION.newDistance += SETTINGS.POSITION.zoomStep * -zoomInput;
//
//            SETTINGS.POSITION.distanceFromGround = Mathf.Lerp(
//                    SETTINGS.POSITION.distanceFromGround,
//                    SETTINGS.POSITION.newDistance,
//                    SETTINGS.POSITION.zoomSmooth * Time.deltaTime
//            );
//
//            if (SETTINGS.POSITION.distanceFromGround < SETTINGS.POSITION.maxZoom)
//            {
//                SETTINGS.POSITION.distanceFromGround = SETTINGS.POSITION.maxZoom;
//                SETTINGS.POSITION.newDistance = SETTINGS.POSITION.maxZoom;
//
//            }
//
//            if (SETTINGS.POSITION.distanceFromGround > SETTINGS.POSITION.minZoom)
//            {
//                SETTINGS.POSITION.distanceFromGround = SETTINGS.POSITION.minZoom;
//                SETTINGS.POSITION.newDistance = SETTINGS.POSITION.minZoom;
//            }
//        }
//
//        void Rotate() {
//            if (!SETTINGS.ORBIT.allowYOrbit)
//            {
//                return;
//            }
//            if (orbitInput > 0)
//            {
//                SETTINGS.ORBIT.yRotation += (currentMousePos.x - previousMousePos.x) * SETTINGS.ORBIT.yOrbitSmooth * Time.deltaTime;
//            }
//            transform.rotation = Quaternion.Euler(SETTINGS.ORBIT.xRotation, SETTINGS.ORBIT.yRotation, 0);
//        }
//
//
//
//
//    }

}
