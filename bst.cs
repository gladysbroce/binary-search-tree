/*
 * Program Description: This is a linked list implementation of a Binary Search Tree(BST).
 * This program performs the following operations:
 * [1] Insert node to binary tree
 * [2] Delete node from binary tree
 * [3] Minimum
 * [4] Maximum
 * [5] Successor
 * [6] Predecessor
 * [7] Search
 * [8] Print BST
 */

using System;
using System.Windows.Forms;
using System.Drawing;

namespace BSTLinkedList {
    public partial class Form1 : Form {

        // Creates a new bst
        public BST b = new BST();

        public Form1() {
            InitializeComponent();
            this.Text = "Binary Search Tree";

            // Hide form during initial load
            HideForm();
        }

        // Method for [1] Insert node to binary tree button
        private void BtnInsert_Click( object sender, EventArgs e ) {
            btnExecute.Text = "Insert";
            labelTitle.Text = btnInsert.Text;
            ShowForm();
        }

        // Method for [2] Delete node from binary tree button
        private void BtnDelete_Click( object sender, EventArgs e ) {
            btnExecute.Text = "Delete";
            labelTitle.Text = btnDelete.Text;
            ShowForm();
        }

        // Method for [3] Minimum button
        private void BtnMin_Click( object sender, EventArgs e ) {
            labelTitle.Text = btnMin.Text;
            HideForm();

            // Get the minimum value in the BST
            Node node = b.GetMin(b.Root);

            // If BST is not empty, display the minimum value. 
            if (node != null) {
                labelMsg.Text = "The minimum value in the BST is " + node.Value + ".";
                labelMsg.ForeColor = Color.YellowGreen;
            }
            //Else, display BST is empty.
            else {
                labelMsg.Text = "BST is empty.";
                labelMsg.ForeColor = Color.Tomato;
            }
            labelMsg.Visible = true;
            labelMsg.Top = 54;
        }

        // Method for [4] Maximum button
        private void BtnMax_Click( object sender, EventArgs e ) {
            labelTitle.Text = btnMax.Text;
            HideForm();

            // Get the maximum value in the BST
            Node node = b.GetMax(b.Root);

            // If BST is not empty, display the maximum value. 
            if (node != null) {
                labelMsg.Text = "The maximum value in the BST is " + node.Value + ".";
                labelMsg.ForeColor = Color.YellowGreen;
            }
            //Else, display BST is empty.
            else {
                labelMsg.Text = "BST is empty.";
                labelMsg.ForeColor = Color.Tomato;
            }
            labelMsg.Visible = true;
            labelMsg.Top = 54;
        }

        // Method for [5] Successor button
        private void BtnSuccessor_Click(object sender, EventArgs e) {
            btnExecute.Text = "Successor";
            labelTitle.Text = btnSuccessor.Text;
            ShowForm();
        }

        // Method for [6] Predecessor button
        private void BtnPredecessor_Click(object sender, EventArgs e) {
            btnExecute.Text = "Predecessor";
            labelTitle.Text = btnPredecessor.Text;
            ShowForm();
        }

        // Method for [7] Search button
        private void BtnSearch_Click(object sender, EventArgs e) {
            btnExecute.Text = "Search";
            labelTitle.Text = btnSearch.Text;
            ShowForm();
        }

        // Method for [8] Print BST button
        private void BtnPrint_Click(object sender, EventArgs e) {
            labelTitle.Text = btnPrint.Text;
            HideForm();

            // Clear data
            b.PrintData = "";

            // Perform inorder traversal so we can later print the values in increasing order
            b.InorderTraversal(b.Root);

            // If BST is not empty, display the values.
            if (b.PrintData != "") {
                labelMsg.Text = "Here are the values inside the BST:\n" + b.PrintData;
                labelMsg.ForeColor = Color.YellowGreen;
            }
            // Else, BST is empty.
            else {
                labelMsg.Text = "BST is empty.";
                labelMsg.ForeColor = Color.Tomato;
            }
            labelMsg.Visible = true;
            labelMsg.Top = 54;
        }

        // Hide Form
        private void HideForm() {
            // Clear message
            labelMsg.Text = String.Empty;

            // Clear value
            txtValue.Text = String.Empty;

            // Disable Execute button
            btnExecute.Enabled = false;

            // Hide form elements
            labelMsg.Hide();
            labelValue.Hide();
            txtValue.Hide();
            btnExecute.Hide();
        }

        // Show Form
        private void ShowForm() {
            // Hide message
            labelMsg.Hide();
            labelMsg.Top = 92;

            // Show form elements
            labelValue.Visible = true;
            txtValue.Visible = true;
            btnExecute.Visible = true;
        }

        // Method for Execute button
        private void BtnExecute_Click(object sender, EventArgs e) {
            labelMsg.Text = "";

            int val = 0;
            bool success = Int32.TryParse(txtValue.Text, out val);

            // Display error when user input is incorrect.
            if (!success) {
                labelMsg.Text = "Invalid input.";
                labelMsg.ForeColor = Color.Tomato;
                labelMsg.Visible = true;
                txtValue.Text = String.Empty;
                btnExecute.Enabled = false;
                return;
            }

            // Create new node
            Node node = new Node();

            switch (btnExecute.Text) {
                // Insert new node
                case "Insert":
                    b.Insert(val);
                    labelMsg.Text = val + " is successfully inserted in the BST.";
                    labelMsg.ForeColor = Color.YellowGreen;
                    break;

                // Delete node
                case "Delete":
                    node = b.Delete(val);
                    if (node != null) {
                        labelMsg.Text = val + " is successfully deleted from the BST.";
                        labelMsg.ForeColor = Color.YellowGreen;
                    }
                    else {
                        labelMsg.Text = val + " is not found in the BST.";
                        labelMsg.ForeColor = Color.Tomato;
                    }
                    break;

                // Seach node
                case "Search":
                    node = b.Search(b.Root, val);
                    if (node != null) {
                        labelMsg.Text = val + " is found in the BST.";
                        labelMsg.ForeColor = Color.YellowGreen;
                    }
                    else {
                        labelMsg.Text = val + " is not found in the BST.";
                        labelMsg.ForeColor = Color.Tomato;
                    }
                    break;

                // Get node's successor
                case "Successor":
                    // Search node in the BST 
                    node = b.Search(b.Root, val);

                    // If input node is found
                    if (node != null) {
                        // Get the successor
                        node = b.GetSuccessor(node);

                        // If successor is found
                        if (node != null) {
                            labelMsg.Text = "The successor of " + val + " is " + node.Value + ".";
                            labelMsg.ForeColor = Color.YellowGreen;
                        }
                        // Else, successor is not found
                        else {
                            labelMsg.Text = val + " has no successor.";
                            labelMsg.ForeColor = Color.Tomato;
                        }
                    }
                    // Else, input node is not found
                    else {
                        labelMsg.Text = val + " is not found in the BST.";
                        labelMsg.ForeColor = Color.Tomato;
                    }
                    break;

                // Get node's predecessor
                case "Predecessor":
                    // Search node in the BST 
                    node = b.Search(b.Root, val);

                    // If input node is found
                    if (node != null) {
                        // Get the predecessor
                        node = b.GetPredecessor(node);

                        //If predecessor is found
                        if (node != null) {
                            labelMsg.Text = "The predecessor of " + val + " is " + node.Value + ".";
                            labelMsg.ForeColor = Color.YellowGreen;
                        }
                        // Else, predecessor is not found
                        else {
                            labelMsg.Text = val + " has no predecessor.";
                            labelMsg.ForeColor = Color.Tomato;
                        }
                    }
                    // Else, input node is not found
                    else {
                        labelMsg.Text = val + " is not found in the BST.";
                        labelMsg.ForeColor = Color.Tomato;
                    }
                    break;
            }

            // Display message
            labelMsg.Visible = true;

            // Clear input box
            txtValue.Text = String.Empty;

            // Disable button
            btnExecute.Enabled = false;
        }

        // Called when name is entered
        private void TxtValue_TextChanged(object sender, EventArgs e) {
            // Enable Execute button when text is entered
            btnExecute.Enabled = !string.IsNullOrWhiteSpace(txtValue.Text);
        }

        private void Form1_Load(object sender, EventArgs e) { }
    }

    public class Node {
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }

    // BST Class
    public class BST {
        public Node Root { get; set; }
        public string PrintData { get; set; }

        // Class constructor
        public BST() {
            Root = null;
        }

        // Insert node to BST
        public void Insert(int x) {

            // Create a new node with x as value and initially point its left and right child to null.
            Node newNode = new Node {
                Value = x,
                Left = null,
                Right = null
            };

            // If root is null, set new node as root
            if (Root == null) {
                Root = newNode;
            }
            // Else,
            else {
                Node current = Root;
                Node parent = new Node();

                // Search for new node's proper position
                while (current != null) {
                    parent = current;
                    if (newNode.Value < current.Value) current = current.Left;
                    else current = current.Right;
                }
                // Insert new node on its proper position
                if (newNode.Value < parent.Value) parent.Left = newNode;
                else parent.Right = newNode;
            }
        }

        // Delete node to BST
        public Node Delete(int x) {
            
            // Start searching from the root
            Node current = Root;
            Node parent = GetParent(current, ref current, x);

            // If input node is not in the BST, return null
            if (current == null) return null;

            // Case 1: Node to be deleted has no child
            if (current.Left == null && current.Right == null) {
                // If node to be deleted is the only node in the BST, set root to null
                if (current == Root) Root = null;
                // Else, point parent of node to null
                else DeleteWithNoChild(ref parent, current);
            }

            // Case 2: Node to be deleted has 2 children
            else if (current.Left != null && current.Right != null) {
                // Get the node's successor
                Node successor = GetSuccessor(current);

                // Swap values of target node and its successor
                int tmp = current.Value;
                current.Value = successor.Value;
                successor.Value = tmp;

                // Search from right side of the node
                Node newCurrent = current.Right;
                parent = GetParent(current, ref newCurrent, x);
                
                // If successor has no child
                if (successor.Left == null && successor.Right == null) {
                    DeleteWithNoChild(ref parent, newCurrent);
                }
                // Else, the successor has at most one child
                else {
                    DeleteWithOneChild(ref parent, newCurrent);
                }
            }

            // Case 3: Node to be deleted has only one child
            else {
                // If node to be deleted is the root, assign child as the new root
                if (current == Root) {
                    if (current.Left != null) Root = current.Left;
                    else Root = current.Right;
                }
                else {
                    DeleteWithOneChild(ref parent, current);
                }
            }
            return current;
        }

        // Delete node with no child
        private void DeleteWithNoChild(ref Node parent, Node current) {
            if (parent.Left == current) parent.Left = null;
            else parent.Right = null;
        }

        // Delete node with one child
        private void DeleteWithOneChild(ref Node parent, Node current) {
            // Point parent to the child of the node to be deleted
            if (parent.Left == current) {
                if (current.Left != null) parent.Left = current.Left;
                else parent.Left = current.Right;
            }
            else {
                if (current.Left != null) parent.Right = current.Left;
                else parent.Right = current.Right;
            }
        }

        // Get parent node
        private Node GetParent(Node parent, ref Node current, int x) {
            // Repeat until node is found
            while (current != null && current.Value != x) {

                parent = current;
                // If input is less than the current node, traverse the left side
                if (x < current.Value) current = current.Left;
                // Else, traverse the right side
                else current = current.Right;
            }
            return parent;
        }

        // Get the minimum value in the BST
        public Node GetMin(Node node) {
            if (node == null) return null;

            // Find the leftmost node
            while (node.Left != null) {
                node = node.Left;
            }
            return node;
        }

        // Get the maximum value in the BST
        public Node GetMax(Node node) {
            if (node == null) return null;

            // Find the rightmost node
            while (node.Right != null) {
                node = node.Right;
            }
            return node;
        }

        // Get the successor of the node
        public Node GetSuccessor(Node node) {

            // If right child exists, search for the minimum value in the right subtree
            if (node.Right != null) {
                return GetMin(node.Right);
            }
            // Else, successor is on the upper part of the given node
            else {
                Node successor = null;

                // Start searching from the root
                Node current = Root;

                // Loop until input node is found
                while (current != null && current.Value != node.Value) {
                    // If input is less than the current node, set current node as the successor then go left
                    if (node.Value < current.Value) {
                        successor = current;
                        current = current.Left;
                    }
                    // Else, go right
                    else {
                        current = current.Right;
                    }
                }
                return successor;
            }
        }

        // Get the predecessor of the node
        public Node GetPredecessor(Node node) {

            // If left child exists, search for the maximum value in the left subtree
            if (node.Left != null) {
                return GetMax(node.Left);
            }
            // Else, predecessor is on the upper part of the given node
            else {
                Node predecessor = null;

                // Start searching from the root
                Node current = Root;

                // Loop until input node is found
                while (current != null && current.Value != node.Value) {
                    // If input is less than the current node, go left
                    if (node.Value < current.Value) {
                        current = current.Left;
                    }
                    // Else, set current node as the predecessor then go right
                    else {
                        predecessor = current;
                        current = current.Right;
                    }
                }
                return predecessor;
            }
        }

        // Search for the value in the BST
        public Node Search(Node root, int x) {
            if (root == null || root.Value == x) {
                return root;
            }

            // If x is less than the root, search the left subtree.
            if (x < root.Value) {
                return Search(root.Left, x);
            }
            // Else, search the right subtree.
            else {
                return Search(root.Right, x);
            }
        }

        // Perform inorder traversal
        public void InorderTraversal(Node root) {

            // Traverse tree from left, root, then right
            if(root != null) {
                InorderTraversal(root.Left);
                PrintData += root.Value + " ";
                InorderTraversal(root.Right);
            }
        }
    }
}