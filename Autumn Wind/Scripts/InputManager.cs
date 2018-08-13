using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Autumn_Wind {
    public class InputManager {

        // Controllers
        // REMINDER: Might need to be public?
        private KeyboardState keyboard = Keyboard.GetState();
        private GamePadState gamePad = GamePad.GetState(1);

        // Keyboard Controls
        public Keys leftKeyPrimary = Keys.A;
        public Keys leftKeySecondary = Keys.Left;
        public Keys rightKeyPrimary = Keys.D;
        public Keys rightKeySecondary = Keys.Right;
        public Keys jumpKeyPrimary = Keys.Space;
        public Keys crouchKeyPrimary = Keys.LeftControl;
        public Keys crouchKeySecondary = Keys.RightControl;
        public Keys attackKeyPrimary = Keys.L;

        // GamePad Controls
        public Buttons jumpButtonController = Buttons.A;
        public Buttons crouchButtonController = Buttons.B;
        public Buttons attackButtonController = Buttons.RightTrigger;

        // GamePad Axes
        public float horizontalAxis;

        // Control booleans
        private bool leftInput;
        private bool rightInput;
        private bool jumpInput;
        private bool crouchInput;
        private bool attackInput;

        public enum InputType { button, axis }

        public struct Input {
            private InputType _type;

            public string name;
            public bool active;
            public float axisValue;

            public Input(string _name, InputType type) {
                name = _name;
                active = false;
                axisValue = 0;
                _type = type;
            }

            public void SetActive(bool change) => active = change;
            public void SetValue(float newValue) => axisValue = newValue;

            public bool GetActive() => active;
            public float GetValue() => axisValue;
            public InputType GetInputType() => _type;
        }

        private List<Input> _inputs;
        private int _inputLength;
        private float _controllerDeadzone = 0.5f;

        public InputManager() {
            _inputs = new List<Input> {
                new Input("Jump", InputType.button),
                new Input("Crouch", InputType.button),
                new Input("Attack", InputType.button),
                new Input("Horizontal", InputType.axis)
            };

            _inputLength = _inputs.Capacity;
        }

        public void Update() {

        }

        private void ManageButtons() {
            // Jump
            _inputs[0].SetActive(keyboard.IsKeyDown(jumpKeyPrimary) || gamePad.IsButtonDown(jumpButtonController));
            // Crouch
            _inputs[1].SetActive(keyboard.IsKeyDown(crouchKeyPrimary) || keyboard.IsKeyDown(crouchKeySecondary) || gamePad.IsButtonDown(crouchButtonController));
            // TODO: Rewrite crouch to be toggle instead of current method.
            // Attack
            _inputs[2].SetActive(keyboard.IsKeyDown(attackKeyPrimary) || gamePad.IsButtonDown(attackButtonController));
        }

        private void ManageAxes() {
            // Left movement: horizontal axis
            if (keyboard.IsKeyDown(leftKeyPrimary) || keyboard.IsKeyDown(leftKeySecondary) || gamePad.ThumbSticks.Left.X < -_controllerDeadzone) {
                _inputs[3].SetValue(-1);
            }
            
            // Right movement: horizontal axis
            if (keyboard.IsKeyDown(rightKeyPrimary) || keyboard.IsKeyDown(rightKeySecondary) || gamePad.ThumbSticks.Right.X > _controllerDeadzone) {
                _inputs[3].SetValue(1);
            }
        }

        public bool GetButtonDown(int index) {
            if (index < _inputLength) {
                return _inputs[index].GetActive();
            }
            else {
                return false;
            }
        }

        public bool GetButtonDown(string inputName) {
            foreach (var input in _inputs) {
                if (input.name == inputName) {
                    return input.active;
                }
            }

            return false;
        }

        public float GetAxisValue(int index) {
            if (index < _inputLength) {
                return _inputs[index].GetValue();
            }
            else {
                return 0;
            }
        }

        public float GetAxisValue(string axisName) {
            foreach (var input in _inputs) {
                if (input.name == axisName) {
                    return input.axisValue;
                }
            }

            return 0;
        }
    }
}
