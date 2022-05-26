using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NativeTest1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            webtestname.ScriptNotify += Webtestname_ScriptNotify;

        }

        private async void Webtestname_ScriptNotify(object sender, NotifyEventArgs e)
        {
            switch (e.Value.ToLower())
            {
                case "loading":
                case "getdevices":
                    // get the list of the devices and send them back
                    var deviceList = await GetAllConnectedCameras();
                    // fake some camera devices
                    deviceList.Add("fake cam 1");
                    deviceList.Add("fake cam 2");
                    deviceList.Add("fake cam 3");
                    await webtestname.InvokeScriptAsync("deviceList", new List<string> { JsonConvert.SerializeObject(deviceList) });
                    break;
                case "activate_camera":
                    // Open camera device
                    break;
                default:
                    break;
            }
        }

        public async Task<List<string>> GetAllConnectedCameras()
        {
            var cameraNames = new List<string>();
            var allVideoDevices = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);
            var reader = await DeviceInformation.FindAllAsync(DeviceClass.ImageScanner);
            allVideoDevices.ToList().ForEach(d=> {
                cameraNames.Add(d.Name);
            });

            return cameraNames;
        }

    }
}
