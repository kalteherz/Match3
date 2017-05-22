/*
 * Author: Bolotin S.E.
 */
 
using System;
using System.Drawing;
using System.Linq;

namespace Match3
{
	public abstract class Elem {
		
		static Type[] typeList = System.Reflection.Assembly.GetExecutingAssembly().GetTypes().Where(t => t.BaseType.Name == "Elem").ToArray();
		
		static Random rnd = new Random();

		PointF pos;
		float jump = 0;
		float jumpDir = 1;
		
		public bool NeedRemove = false;
		public bool Selected = false;

		public Field Owner {
			get; set;
		}
		
		public static Elem Random(Field owner) {
			Elem elem = (Elem)Activator.CreateInstance(typeList[rnd.Next(typeList.Length)]);
			elem.Owner = owner;
			return elem;
		}
		
		public void SetPosition(PointF pos) {
			this.pos = pos;
		}
		
		public Rectangle Rect() {
			int shiftX = Owner.CellSize.Width / 6;
			int shiftY = Owner.CellSize.Height / 6;
			if (!Selected) {
				jump = 0;
				jumpDir = 1;
			} else {
				jump += jumpDir * Owner.FrameTime * shiftY / 150f;
				if (Math.Abs(jump) >= shiftY - 2) {
					jump = jumpDir * (shiftY - 2.1f);
					jumpDir = -jumpDir;
				}
			}
			return new Rectangle(
				(int)pos.X + shiftX, (int)(pos.Y + jump) + shiftY,
			    Owner.CellSize.Width - 2 * shiftX,
			    Owner.CellSize.Height - 2 * shiftY
			);
		}
		
		public void Draw(Graphics canvas) {
			DrawShape(canvas);
		}
		
		protected abstract void DrawShape(Graphics canvas);
		
		private float CalcCoord(float curCoord, float targetCoord, float shift) {
			if (curCoord.Equals(targetCoord))
				return targetCoord;
			if (Math.Abs(targetCoord - curCoord) > shift) {
				if (curCoord > targetCoord)
					shift = -shift;
				curCoord += shift;
				if (Math.Abs(curCoord - targetCoord) < 0.5)
					curCoord = targetCoord;
			} else
				curCoord = targetCoord;
			Owner.Animation =  true;
			return curCoord;
		}
		
		public void CalcPosition(float shift, PointF target) {
			if (!target.Equals(pos)) {
				pos.X = CalcCoord(pos.X, target.X, shift);
				pos.Y = CalcCoord(pos.Y, target.Y, shift);
			}
		}
	}
}
