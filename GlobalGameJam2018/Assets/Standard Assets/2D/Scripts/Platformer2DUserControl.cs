using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private static float TILT_SENSITIVITY = 0.8f;
        private static float TILT_THRESHOLD = 0.2f;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
         
            }
        }

        public void performJump()
        {
            m_Jump = true;
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);

            //HACKED: Takes acceleration from x axis as horizontal movement instead of inputManager.
            // float h = CrossPlatformInputManager.GetAxis("Horizontal");

            float h = Input.acceleration.x;
            if(h < -TILT_SENSITIVITY) {  h = -1;}
            if(h >  TILT_SENSITIVITY) { h = 1; }
            
            // Pass all parameters to the character control script
            if(h > TILT_THRESHOLD || h < TILT_THRESHOLD) //dead zone to prevent accidental tilts
            {
                m_Character.Move(h, crouch, m_Jump);
            }
            else
            {
                m_Character.Move(0, crouch, m_Jump);
            }

            m_Jump = false;
        }
    }
}
