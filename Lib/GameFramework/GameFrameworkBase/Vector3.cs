using System;
using System.Linq;


namespace GameFramework.Base
{
    /// <summary>
    /// 3D 空间中坐标
    /// </summary>
    public struct Vector3
    {
        private const float kEpsilon = 1E-05f;
        public float x;
        public float y;
        public float z;

        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return this.x;
                    case 1:
                        return this.y;
                    case 2:
                        return this.z;
                    default:
                        throw new IndexOutOfRangeException("Invalid Vector3 index!");
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        this.x = value;
                        break;
                    case 1:
                        this.y = value;
                        break;
                    case 2:
                        this.z = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Invalid Vector3 index!");
                }
            }
        }
        public Vector3 normalized
        {
            get
            {
                return Vector3.Normalize(this);
            }
        }
        public float magnitude
        {
            get
            {
                return Mathf.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);
            }
        }
        public float sqrMagnitude
        {
            get
            {
                return this.x * this.x + this.y * this.y + this.z * this.z;
            }
        }
        public static Vector3 zero
        {
            get
            {
                return new Vector3(0f, 0f, 0f);
            }
        }
        public static Vector3 one
        {
            get
            {
                return new Vector3(1f, 1f, 1f);
            }
        }
        public static Vector3 forward
        {
            get
            {
                return new Vector3(0f, 0f, 1f);
            }
        }
        public static Vector3 back
        {
            get
            {
                return new Vector3(0f, 0f, -1f);
            }
        }
        public static Vector3 up
        {
            get
            {
                return new Vector3(0f, 1f, 0f);
            }
        }
        public static Vector3 down
        {
            get
            {
                return new Vector3(0f, -1f, 0f);
            }
        }
        public static Vector3 left
        {
            get
            {
                return new Vector3(-1f, 0f, 0f);
            }
        }
        public static Vector3 right
        {
            get
            {
                return new Vector3(1f, 0f, 0f);
            }
        }

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Vector3(float x, float y)
        {
            this.x = x;
            this.y = y;
            this.z = 0f;
        }
        public static Vector3 Lerp(Vector3 a, Vector3 b, float t)
        {
            t = Mathf.Clamp01(t);
            return new Vector3(a.x + (b.x - a.x) * t, a.y + (b.y - a.y) * t, a.z + (b.z - a.z) * t);
        }
        public static Vector3 LerpUnclamped(Vector3 a, Vector3 b, float t)
        {
            return new Vector3(a.x + (b.x - a.x) * t, a.y + (b.y - a.y) * t, a.z + (b.z - a.z) * t);
        }
        public void Set(float new_x, float new_y, float new_z)
        {
            this.x = new_x;
            this.y = new_y;
            this.z = new_z;
        }
        public static Vector3 Scale(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
        }
        public void Scale(Vector3 scale)
        {
            this.x *= scale.x;
            this.y *= scale.y;
            this.z *= scale.z;
        }
        public static Vector3 Cross(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.y * rhs.z - lhs.z * rhs.y, lhs.z * rhs.x - lhs.x * rhs.z, lhs.x * rhs.y - lhs.y * rhs.x);
        }
        public override int GetHashCode()
        {
            return this.x.GetHashCode() ^ this.y.GetHashCode() << 2 ^ this.z.GetHashCode() >> 2;
        }
        public override bool Equals(object other)
        {
            if (!(other is Vector3))
            {
                return false;
            }
            Vector3 vector = (Vector3)other;
            return this.x.Equals(vector.x) && this.y.Equals(vector.y) && this.z.Equals(vector.z);
        }
        public static Vector3 Normalize(Vector3 value)
        {
            float num = Vector3.Magnitude(value);
            if (num > 1E-05f)
            {
                return value / num;
            }
            return Vector3.zero;
        }
        public void Normalize()
        {
            float num = Vector3.Magnitude(this);
            if (num > 1E-05f)
            {
                x /= num;
                y /= num;
                z /= num;
            }
            else
            {
                x = 0;
                y = 0;
                z = 0;
            }
        }
        public override string ToString()
        {
            return string.Format("({0},{1},{2})", x, y, z);
        }
        public static float Dot(Vector3 lhs, Vector3 rhs)
        {
            return lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z;
        }
        public static float Angle(Vector3 from, Vector3 to)
        {
            return Mathf.Acos(Mathf.Clamp(Vector3.Dot(from.normalized, to.normalized), -1f, 1f)) * 57.29578f;
        }
        public static float Distance(Vector3 a, Vector3 b)
        {
            Vector3 vector = new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
            return Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);
        }
        //public static Vector3 ClampMagnitude(Vector3 vector, float maxLength)
        //{
        //    if (vector.sqrMagnitude > maxLength * maxLength)
        //    {
        //        return vector.normalized * maxLength;
        //    }
        //    return vector;
        //}
        //public static Vector3 Project(Vector3 vector, Vector3 onNormal)
        //{
        //    float num = Vector3.Dot(onNormal, onNormal);
        //    if (num < Mathf.Epsilon)
        //    {
        //        return Vector3.zero;
        //    }
        //    return onNormal * Vector3.Dot(vector, onNormal) / num;
        //}
        //public static Vector3 ProjectOnPlane(Vector3 vector, Vector3 planeNormal)
        //{
        //    return vector - Vector3.Project(vector, planeNormal);
        //}
        //public static Vector3 Exclude(Vector3 excludeThis, Vector3 fromThat)
        //{
        //    return fromThat - Vector3.Project(fromThat, excludeThis);
        //}
        //public static Vector3 Reflect(Vector3 inDirection, Vector3 inNormal)
        //{
        //    return -2f * Vector3.Dot(inNormal, inDirection) * inNormal + inDirection;
        //}
        //public static Vector3 MoveTowards(Vector3 current, Vector3 target, float maxDistanceDelta)
        //{
        //    Vector3 a = target - current;
        //    float magnitude = a.magnitude;
        //    if (magnitude <= maxDistanceDelta || magnitude == 0f)
        //    {
        //        return target;
        //    }
        //    return current + a / magnitude * maxDistanceDelta;
        //}
        public static float Magnitude(Vector3 a)
        {
            return Mathf.Sqrt(a.x * a.x + a.y * a.y + a.z * a.z);
        }
        public static float SqrMagnitude(Vector3 a)
        {
            return a.x * a.x + a.y * a.y + a.z * a.z;
        }
        public static Vector3 Min(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(Mathf.Min(lhs.x, rhs.x), Mathf.Min(lhs.y, rhs.y), Mathf.Min(lhs.z, rhs.z));
        }
        public static Vector3 Max(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(Mathf.Max(lhs.x, rhs.x), Mathf.Max(lhs.y, rhs.y), Mathf.Max(lhs.z, rhs.z));
        }
        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }
        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }
        public static Vector3 operator -(Vector3 a)
        {
            return new Vector3(-a.x, -a.y, -a.z);
        }
        public static Vector3 operator *(Vector3 a, float d)
        {
            return new Vector3(a.x * d, a.y * d, a.z * d);
        }
        public static Vector3 operator *(float d, Vector3 a)
        {
            return new Vector3(a.x * d, a.y * d, a.z * d);
        }
        public static Vector3 operator /(Vector3 a, float d)
        {
            return new Vector3(a.x / d, a.y / d, a.z / d);
        }
        public static bool operator ==(Vector3 lhs, Vector3 rhs)
        {
            return Vector3.SqrMagnitude(lhs - rhs) < 9.99999944E-11f;
        }
        public static bool operator !=(Vector3 lhs, Vector3 rhs)
        {
            return Vector3.SqrMagnitude(lhs - rhs) >= 9.99999944E-11f;
        }
    }

}
