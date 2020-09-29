using System;

public static class MyMath {
	public static float Clamp(float value, float min, float max) {
		if (value < min) {
			return min;
		} else if (value > max) {
			return max;
		} else {
			return value;
		}
	}
}

public abstract class Tween<T> {
	protected float start;
	protected float end;

	public Tween(float start, float end) {
		this.start = start;
		this.end = end;
	}

	public abstract T Lerp(float t);
}

public abstract class Curve {
	public abstract float Transform(float t);
}

public class CurvedAnimation<T> {
	Curve curve;
	Tween<T> tween;
	float duration;

	public CurvedAnimation(Curve curve, Tween<T> tween, float duration) {
		this.curve = curve;
		this.tween = tween;
		this.duration = duration;
	}

	public T Evaluate(float t) {
		float x = MyMath.Clamp(t / duration, 0.0f, 1.0f);		
		float transform = curve.Transform(x);
		T value = tween.Lerp(transform);
		return value;
	}
}

// --- ✄ -----------------------

public class RotationTween : Tween<float> {
	public RotationTween(float start, float end) : base(start, end) {}

	public override float Lerp(float t) {
		return start + (end - start) * t;
	}
}

public class ExponentialCurve : Curve {
	float exponent;
	public ExponentialCurve(float exponent) {
		this.exponent = exponent;
	}

	public override float Transform(float t) {
		return (float)Math.Pow(t, exponent);
	}
}
