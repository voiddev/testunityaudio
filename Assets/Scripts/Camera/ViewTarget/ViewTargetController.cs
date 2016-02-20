using UnityEngine;
using Scripts.Utils;
using Settings = Scripts.Camera.CameraSettings;
using DG.Tweening;

namespace Scripts.Camera.ViewTarget {
    public class ViewTargetController : GameComponentSingleton<ViewTargetController> {

        public Settings.Input input = new Settings.Input();

        public ViewTargetSettings.Movement movement = new ViewTargetSettings.Movement();

        private float horizontalInput;
        private float verticalInput;
        private float mousePanInput;

        private bool moving = false;

        private Vector3 lastPosition;

        protected ViewTargetController() {
        }

        public bool isMoving() {
            return moving;
        }

        void Start() {
            lastPosition = transform.position;
        }

        void Update () {
            UpdateInputs();
            Move();

            if (lastPosition != transform.position) {
                moving = true;
            } else moving = false;
            lastPosition = transform.position;
        }

        private void UpdateInputs() {
            horizontalInput = Input.GetAxis(input.horizontal);
            verticalInput = Input.GetAxis(input.vertical);
        }

        private void Move() {
            if (mousePanInput != 0) {
                LOG.Info("mousePanInput " + mousePanInput);
            } else {
                if (horizontalInput != 0f ) {
                    transform.position += Vector3.right
                    * horizontalInput
                    * movement.speed
                    * Time.deltaTime;
                }

                if (verticalInput != 0f ) {
                    transform.position += Vector3.forward
                    * verticalInput
                    * movement.speed
                    * Time.deltaTime;
                }
            }
//            if (Input.GetKey(KeyCode.Space)) {
//                transform.Translate(Vector3.up * 100f * Time.deltaTime);
//            }
        }
    }
}