﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

namespace MoreMountains.Tools
{	
	/// <summary>
	/// Various static methods used throughout the Infinite Runner Engine and the Corgi Engine.
	/// </summary>

	public static class MMMaths 
	{
		/// <summary>
		/// Takes a Vector3 and turns it into a Vector2
		/// </summary>
		/// <returns>The vector2.</returns>
		/// <param name="target">The Vector3 to turn into a Vector2.</param>
		public static Vector2 Vector3ToVector2 (Vector3 target) 
		{
			return new Vector2(target.x, target.y);
		}

		/// <summary>
		/// Takes a Vector2 and turns it into a Vector3 with a null z value
		/// </summary>
		/// <returns>The vector3.</returns>
		/// <param name="target">The Vector2 to turn into a Vector3.</param>
		public static Vector3 Vector2ToVector3 (Vector2 target) 
		{
			return new Vector3(target.x, target.y, 0);
		}

		/// <summary>
		/// Takes a Vector2 and turns it into a Vector3 with the specified z value 
		/// </summary>
		/// <returns>The vector3.</returns>
		/// <param name="target">The Vector2 to turn into a Vector3.</param>
		/// <param name="newZValue">New Z value.</param>
		public static Vector3 Vector2ToVector3 (Vector2 target, float newZValue) 
		{
			return new Vector3(target.x, target.y, newZValue);
		}

		/// <summary>
		/// Returns a random vector3 from 2 defined vector3.
		/// </summary>
		/// <returns>The vector3.</returns>
		/// <param name="min">Minimum.</param>
		/// <param name="max">Maximum.</param>
		public static Vector3 RandomVector3(Vector3 minimum, Vector3 maximum)
		{
			return new Vector3(UnityEngine.Random.Range(minimum.x, maximum.x), 
											 UnityEngine.Random.Range(minimum.y, maximum.y), 
											 UnityEngine.Random.Range(minimum.z, maximum.z));
		}

		/// <summary>
		/// Rotates a point around the given pivot.
		/// </summary>
		/// <returns>The new point position.</returns>
		/// <param name="point">The point to rotate.</param>
		/// <param name="pivot">The pivot's position.</param>
		/// <param name="angle">The angle we want to rotate our point.</param>
		public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, float angle) 
		{			
			angle = angle*(Mathf.PI/180f);
			var rotatedX = Mathf.Cos(angle) * (point.x - pivot.x) - Mathf.Sin(angle) * (point.y-pivot.y) + pivot.x;
			var rotatedY = Mathf.Sin(angle) * (point.x - pivot.x) + Mathf.Cos(angle) * (point.y - pivot.y) + pivot.y;
			return new Vector3(rotatedX,rotatedY,0);		
		}

		/// <summary>
		/// Rotates a point around the given pivot.
		/// </summary>
		/// <returns>The new point position.</returns>
		/// <param name="point">The point to rotate.</param>
		/// <param name="pivot">The pivot's position.</param>
		/// <param name="angles">The angle as a Vector3.</param>
		public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angle) 
		{
			// we get point direction from the point to the pivot
		   	Vector3 direction = point - pivot; 
		   	// we rotate the direction
		   	direction = Quaternion.Euler(angle) * direction; 
		   	// we determine the rotated point's position
		   	point = direction + pivot; 
		   	return point; 
		 }

		/// <summary>
		/// Returns the sum of all the int passed in parameters
		/// </summary>
		/// <param name="thingsToAdd">Things to add.</param>
		public static int Sum(params int[] thingsToAdd)
		{
			int result=0;
			for (int i = 0; i < thingsToAdd.Length; i++)
			{
				result += thingsToAdd[i];
			}
			return result;
		}

		/// <summary>
		/// Returns the result of rolling a dice of the specified number of sides
		/// </summary>
		/// <returns>The result of the dice roll.</returns>
		/// <param name="numberOfSides">Number of sides of the dice.</param>
		public static int RollADice(int numberOfSides)
		{
			return (UnityEngine.Random.Range(1,numberOfSides));
		}

		/// <summary>
		/// Returns a random success based on X% of chance.
		/// Example : I have 20% of chance to do X, Chance(20) > true, yay!
		/// </summary>
		/// <param name="percent">Percent of chance.</param>
		public static bool Chance(int percent)
		{
			return (UnityEngine.Random.Range(0,100) <= percent);
		}

		/// <summary>
		/// Moves from "from" to "to" by the specified amount and returns the corresponding value
		/// </summary>
		/// <param name="from">From.</param>
		/// <param name="to">To.</param>
		/// <param name="amount">Amount.</param>
		public static float Approach(float from, float to, float amount)
		{
			if (from < to)
			{
				from += amount;
				if (from > to)
				{
					return to;
				}
			}
			else
			{
				from -= amount;
				if (from < to)
				{
					return to;
				}
			}
			return from;
		} 
	}
}