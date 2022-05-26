using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;

namespace runtimeCompTest1
{
    [AllowForWeb]
    public sealed class KeyHandler
    {    
        public void setKeyCombination(int keyPress)
        {
            Debug.WriteLine("Called from WebView! {0}", keyPress);
        }
    }
}
