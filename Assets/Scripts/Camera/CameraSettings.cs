using System;
using UnityEngine;

namespace Scripts.Camera {

    public class CameraSettings {

        [Serializable]
        public class Input {
            public string horizontal = "Horizontal";
            public string vertical = "Vertical";
            public string mousePan = "MousePan";
        }

        [Serializable]
        public class FPSCameraSetting {
            [Serializable]
            public class Movement {
                public float smooth = 0.05f;
            }
        }


        [Serializable]
        public class RTSCameraSetting {
            [Serializable]
            public class Panning {
                public float speed = 200f;
            }
        }

    }

}