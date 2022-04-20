using System;
using Godot;

namespace Kaiju.Entities
{
    public class Npc : KinematicBody2D
    {
        public bool isPlayerNear = false;
        public float movementSpeed = 200;
    }
}
