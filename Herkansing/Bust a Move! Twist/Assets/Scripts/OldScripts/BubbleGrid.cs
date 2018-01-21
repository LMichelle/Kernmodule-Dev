using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BustAMove { 
    public class BubbleGrid: MonoBehaviour {
        public Transform BubblePrefab;     

        public int gridHeight = 14;         
        public int gridWidth = 6;

        float bubbleHeight = 1.0f;
        float bubbleWidth = 1.0f;

        public float distance = 0.0f;

        Vector3 startPos;       // defines where first bubble will be placed

        // UNITY FUNCTIONS ----------------------------------------
        void Start() {
            AddDistance();      // adding distance offset
            GridStartPos();     // calculating the start position
            CreateGrid();       // create the grid
        }


        // FUNCTIONS ----------------------------------------
        void AddDistance() {                 
            bubbleHeight += bubbleHeight * distance;
            bubbleWidth += bubbleWidth * distance;
        }

        void GridStartPos() {
            //float offset = 0;

            //if (gridHeight / 2 % 2 != 0) { 
            //    offset = bubbleWidth / 2;
            //}

            float x = -bubbleWidth * (gridWidth / 2); //- offset
            float z = bubbleHeight * 0.75f * (gridHeight / 2);

            startPos = new Vector3(x, 0, z);
        }

        Vector3 WorldPos(Vector2 gridPos) {     // function that translates the coordinates
            //float offset = 0;

            //if (gridPos.y % 2 != 0) { // if not devideable by two
            //    offset = gridWidth / 2;
            //}

            float x = startPos.x + gridPos.x * bubbleWidth; //+ offset
            float z = startPos.z - gridPos.y * bubbleHeight * 0.75f;

            return new Vector3(x, 0, z);
        }

        void CreateGrid() {
            for (int y = 0; y < gridHeight; y++) {
                for (int x = 0; x < gridWidth; x++) {
                    Transform bubble = Instantiate(BubblePrefab) as Transform;
                    Vector2 gridPos = new Vector2(x, y);    // stores coordinates of the bubbles
                    bubble.position = WorldPos(gridPos);    // translates 2D coordinates into 3D world 
                    bubble.parent = this.transform;         // stores bubbles in parent so hierarchy will stay clear
                    bubble.name = "Bubble" + x + "|" + y;   // position of the bubbles
                }
            }
        }
    }
}
