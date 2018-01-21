using UnityEngine;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;


namespace BustAMove {
    public class BubbleColor : MonoBehaviour {

        public Sprite spriteGreen;
        public Sprite spriteBlue;
        public Sprite spriteRed;
        public Sprite spriteYellow;
        public Sprite spriteOrange;
        public Sprite spritePurple;

        public RColors rColors;

        private SpriteRenderer spriteRenderer;

        void Start() {
            DiscoBal();
        }

        public void DiscoBal() {
            var values = Enum.GetValues(typeof(RColors));
            rColors = (RColors)Random.Range(0, values.Length);

            spriteRenderer = GetComponent<SpriteRenderer>();

            switch (rColors) {
                case RColors.Green:
                    spriteRenderer.sprite = spriteGreen;
                    break;

                case RColors.Blue:
                    spriteRenderer.sprite = spriteBlue;
                    break;

                case RColors.Red:
                    spriteRenderer.sprite = spriteRed;
                    break;

                case RColors.Yellow:
                    spriteRenderer.sprite = spriteYellow;
                    break;

                case RColors.Orange:
                    spriteRenderer.sprite = spriteOrange;
                    break;

                case RColors.Purple:
                    spriteRenderer.sprite = spritePurple;
                    break;
            }
        }

        public enum RColors {
            Green,          // 0
            Blue,           // 1
            Red,            // 2
            Yellow,         // 3
            Orange,         // 4
            Purple          // 5
        }
    }
}
