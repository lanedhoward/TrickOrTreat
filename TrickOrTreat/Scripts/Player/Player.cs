using Godot;
using System;

public partial class Player : CharacterBody3D
{
	public const float Speed = 5.0f;
	public const float JumpVelocity = 4.5f;

	public float Sensitivity = 0.003f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();

	public Node3D Head;
	public Camera3D Camera;

	public override void _Ready()
	{
		base._Ready();

		Head = GetNode<Node3D>("Head");
		Camera = GetNode<Camera3D>("Head/Camera3D");

		Input.MouseMode = Input.MouseModeEnum.Captured;

	}

	public override void _Input(InputEvent @event)
	{
		base._Input(@event);

		if(@event is InputEventMouseMotion mouseMotion)
		{
			Head.RotateY(-mouseMotion.Relative.X * Sensitivity);
			Camera.RotateX(-mouseMotion.Relative.Y * Sensitivity);

			Vector3 cameraRotation = Camera.Rotation;

			cameraRotation.X = Mathf.Clamp(cameraRotation.X, Mathf.DegToRad(-80f), Mathf.DegToRad(80f));
			Camera.Rotation = cameraRotation;
		}

		if (@event is InputEventKey key)
		{
			if (key.IsAction("Exit"))
			{
				GetTree().Quit();
			}
		}
	}
	/*
	public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y -= gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
			velocity.Y = JumpVelocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 inputDir = Input.GetVector("left", "right", "up", "down");
		Vector3 direction = (Head.Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		if (direction != Vector3.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Z = direction.Z * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
	*/
}
