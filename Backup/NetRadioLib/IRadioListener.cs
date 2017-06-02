using System;
using System.Text;
using System.Threading;
using System.IO;

using System.Collections;
using System.ComponentModel;

using System.Data;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Wma;
using Un4seen.Bass.AddOn.Tags;
public interface IRadioListener
{
    void tagUpdate();
    void statusUpdate();
    void messagesUpdate();
}