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

namespace Radio
{
    public class NetRadio
    {


        public String[] icyTags;
        public String _Artist;
        public String _Title;
        public String _Album;
        public String _Comment;
        public String _Genre;
        public String _Year;
        public String _error;
        public String _buffering;
        public String _radioName;
        private System.Windows.Forms.Form parent;
        private IRadioListener listen;
        private RadioRecorder recorderr = new RadioRecorder();
        public Boolean recording = false;
        public Boolean continuous = true;
        private String recPath;
        private System.ComponentModel.Container components = null;

        public NetRadio(System.Windows.Forms.Form parent,IRadioListener listener)
        {
            this.parent = parent;
            this.listen = listener;

            _myUserAgentPtr = Marshal.StringToHGlobalAnsi(_myUserAgent);
        }




        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>


        // PINNED
        private string _myUserAgent = "RADIO42";
        [FixedAddressValueType()]
        public IntPtr _myUserAgentPtr;
     

        // LOCAL VARS
        public int _Stream = 0;
        public string _url = String.Empty;
        private DOWNLOADPROC myStreamCreateURL;
        private TAG_INFO _tagInfo;
        private SYNCPROC mySync;

        private int _wmaPlugIn = 0;

        public void NetRadio_Load()//IRadioListener listener)
        {
            //BassNet.Registration("your email", "your regkey");
            
            //this.listen = listener;
            // check the version..
            if (Utils.HighWord(Bass.BASS_GetVersion()) != Bass.BASSVERSION)
            {
                _error = "Wrong Bass Version!";
            }

            // stupid thing here as well, just to demo...
            //string userAgent = Bass.BASS_GetConfigString(BASSConfig.BASS_CONFIG_NET_AGENT);

            Bass.BASS_SetConfigPtr(BASSConfig.BASS_CONFIG_NET_AGENT, _myUserAgentPtr);

            Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_NET_PREBUF, 0); // so that we can display the buffering%
            Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_NET_PLAYLIST, 1);

            if (Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, parent.Handle))
            {
                // Some words about loading add-ons:
                // In order to set an add-on option with BASS_SetConfig, we need to make sure, that the
                // library (in this case basswma.dll) is actually loaded!
                // However, an external library is dynamically loaded in .NET with the first call 
                // to one of it's methods...
                // As BASS will only know about additional config options once the lib has been loaded,
                // we need to make sure, that the lib is loaded before we make the following call.
                // 1) Loading a lib manually :
                // BassWma.LoadMe();  // basswma.dll must be in same directory
                // 2) Using the BASS PlugIn system (recommended):
                _wmaPlugIn = Bass.BASS_PluginLoad("basswma.dll");
                // 3) ALTERNATIVLY you might call any 'dummy' method to load the lib!
                //int[] cbrs = BassWma.BASS_WMA_EncodeGetRates(44100, 2, BASSWMAEncode.BASS_WMA_ENCODE_RATES_CBR);
                // now basswma.dll is loaded and the additional config options are available...

                if (Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_WMA_PREBUF, 0) == false)
                {
                    Console.WriteLine("ERROR: " + Enum.GetName(typeof(BASSError), Bass.BASS_ErrorGetCode()));
                }
                // we alraedy create the user callback methods...
                myStreamCreateURL = new DOWNLOADPROC(MyDownloadProc);
            }
            else

                _error = "Bass_Init error!";
        }

        public void NetRadio_Close()
        {
            Bass.BASS_PluginFree(_wmaPlugIn);
            // close bass
            Bass.BASS_Stop();
            Bass.BASS_Free();

            Bass.BASS_PluginFree(_wmaPlugIn);
        }
        public void stopRadio()
        {
            stopRecord();
            Bass.BASS_StreamFree(_Stream);
        }
        public void playRadio(string url)
        {
            stopRecord();
            Bass.BASS_StreamFree(_Stream);

            _url = url;
            // test BASS_StreamCreateURL

            bool isWMA = false;
            _buffering = "Conectando..";
            listen.statusUpdate();
            if (_url != String.Empty)
            {

                // create the stream
                _Stream = Bass.BASS_StreamCreateURL(_url, 0, BASSFlag.BASS_STREAM_STATUS, myStreamCreateURL, IntPtr.Zero);
                if (_Stream == 0)
                {
                    // try WMA streams...
                    _Stream = BassWma.BASS_WMA_StreamCreateFile(_url, 0, 0, BASSFlag.BASS_DEFAULT);
                    if (_Stream != 0)
                        isWMA = true;
                    else
                    {
                        // error

                        _buffering = "No se Puede Conectar.";
                        listen.statusUpdate();
                        return;
                    }
                }
                _tagInfo = new TAG_INFO(_url);
                BASS_CHANNELINFO info = Bass.BASS_ChannelGetInfo(_Stream);
                if (info.ctype == BASSChannelType.BASS_CTYPE_STREAM_WMA)
                    isWMA = true;
                // ok, do some pre-buffering...
                _buffering = "buffering...";
                listen.statusUpdate();
                if (!isWMA)
                {
                    // display buffering for MP3, OGG...
                    while (true)
                    {
                        long len = Bass.BASS_StreamGetFilePosition(_Stream, BASSStreamFilePosition.BASS_FILEPOS_END);
                        if (len == -1)
                            break; // typical for WMA streams
                        // percentage of buffer filled
                        float progress = (
                            Bass.BASS_StreamGetFilePosition(_Stream, BASSStreamFilePosition.BASS_FILEPOS_DOWNLOAD) -
                            Bass.BASS_StreamGetFilePosition(_Stream, BASSStreamFilePosition.BASS_FILEPOS_CURRENT)
                            ) * 100f / len;

                        if (progress > 75f)
                        {
                            break; // over 75% full, enough
                        }

                        _buffering = String.Format("buffering... {0}%", progress);
                        listen.statusUpdate();
                    }
                }
                else
                {
                    // display buffering for WMA...
                    while (true)
                    {
                        long len = Bass.BASS_StreamGetFilePosition(_Stream, BASSStreamFilePosition.BASS_FILEPOS_WMA_BUFFER);
                        if (len == -1L)
                            break;
                        // percentage of buffer filled
                        if (len > 75L)
                        {
                            break; // over 75% full, enough
                        }

                        _buffering = String.Format("buffering... {0}%", len);
                        listen.statusUpdate();
                    }
                }

                // get the meta tags (manually - will not work for WMA streams here)
                string[] icy = Bass.BASS_ChannelGetTagsICY(_Stream);
                if (icy == null)
                {
                    // try http...
                    icy = Bass.BASS_ChannelGetTagsHTTP(_Stream);
                }
                if (icy != null)
                {
                    foreach (string tag in icy)
                    {
                        _error += "ICY: " + tag + Environment.NewLine;
                        if (tag.StartsWith("icy-name"))
                        {
                            _radioName = tag.Split(':')[1];
                        }
                    }
                }
                listen.tagUpdate(); 
                // get the initial meta data (streamed title...)
                icy = Bass.BASS_ChannelGetTagsMETA(_Stream);
                if (icy != null)
                {
                    foreach (string tag in icy)
                    {
                        _error = "Meta: " + tag + Environment.NewLine;
                    }
                }
                else
                {
                    // an ogg stream meta can be obtained here
                    icy = Bass.BASS_ChannelGetTagsOGG(_Stream);
                    if (icy != null)
                    {
                        foreach (string tag in icy)
                        {
                            _error += "Meta: " + tag + Environment.NewLine;
                        }
                    }
                }
                icyTags = icy;
                // alternatively to the above, you might use the TAG_INFO (see BassTags add-on)
                // This will also work for WMA streams here ;-)
                if (BassTags.BASS_TAG_GetFromURL(_Stream, _tagInfo))
                {
                    // and display what we get
                    _Album = _tagInfo.album;
                    _Artist = _tagInfo.artist;
                    _Title = _tagInfo.title;
                    _Comment = _tagInfo.comment;
                    _Genre = _tagInfo.genre;
                    _Year = _tagInfo.year;
                }
                
                // set a sync to get the title updates out of the meta data...
                mySync = new SYNCPROC(MetaSync);
                Bass.BASS_ChannelSetSync(_Stream, BASSSync.BASS_SYNC_META, 0, mySync, IntPtr.Zero);
                Bass.BASS_ChannelSetSync(_Stream, BASSSync.BASS_SYNC_WMA_CHANGE, 0, mySync, IntPtr.Zero);

                _buffering= "Playing...";
                listen.statusUpdate();
                listen.tagUpdate(); 
                // play the stream
                Bass.BASS_ChannelPlay(_Stream, false);


            }
        }
        public void recordContinuous(String filename)
        {
            recording = true;
            continuous = true;
            recorderr.StartRecording(_Stream, filename);  
        }
        public void recordTracking(String path)
        {
            recording = true;
            continuous = false;
            recPath = path;
            changeRecordingTrack();
        }
        private void changeRecordingTrack()
        {

            if (!_Artist.Equals("") && recording && !continuous)
            {
                recorderr.StopRecording();
                recorderr.StartRecording(_Stream ,recPath + "\\" + _Artist + " - " + _Title + ".mp3");
            }
            else if (_Artist.Equals("") && recording && !continuous)
            {
                recorderr.StopRecording();
                recorderr.StartRecording(_Stream ,recPath + "\\"+_Title + " - "+ _radioName + ".mp3");
            }
        }

        public void stopRecord()
        {
            recording = false;
            continuous = false;
            recorderr.StopRecording(); 
        }
        private void MyDownloadProc(IntPtr buffer, int length, IntPtr user)
        {
            if (buffer != IntPtr.Zero && length == 0)
            {
                // the buffer contains HTTP or ICY tags.
                string txt = Marshal.PtrToStringAnsi(buffer);
                _buffering = txt;
                listen.messagesUpdate(); 
                // you might instead also use "this.BeginInvoke(...)", which would call the delegate asynchron!
            }
        }

        private void MetaSync(int handle, int channel, int data, IntPtr user)
        {
            // BASS_SYNC_META is triggered on meta changes of SHOUTcast streams
            if (_tagInfo.UpdateFromMETA(Bass.BASS_ChannelGetTags(channel, BASSTag.BASS_TAG_META), false, true))
            {
                _Album = _tagInfo.album;
                _Artist = _tagInfo.artist;
                _Title = _tagInfo.title;
                _Comment = _tagInfo.comment;
                _Genre = _tagInfo.genre;
                _Year = _tagInfo.year;
                changeRecordingTrack();
                listen.tagUpdate(); 
            }
        }



        public void setVolum(int level)
        {
            float tmp = ((float)level) / 10000;
            Bass.BASS_ChannelSetAttribute(_Stream, BASSAttribute.BASS_ATTRIB_VOL, tmp);
        }


    }
}
