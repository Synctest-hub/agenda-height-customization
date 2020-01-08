using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AgendaHeightCustomization
{
    public class ScheduleBehavior : Behavior<ContentPage>
    {
        SfSchedule schedule;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            this.schedule = bindable.FindByName<SfSchedule>("schedule");
            this.schedule.SizeChanged += OnScheduleSizeChanged;
            this.schedule.MonthViewSettings.ShowAgendaView = true;
        }

        private void OnScheduleSizeChanged(object sender, EventArgs e)
        {
            var scheduler = sender as SfSchedule;
            if (scheduler.Width > scheduler.Height && Device.RuntimePlatform != Device.UWP)
            {
                schedule.MonthViewSettings.AgendaViewHeight = schedule.Height * 0.3;
            }
            else
            {
                schedule.MonthViewSettings.AgendaViewHeight = schedule.Height * 0.6;
            }
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            this.schedule.SizeChanged -= OnScheduleSizeChanged;
            this.schedule = null;
        }
    }
}
