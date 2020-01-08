# How to customize agenda view height based on SfSchedule height?
SfSchedule allows you to customize AgendaView height in runtime. This article explains you how to customize the AgendaView height based on schedule height and device orientation in runtime.

**Step 1:** Initialize event handler for SizeChanged event of SfSchedule.

```C#
schedule.SizeChanged += OnScheduleSizeChanged;
```

**Step 2:** In SizeChanged event handler, get SfSchedule height and based on SfSchedule height and orientation, calculate height for AgendaView and assign it to AgendaViewHeight property of SfSchedule MonthViewSettings.

```C#
private void OnScheduleSizeChanged(object sender, EventArgs e)
{
        var scheduler = sender as SfSchedule;
        if(scheduler.Width > scheduler.Height && Device.RuntimePlatform != Device.UWP)
        {
                schedule.MonthViewSettings.AgendaViewHeight = schedule.Height * 0.3;
         }
         else
         {
                schedule.MonthViewSettings.AgendaViewHeight = schedule.Height * 0.5;
         }
}
```
