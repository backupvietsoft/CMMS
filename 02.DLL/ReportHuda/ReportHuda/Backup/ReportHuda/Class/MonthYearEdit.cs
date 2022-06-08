using System;
using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Calendar;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraEditors.Repository;

namespace ReportHuda
{
	public class MMonthYearEdit : DateEdit
	{
        public static Boolean _MMonthYear;
        public Boolean MMonthYear { get { return _MMonthYear; } set { _MMonthYear = value; } }



        public MMonthYearEdit()
        {
            if (_MMonthYear)
                Properties.Mask.EditMask = "y";
            else
                Properties.Mask.EditMask = "d";
        }

		protected override PopupBaseForm CreatePopupForm()
		{
			return new YearMonthVistaPopupDateEditForm(this,_MMonthYear);
		}

		protected override void CreateRepositoryItem()
		{
			fProperties = new YearMonthRepositoryItemDateEdit(this);
		}

		class YearMonthRepositoryItemDateEdit : RepositoryItemDateEdit
		{
			public YearMonthRepositoryItemDateEdit(DateEdit dateEdit)
			{
				SetOwnerEdit(dateEdit);
			}

			[Browsable(false)]
			public override bool ShowToday
			{
				get
				{
					return false;
				}
			}
		}

		class YearMonthVistaPopupDateEditForm : VistaPopupDateEditForm
		{
            public YearMonthVistaPopupDateEditForm(DateEdit ownerEdit,Boolean MM ): base(ownerEdit) {}

            protected override DateEditCalendar CreateCalendar()
			{
                return new YearMonthVistaDateEditCalendar(OwnerEdit.Properties, OwnerEdit.EditValue);
			}
		}

		class YearMonthVistaDateEditCalendar : VistaDateEditCalendar
		{
            public YearMonthVistaDateEditCalendar(RepositoryItemDateEdit item, object editDate): base(item, editDate) 
            {}

			protected override void Init()
			{
                
				base.Init();
                if (!_MMonthYear)
                    View = DateEditCalendarViewType.YearsInfo;
                else
                    View = DateEditCalendarViewType.YearInfo;
			}

			protected override void OnItemClick(CalendarHitInfo hitInfo)
			{
				DayNumberCellInfo cell = (DayNumberCellInfo)hitInfo.HitObject;
                if (!_MMonthYear)
                {
                    if (View == DateEditCalendarViewType.YearsInfo)
                    {
                        //DateTime date = new DateTime(DateTime.Year, cell.Date.Month, 1);                    
                        DateTime date = new DateTime(cell.Date.Year, 1, 1);
                        OnDateTimeCommit(date, false);
                    }
                    else
                    {
                        base.OnItemClick(hitInfo);
                    }
                }
                else
                {
                    if (View == DateEditCalendarViewType.YearInfo)
                    {
                        DateTime date = new DateTime(cell.Date.Year, cell.Date.Month, 1);                    
                        OnDateTimeCommit(date, false);
                    }
                    else
                    {
                        base.OnItemClick(hitInfo);
                    }                
                }
			}
		}
	}
}
