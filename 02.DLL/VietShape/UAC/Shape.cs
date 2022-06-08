using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace VietShape
{	
	public class Shape : System.Windows.Forms.UserControl
	{		
		private System.ComponentModel.Container components = null;		
		Rectangle BaseRect;
		Rectangle ControlRect;
		Rectangle[]SmallRect = new Rectangle[8];
		Size Sqare = new Size(5,5);
        Graphics Graphic;
		Control currentControl;
		private Point PrevLeftClick;        
		private bool IsFirst = true;
		Color MyBackColor = Color.Wheat;	
		Color SqareColor = Color.White;
		Color SqareLineColor = Color.Black;
		public Control Control
		{
			get {return currentControl;}
			set 
			{
                currentControl = value;
                Rect = currentControl.Bounds;
			}
		}	
		enum RESIZE_BORDER
		{
			RB_NONE = 0,
			RB_TOP = 1,
			RB_RIGHT = 2,
			RB_BOTTOM = 3,
			RB_LEFT = 4,
			RB_TOPLEFT = 5,
			RB_TOPRIGHT = 6,
			RB_BOTTOMLEFT = 7,
			RB_BOTTOMRIGHT = 8
		}
		private RESIZE_BORDER CurrBorder;
		public Rectangle Rect
		{
			get {return BaseRect;}
			set 
			{
				int X = Sqare.Width;
				int Y = Sqare.Height;
				int Height = value.Height;
				int Width = value.Width;
				BaseRect = new Rectangle(X,Y,Width,Height);
				SetRectangles();
			}
			
		}
		void SetRectangles()
		{
			//TopLeft
            SmallRect[0] = new Rectangle(new Point(BaseRect.X - Sqare.Width, BaseRect.Y - Sqare.Height), Sqare);
			//TopRight
			SmallRect[1] = new Rectangle(new Point(BaseRect.X + BaseRect.Width,BaseRect.Y - Sqare.Height),Sqare);
			//BottomLeft
			SmallRect[2] = new Rectangle(new Point(BaseRect.X - Sqare.Width,BaseRect.Y + BaseRect.Height),Sqare);
			//BottomRight
			SmallRect[3] = new Rectangle(new Point(BaseRect.X + BaseRect.Width,BaseRect.Y + BaseRect.Height),Sqare);
			//TopMiddle
			SmallRect[4] = new Rectangle(new Point(BaseRect.X + (BaseRect.Width/2) - (Sqare.Width/2) ,BaseRect.Y - Sqare.Height),Sqare);
			//BottomMiddle
			SmallRect[5] = new Rectangle(new Point(BaseRect.X + (BaseRect.Width/2) - (Sqare.Width/2) ,BaseRect.Y + BaseRect.Height),Sqare);
			//LeftMiddle
			SmallRect[6] = new Rectangle(new Point(BaseRect.X - Sqare.Width,BaseRect.Y + (BaseRect.Height/2) - (Sqare.Height/2)),Sqare);
			//RightMiddle
			SmallRect[7] = new Rectangle(new Point(BaseRect.X + BaseRect.Width,BaseRect.Y + (BaseRect.Height/2) - (Sqare.Height/2)),Sqare);			
			//the whole tracker rect
			ControlRect = new Rectangle(new Point(0,0),this.Bounds.Size);
		}
		public void Draw()
		{
			try
			{
				//draw sqares
                Graphic.FillRectangles(Brushes.Black, SmallRect);
				//fill sqares
                Graphic.DrawRectangles(Pens.Black, SmallRect);
			}

			catch (Exception ex)
			{
                MessageBox.Show(ex.ToString());
			}
		}
		public bool HitTrack(Point point)
		{
			if (!ControlRect.Contains(point))
			{				
				Cursor.Current = Cursors.Arrow;
				
				return false;
			}
			else if(SmallRect[0].Contains(point))
			{
				Cursor.Current = Cursors.SizeNWSE;
				CurrBorder = RESIZE_BORDER.RB_TOPLEFT;
			}
			else if(SmallRect[3].Contains(point))
			{
				Cursor.Current = Cursors.SizeNWSE;
				CurrBorder = RESIZE_BORDER.RB_BOTTOMRIGHT;
			}
			else if(SmallRect[1].Contains(point))
			{
				Cursor.Current = Cursors.SizeNESW;
				CurrBorder = RESIZE_BORDER.RB_TOPRIGHT;
			}
			else if(SmallRect[2].Contains(point))
			{
				Cursor.Current = Cursors.SizeNESW;
				CurrBorder = RESIZE_BORDER.RB_BOTTOMLEFT;
			}
			else if(SmallRect[4].Contains(point))
			{
				Cursor.Current = Cursors.SizeNS;
				CurrBorder = RESIZE_BORDER.RB_TOP;
			}
			else if(SmallRect[5].Contains(point))
			{
				Cursor.Current = Cursors.SizeNS;
				CurrBorder = RESIZE_BORDER.RB_BOTTOM;
			}
			else if(SmallRect[6].Contains(point))
			{
				Cursor.Current = Cursors.SizeWE;
				CurrBorder = RESIZE_BORDER.RB_LEFT;
			}
			else if(SmallRect[7].Contains(point))
			{
				Cursor.Current = Cursors.SizeWE;
				CurrBorder = RESIZE_BORDER.RB_RIGHT;
			}
			else if(ControlRect.Contains(point))
			{
				Cursor.Current = Cursors.SizeAll;
				CurrBorder = RESIZE_BORDER.RB_NONE;
				
			}						
			return true;
		}
		public bool HitTrack(int x, int y)
		{
			return HitTrack(new Point(x,y));
		}
		public Shape(Control theControl)
		{
            currentControl = theControl;            
			InitializeComponent();			
			Create();
			
		}
		public Shape()
		{			
			InitializeComponent();
		}
		private void Create()
		{
			int X = currentControl.Bounds.X - Sqare.Width;
			int Y = currentControl.Bounds.Y - Sqare.Height;
			int Height = currentControl.Bounds.Height + (Sqare.Height*2);
			int Width = currentControl.Bounds.Width + (Sqare.Width*2);
			this.Bounds = new Rectangle(X,Y,Width+1,Height+1);			
			this.BringToFront();
			Rect = currentControl.Bounds;
			this.Region = new Region(BuildFrame());
            Graphic = this.CreateGraphics();

		}
		private GraphicsPath BuildFrame()
		{
			GraphicsPath path = new GraphicsPath();
			//Top Rectagle
			path.AddRectangle(new Rectangle(0,0,currentControl.Width + (Sqare.Width*2)+1,Sqare.Height+1));;
			//Left Rectangle
			path.AddRectangle(new Rectangle(0,Sqare.Height+1,Sqare.Width+1,currentControl.Bounds.Height + Sqare.Height+1));
			//Bottom Rectagle
			path.AddRectangle(new Rectangle(Sqare.Width+1,currentControl.Bounds.Height + Sqare.Height,currentControl.Width + Sqare.Width +1,Sqare.Height+1));
			//Right Rectagle
			path.AddRectangle(new Rectangle(currentControl.Width + Sqare.Width,Sqare.Height+1,Sqare.Width+1,currentControl.Height-2));			
			return path;
		}
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#region Component Designer generated code
		private void InitializeComponent()
		{			
			this.BackColor = System.Drawing.Color.Transparent;            
            this.currentControl.Capture = false;
			this.Name = "Shape";
			this.Size = new System.Drawing.Size(64, 56);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Shape_MouseUp);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Shape_Paint);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Shape_MouseMove);            
		}        
		#endregion		
		public void Mouse_Move(object sender,System.Windows.Forms.MouseEventArgs e)
		{
            currentControl.BringToFront();
            currentControl.Capture = false ;
			//minimum size for the control is 8x8
			if (currentControl.Height < 8)
			{
				currentControl.Height = 8;
				return;
			}
			else if (currentControl.Width < 8)
			{
				currentControl.Width = 8;
				return;
			}
					
			switch(this.CurrBorder)
			{
				case RESIZE_BORDER.RB_TOP:
					currentControl.Height = currentControl.Height - e.Y + PrevLeftClick.Y;
                    if (currentControl.Height > 8)
                        currentControl.Top = currentControl.Top + e.Y - PrevLeftClick.Y;					
					break;
				case RESIZE_BORDER.RB_TOPLEFT:
					currentControl.Height = currentControl.Height - e.Y + PrevLeftClick.Y;
					if (currentControl.Height > 8)
					currentControl.Top =currentControl.Top + e.Y - PrevLeftClick.Y;
					currentControl.Width = currentControl.Width - e.X + PrevLeftClick.X;
					if (currentControl.Width > 8)
					currentControl.Left =currentControl.Left + e.X - PrevLeftClick.X;
					break;
				case RESIZE_BORDER.RB_TOPRIGHT:
					currentControl.Height = currentControl.Height - e.Y + PrevLeftClick.Y;
					if (currentControl.Height > 8)
					currentControl.Top = currentControl.Top + e.Y - PrevLeftClick.Y;
					currentControl.Width = currentControl.Width + e.X - PrevLeftClick.X;
					break;
				case RESIZE_BORDER.RB_RIGHT:
					currentControl.Width = currentControl.Width + e.X - PrevLeftClick.X;
					break;
				case RESIZE_BORDER.RB_BOTTOM:
					currentControl.Height = currentControl.Height + e.Y - PrevLeftClick.Y;
					break;
				case RESIZE_BORDER.RB_BOTTOMLEFT:
					currentControl.Height = currentControl.Height + e.Y - PrevLeftClick.Y;
					currentControl.Width = currentControl.Width - e.X + PrevLeftClick.X;
					if (currentControl.Width > 8)
						currentControl.Left = currentControl.Left + e.X - PrevLeftClick.X;
					break;
				case RESIZE_BORDER.RB_BOTTOMRIGHT:
					currentControl.Height = currentControl.Height + e.Y - PrevLeftClick.Y;
					currentControl.Width = currentControl.Width + e.X - PrevLeftClick.X;
					break;
				case RESIZE_BORDER.RB_LEFT:
					currentControl.Width = currentControl.Width - e.X + PrevLeftClick.X;
					if (currentControl.Width > 8)
					currentControl.Left = currentControl.Left + e.X - PrevLeftClick.X;
					break;
				case RESIZE_BORDER.RB_NONE:
					currentControl.Location = new Point(currentControl.Location.X + e.X - PrevLeftClick.X, currentControl.Location.Y + e.Y - PrevLeftClick.Y);
					break;
				
			}

		}
		private void Shape_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Cursor = Cursors.Arrow;
			
			if (e.Button == MouseButtons.Left)
			{
				// If this is the first mouse move event for left click dragging of the form,
				// store the current point clicked so that we can use it to calculate the form's
				// new location in subsequent mouse move events due to left click dragging of the form
				if(IsFirst == true)
				{
					// Store previous left click position
					PrevLeftClick = new Point(e.X, e.Y);

					// Subsequent mouse move events will not be treated as first time, until the
					// left mouse click is released or other mouse click occur
					IsFirst = false;
				}
				else
				{
					//hide tracker
					this.Visible = false;
					//forward mouse position to append changes
					Mouse_Move(this,e);
					// Store new previous left click position
					PrevLeftClick = new Point(e.X, e.Y);
				}
				
				
			}
			else
			{
				// This is a new mouse move event so reset flag
				IsFirst = true;
				//show the tracker
				this.Visible = true;
				
				//update the mouse pointer to other cursors by checking it's position
				HitTrack(e.X,e.Y);
			}

			
		}
		private void Shape_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			//redraw sqares
			Draw();
		}
		private void Shape_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			//the mouse is up, recreate the control to append changes
			Create();
			this.Visible = true;
			
		}
	}
}
