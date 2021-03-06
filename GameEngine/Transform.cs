﻿using Microsoft.Xna.Framework;
using Microsoft.Xna;
using System.Collections.Generic;

namespace CPI311.GameEngine
{
    public class Transform
    {
        private Vector3 localPosition;
        private Vector3 localScale;
        private Quaternion localRotation;
        private Matrix world;
        
        

        public Vector3 LocalPosition
        {
            get { return localPosition; }
            set { localPosition = value; UpdateWorld(); }
        }

        public Quaternion LocalRotation
        {
            get { return localRotation; }
            set { localRotation = value; UpdateWorld(); }
        }

        public Vector3 LocalScale
        {
            get { return localScale; }
            set { localScale = value; UpdateWorld(); }
        }

        public Matrix World
        {
            get { return world; }
        }

        public Vector3 Position
        {
            get { return World.Translation; }
           
        }

        public Transform()
        {
            localScale = Vector3.One;
            localRotation = Quaternion.Identity;
            localPosition = Vector3.Zero;
            Children = new List<Transform>();
            UpdateWorld();
        }

        public void UpdateWorld()
        {
            world = Matrix.CreateScale(localScale) * Matrix.CreateFromQuaternion(localRotation) * Matrix.CreateTranslation(localPosition);
            if (parent != null)
                world *= parent.World;
            foreach (Transform child in Children)
                child.UpdateWorld();
        }


        //direction changers
        public Vector3 Forward { get { return world.Forward; } }
        public Vector3 Backward { get { return world.Backward; } }
        public Vector3 Up { get { return world.Up; } }
        public Vector3 Down { get { return world.Down; } }
        public Vector3 Left { get { return world.Left; } }
        public Vector3 Right { get { return world.Right; } }

        // Methods
        public void Rotate (Vector3 axis, float angle)
        {
            LocalRotation *= Quaternion.CreateFromAxisAngle(axis, angle);

        }

        // Parent stuff

        private Transform parent;
        public Transform Parent
        {
            get { return parent; }
            set
            {
                if (parent != null) parent.Children.Remove(this);
                parent = value;
                if (parent != null) parent.Children.Add(this);
                UpdateWorld();
            }
        }


        //lab 5 additons
        public Quaternion Rotation
        {
            get { return Quaternion.CreateFromRotationMatrix(World); }
            set
            {
                if (Parent == null) LocalRotation = value;
                else
                {
                    Vector3 scale, pos; Quaternion rot;
                    world.Decompose(out scale, out rot, out pos);
                    Matrix total = Matrix.CreateScale(scale) *
                          Matrix.CreateFromQuaternion(value) *
                          Matrix.CreateTranslation(pos);
                    LocalRotation = Quaternion.CreateFromRotationMatrix(
                         Matrix.Invert(Matrix.CreateScale(LocalScale)) * total *
                         Matrix.Invert(Matrix.CreateTranslation(LocalPosition)
                         * Parent.world));
                }
            }
        }


        private List<Transform> Children { get; set; }

    }
}


