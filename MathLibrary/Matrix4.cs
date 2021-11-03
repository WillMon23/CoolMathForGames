using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
    public struct Matrix4
    {
        public float M00, M01, M02, M03, M10, M11, M12, M13, M20, M21, M22, M23, M30, M31, M32, M33;

        public Matrix4(float m00, float m01, float m02, float m03,
                       float m10, float m11, float m12, float m13,
                       float m20, float m21, float m22, float m23,
                       float m30, float m31, float m32, float m33)
        {
            M00 = m00; M01 = m01; M02 = m02;
            M10 = m10; M11 = m11; M12 = m12;
            M20 = m20; M21 = m21; M22 = m22;
            M30 = m30, M31 = m31, M32 = m32, M33 = m33;
        }

        public static Matrix4 Identity
        {
            get
            {
                return new Matrix4();
            }

        }

        /// <summary>
        /// Creates a new matrix that has been rotated bt the given in radians 
        /// </summary>
        /// <param name="radians"></param>
        /// <returns>The resualt of the rotation</returns>
        public static Matrix4 CreateRotationZ(float radians)
        {
            return new Matrix4();
        }

        public static Matrix4 CreateRotationY(float radians)
        {
            return new Matrix4();
        }

        public static Matrix4 CreateRotationX(float radians)
        {
            return new Matrix4();
        }


        /// <summary>
        /// Creats a new matrix that has been translated by the given value
        /// </summary>
        /// <param name="x"> The value to use to scale the matrix in the x axis</param>
        /// <param name="y"> The value to use to scale the matrix in the y axis</param>
        /// <returns></returns>
        public static Matrix4 CreateTranslation(float x, float y, float z)
        {
            return new Matrix4();
        }



        /// <summary>
        /// Creats a new MAtrex that has been scaled by the given value
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Matrix4 CreateScale(float x, float y, float z)
        {
            return new Matrix4()
        }

        public static Matrix4 operator +(Matrix3 lhs, Matrix3 rhs)
        {
            //Matrix4 temp = new Matrix4();

            ////Top
            //temp.M00 = lhs.M00 + rhs.M00;
            //temp.M01 = lhs.M01 + rhs.M01;
            //temp.M02 = lhs.M02 + rhs.M02;

            ////Middle
            //temp.M10 = lhs.M10 + rhs.M10;
            //temp.M11 = lhs.M11 + rhs.M11;
            //temp.M12 = lhs.M12 + rhs.M12;

            ////Bottom
            //temp.M20 = lhs.M20 + rhs.M20;
            //temp.M21 = lhs.M21 + rhs.M21;
            //temp.M22 = lhs.M22 + rhs.M22;

            return new Matrix4();
        }

        public static Matrix4 operator -(Matrix3 lhs, Matrix3 rhs)
        {
            Matrix4 temp = new Matrix4();

            //Top
            temp.M00 = lhs.M00 - rhs.M00;
            temp.M01 = lhs.M01 - rhs.M01;
            temp.M02 = lhs.M02 - rhs.M02;

            //Middle           
            temp.M10 = lhs.M10 - rhs.M10;
            temp.M11 = lhs.M11 - rhs.M11;
            temp.M12 = lhs.M12 - rhs.M12;

            //Bottom           
            temp.M20 = lhs.M20 - rhs.M20;
            temp.M21 = lhs.M21 - rhs.M21;
            temp.M22 = lhs.M22 - rhs.M22;

            return new Matrix4();
        }

        public static Matrix4 operator *(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix4();
                //(
                //    //Row1, Column1
                //    //lhs.M00 * rhs.M00 + lhs.M01 * rhs.M10 + lhs.M02 * rhs.M20,
                //    ////Row1, Column2
                //    //lhs.M00 * rhs.M01 + lhs.M01 * rhs.M11 + lhs.M02 * rhs.M21,
                //    ////Row1, Column3
                //    //lhs.M00 * rhs.M02 + lhs.M01 * rhs.M12 + lhs.M02 * rhs.M22,

                //    ////Row2, Column1
                //    //lhs.M10 * rhs.M00 + lhs.M11 * rhs.M10 + lhs.M12 * rhs.M20,
                //    ////Row2, Column2
                //    //lhs.M10 * rhs.M01 + lhs.M11 * rhs.M11 + lhs.M12 * rhs.M21,
                //    ////Row2, Column3
                //    //lhs.M10 * rhs.M02 + lhs.M11 * rhs.M12 + lhs.M12 * rhs.M22,

                //    ////Row3, Column1
                //    //lhs.M20 * rhs.M00 + lhs.M21 * rhs.M10 + lhs.M22 * rhs.M20,
                //    ////Row3, Column2
                //    //lhs.M20 * rhs.M01 + lhs.M21 * rhs.M11 + lhs.M22 * rhs.M21,
                //    ////Row3, Column3
                //    //lhs.M20 * rhs.M02 + lhs.M21 * rhs.M12 + lhs.M22 * rhs.M22

                //);
        }

       public static Matrix4 operator *(Matrix4 lhs, Vector4 rhs)
        {
            return new Matrix4();
        }
    }
}


