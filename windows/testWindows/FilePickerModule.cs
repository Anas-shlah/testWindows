using Microsoft.ReactNative;
using Windows.Storage.Pickers;
using Windows.Storage;
using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace YourNamespace
{
    [ReactModule("FilePickerModule")] // هذا التعريف يربط الوحدة بـ React Native
    public class FilePickerModule
    {
        [ReactMethod("openFilePicker")] // هذا التعريف يسمح باستدعاء الدالة من React Native
        public async Task<string> OpenFilePickerAsync()
        {
            var picker = new FileOpenPicker();
            picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".png");

            // هذا الجزء يضمن أن نافذة الاختيار تظهر فوق نافذة التطبيق
            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(App.Window);
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hwnd);

            // فتح نافذة اختيار الملف
            StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                return file.Path;  // إرجاع مسار الملف إذا تم اختياره
            }
            return null;  // إرجاع null إذا لم يتم اختيار أي ملف
        }
    }
}
