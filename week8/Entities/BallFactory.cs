using System;

public class BallFactory
{
	public BallFactory()
	{
		return new Ball();
	}

	public Color BallColor { get; set; }

	public Toy CreateNew()
	{
		return new Ball(BallColor);
	}
}
