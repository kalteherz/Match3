/*
 * Author: Bolotin S.E.
 */

using System;
using System.Drawing;

namespace Match3 {

	public class Field {
		
		private Elem[,] table;
		private Size size;
		private Size cellSize;
		private Point mousePosition;
		private Elem selectedCell;
		private Point selectedCellPosition;
		
		public long FrameTime {
			get; set;
		}
		
		public bool Busy {
			get {
				return Animation || CellsChanged || CellsMatched;
			}
		}
		
		public Point SelectedCell {
			get {
				return selectedCellPosition;
			}
			set {
				selectedCellPosition = value;
				if (selectedCell != null)
					selectedCell.Selected = false;
				if (CellOnScreen(value)) {
					selectedCell = table[value.X, value.Y];
					selectedCell.Selected = true;
				} else
					selectedCell = null;
			}
		}
		
		public Point MousePosition {
			get {
				return mousePosition; 
			}
			set {
				if ((value.X < 0) || (value.Y < 0))
					mousePosition = value;
				else {
					mousePosition.X = Math.Min(ColCount - 1, value.X / CellSize.Width);
					mousePosition.Y = Math.Min(RowCount - 1, value.Y / CellSize.Height);
				}
			}
		}
		
		public bool CellOnScreen(Point cell) {
			return 
				(cell.X >= 0) && (cell.X < ColCount) &&
				(cell.Y >= 0) && (cell.Y < RowCount);
		}
		
		public bool Animation {
			get; set;
		}
		
		public bool CellsMatched {
			get; set;
		}
		
		public bool CellsChanged {
			get; set;
		}
		
		public Size Size {
			get {
				return size;
			}
			set {
				size = value;
				cellSize = new Size(
					size.Width / ColCount,
					size.Height / RowCount
				);
			}
		}
		
		public Size CellSize {
			get {
				return cellSize;
			}
		}
		
		public void SetSize(Size size) {
			Size = size;
		}
		
		public Field(Size size, int colCount, int rowCount)
		{
			table = new Elem[colCount, rowCount];
			Size = size;
			Animation = true;
			CellsMatched = true;
			CellsChanged = false;
			SelectedCell = new Point(-1, -1);
			MousePosition = new Point(-1, -1);
			for (int i = 0; i < ColCount; i++)
				for (int j = 0; j < RowCount; j++) {
				table[i, j] = Elem.Random(this);
					table[i, j].SetPosition(new PointF(i * CellSize.Width, (j - RowCount) * CellSize.Height));
				}
		}
		
		public int ColCount {
			get {
				return table.GetLength(0);
			}
		}
		
		public int RowCount {
			get {
				return table.GetLength(1);
			}
		}

		public void SwapCells(Point c1, Point c2) {
			Elem tmp = table[c2.X, c2.Y];
			table[c2.X, c2.Y] = table[c1.X, c1.Y];
			table[c1.X, c1.Y] = tmp;
			Animation = true;
		}
		
		public void CalcPositions() {
			Animation = false;
			float shift = FrameTime * CellSize.Width / 100f;
			for (int i = 0; i < ColCount; i++)
				for (int j = 0; j < RowCount; j++) {
					table[i, j].CalcPosition(
						shift,
						new PointF(i * CellSize.Width, j * CellSize.Height)
					);
				}
		}

		public void DrawField(Graphics canvas) {
			canvas.Clear(Color.LightGray);
			if (!Busy)
				canvas.FillRectangle(new SolidBrush(Color.WhiteSmoke), MousePosition.X * CellSize.Width + 1, MousePosition.Y * CellSize.Height + 1, CellSize.Width - 1, CellSize.Height - 1);

			Pen pen = new Pen(Color.Black);
			canvas.DrawRectangle(pen, new Rectangle(0, 0, size.Width - 1, size.Height - 1));
			for (int i = 0; i < ColCount; i++)
				for (int j = 0; j < RowCount; j++) {
					canvas.DrawRectangle(pen, i * CellSize.Width, j * CellSize.Height, CellSize.Width, CellSize.Height);
				}
			foreach (Elem cell in table) {
				cell.Draw(canvas);
			}
		}
		
		private bool FindMatch() {
			bool result = false;
			for (int i = 0; i < ColCount; i++) {
				int matchCount = 1;
				for (int j = 1; j <= RowCount; j++) {
					if ((j == RowCount) || (table[i, j].GetType() != table[i, j - 1].GetType())) {
						if (matchCount >= 3) {
							result = true;
							for (int k = j - matchCount; k < j ; k++) {
								table[i, k].NeedRemove = true;
							}
						}
						matchCount = 1;
					} else {
						matchCount++;
					}
				}
			}
			for (int j = 0; j < RowCount; j++) {
				int matchCount = 1;
				for (int i = 1; i <= ColCount; i++) {
					if ((i == ColCount) || (table[i, j].GetType() != table[i - 1, j].GetType())) {
						if (matchCount >= 3) {
							result = true;
							for (int k = i - matchCount; k < i ; k++) {
								table[k, j].NeedRemove = true;
							}
						}
						matchCount = 1;
					} else {
						matchCount++;
					}
				}
			}
			return result;
		}
		
		private void SortCol(int col) { // Bubble :)
			bool needSort;
			do {
				needSort = false;
				for (int j = 1; j < RowCount; j++) {
					if (table[col, j].NeedRemove && !table[col, j - 1].NeedRemove) {
						SwapCells(new Point(col, j), new Point(col, j - 1));
						needSort = true;
					}
				}
			} while (needSort);
		}
		
		private int RemoveCells() {
			int scores = 0;
			for (int i = 0; i < ColCount; i++) {
				SortCol(i);
				int newCellCount = 0;
				for (int j = RowCount - 1; j >= 0; j--) {
					if (table[i, j].NeedRemove) {
						newCellCount++;
						table[i, j] = Elem.Random(this);
						table[i, j].SetPosition(new PointF(i * CellSize.Width, -newCellCount * CellSize.Height));
					}
				}
				scores += newCellCount;
			}
			return scores;
		}
	
		public int FindRemoveMatch() {
			FindMatch();
			int scores = RemoveCells();
			CellsMatched = scores != 0;
			Animation = Animation || CellsMatched;
			return scores;
		}
		
	}
}
