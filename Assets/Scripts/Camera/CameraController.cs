using Scripts.Camera.ViewTarget;

using Scripts.Utils;
using UnityEngine;
using Settings = Scripts.Camera.CameraSettings;


namespace Scripts.Camera {
    public class CameraController : GameComponentSingleton<CameraController> {

        public GameObject fpsTarget;

        public Settings.Input input = new Settings.Input();
        public Settings.RTSCameraSetting.Panning panning = new Settings.RTSCameraSetting.Panning();
        public Settings.FPSCameraSetting.Movement movement = new Settings.FPSCameraSetting.Movement();

        public string test = "test";
        public Vector3 cameraOffset = new Vector3(0, 20, -30);


        private float panInput;
        private float prevPanInput;
        private Vector3 prevMousePos;

        private ViewTargetController fpsTargetController;
        private Vector3 targetVelocity = Vector3.zero;

        void Start() {
            prevMousePos = Vector3.zero;

            fpsTargetController = fpsTarget.GetComponent(
                    typeof(ViewTargetController).Name
            ) as ViewTargetController;
        }

        void Update() {

            UpdateInputs();

            if (panInput != 0) {
                //                Pan();
                //                MoveTo(fpsTarget);
            } else {
                if (!isVelocityZero()) {

                    SmoothMoveTo(fpsTarget, true, movement.smooth);
                } else if (fpsTargetController.isMoving()) {
                    LOG.Info("Smooth move");
                    SmoothMoveTo(fpsTarget, true, movement.smooth);
                }
            }

            prevMousePos = Input.mousePosition;
        }

        private void UpdateInputs() {
            panInput = Input.GetAxis(input.mousePan);
        }

        private void Pan() {

            Vector3 newPos = fpsTarget.transform.position;

            newPos += Vector3.right
            * -(Input.mousePosition.x - prevMousePos.x)
            * panning.speed
            * Time.deltaTime;

            newPos += Vector3.forward
            * -(Input.mousePosition.y - prevMousePos.y)
            * panning.speed
            * Time.deltaTime;

            //fpsTarget.transform.position = Vector3.Lerp(fpsTarget.transform.position, newPos, 1f);

            fpsTarget.transform.position = newPos;

            prevPanInput = panInput;


        }

        public bool isPanning() {
            return prevPanInput == panInput;
        }

        // FPS Behaviour
        bool isVelocityZero() {
            if (
            Mathf.Round(targetVelocity.x) == 0f &&
            Mathf.Round(targetVelocity.y) == 0f &&
            Mathf.Round(targetVelocity.z) == 0f
            ) {
                return true;
            } else
                return false;
        }

        void SmoothMoveTo(GameObject target, bool lookAtTarget, float smooth) {

            Vector3 position = target.transform.position + cameraOffset;

            transform.position = Vector3.SmoothDamp(
                    transform.position,
                    position,
                    ref targetVelocity,
                    smooth
            );
            if (lookAtTarget) {
                transform.LookAt(target.transform);
            }
        }

        void MoveTo(GameObject target) {
            Vector3 position = target.transform.position + cameraOffset;

            //cant use because camera is jump
            //            transform.position = Vector3.Lerp(transform.position, position, 1f * Time.deltaTime);
            //            transform.LookAt(target.transform);
            transform.position = position;
        }


    }
}