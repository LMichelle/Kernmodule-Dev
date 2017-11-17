using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BustAMove { 
    public class Grid : MonoBehaviour {

        public List<GameObject> allBubblesList = new List<GameObject>();
        public List<GameObject> nodesList = new List<GameObject>();

        public Vector2 startPos;

        public GameObject emptyBall;
        public GameObject bubbleToList;

        public bool pushGridOnce = true;
        public bool gotBubbleCount = false;

        public int gridHeight; 
        public int gridWidth; 
        public int maxCountForPushGrid;
        private int gridHeightCalculated;
        private int gridWidthCalculated;

        private bool once = true;

        public int points;

        void Start() {
            GridStartPos();
            CreateGrid();
            foreach (GameObject node in GameObject.FindGameObjectsWithTag("Node")) {
                nodesList.Add(node);              
            }
            pushGridOnce = true;
            maxCountForPushGrid = GameObject.FindGameObjectWithTag("Player").GetComponent<ArrowControl>().maxCount;
        }

        private void Update() {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<ArrowControl>().counter == maxCountForPushGrid && pushGridOnce) {
                PushGrid();
                pushGridOnce = false;
            }

            if (GameObject.FindGameObjectWithTag("Player").GetComponent<ArrowControl>().counter < maxCountForPushGrid) {
                pushGridOnce = true;
            }

            foreach (GameObject node in GameObject.FindGameObjectsWithTag("Node")) {
                List<GameObject> bubbleListPerNode = node.GetComponent<NodeChecker>().bubblesAroundList;
                foreach (GameObject bubble in bubbleListPerNode) {
                    if (!allBubblesList.Contains(bubble)) {
                        allBubblesList.Add(bubble);
                    }
                }
            }
                
            for (int i = allBubblesList.Count - 1; i > -1; i--) {
                if (allBubblesList[i] == null) {
                    allBubblesList.RemoveAt(i);
                }
            }

            if (allBubblesList.Count > 0 && once) {
                gotBubbleCount = true;
                once = false;
            }

        }

        // Set Starting position to count from where the Grid objects transform is. Then calculate what the actual position is to where the grid goes.
        void GridStartPos() {
            startPos = this.transform.position;
            gridWidthCalculated  = (int)startPos.x + gridWidth;
            gridHeightCalculated = (int)startPos.y + gridHeight;
        }

        // If the row is even, then make sure there is an offset.
        Vector2 SetPos(Vector2 pos) { 
            if ((int)pos.y % 2 == 0) {
                pos.x += 0.5f;
            }
            return pos;
        }

        // Creates a grid filled with nodes.
        void CreateGrid() {                     
            for (int x = (int)startPos.x; x < gridWidthCalculated; x++) {
                for (int y = (int)startPos.y; y < gridHeightCalculated; y++) {
                    // Every second row has one bubble less due to the offset.
                    if (y % 2 == 0 && x == gridWidthCalculated - 1) {           
                    } else {
                        NewPlace(x, y);
                    }
                }
            }
        }

        void PushGrid() {
            // Push grid down after shooting ... bubbles 
            foreach (GameObject node in nodesList) {
                node.transform.position = new Vector2(node.transform.position.x, node.transform.position.y - 1);
            }

            // also change all bubble colors
            foreach (GameObject bub in allBubblesList) {
                bub.GetComponent<BubbleColor>().DiscoBal();
            }
        }

        void NewPlace(int x, int y) { // create a new node at the right position
            GameObject emptyPlace = Instantiate(emptyBall) as GameObject;
            Vector2 gridPos = new Vector2(x, y);
            gridPos = SetPos(gridPos);
            gridPos.x += 0.5f;
            gridPos.y += 0.5f;
            emptyPlace.transform.position = gridPos;
            emptyPlace.transform.parent   = this.transform;
            emptyPlace.name = "Place " + emptyPlace.transform.localPosition.x + " " + emptyPlace.transform.localPosition.y; 
        }
    }
}
