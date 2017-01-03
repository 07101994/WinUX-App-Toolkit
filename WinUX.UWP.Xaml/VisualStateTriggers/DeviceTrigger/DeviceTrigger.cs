﻿namespace WinUX.Xaml.VisualStateTriggers.DeviceTrigger
{
    using Windows.System.Profile;
    using Windows.UI.Xaml;

    using WinUX.Device.Profile;

    /// <summary>
    /// Defines a visual state trigger for the current device type.
    /// </summary>
    public sealed partial class DeviceTrigger : VisualStateTriggerBase
    {
        private static readonly DeviceType CurrentDevice;

        static DeviceTrigger()
        {
            CurrentDevice = AnalyticsInfo.VersionInfo.GetDeviceType();
        }

        private static void OnDeviceTypeChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var trigger = (DeviceTrigger)obj;
            var newVal = (DeviceType)args.NewValue;

            switch (CurrentDevice)
            {
                case DeviceType.Desktop:
                    trigger.IsActive = newVal == DeviceType.Desktop;
                    break;
                case DeviceType.Mobile:
                    trigger.IsActive = IsInContinuum() && trigger.SupportsContinuum
                                           ? newVal == DeviceType.MobileContinuum
                                           : newVal == DeviceType.Mobile;
                    break;
                case DeviceType.SurfaceHub:
                    trigger.IsActive = newVal == DeviceType.SurfaceHub;
                    break;
                case DeviceType.IoT:
                    trigger.IsActive = newVal == DeviceType.IoT;
                    break;
                case DeviceType.Xbox:
                    trigger.IsActive = newVal == DeviceType.Xbox;
                    break;
                case DeviceType.Holographic:
                    trigger.IsActive = newVal == DeviceType.Holographic;
                    break;
                default:
                    trigger.IsActive = newVal == DeviceType.Unknown;
                    break;
            }
        }

        private static bool IsInContinuum()
        {
            return CurrentDevice == DeviceType.Mobile && DeviceTrigger.ScreenDiagonal > 7;
        }
    }
}