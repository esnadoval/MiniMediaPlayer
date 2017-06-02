using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Wma;
using Un4seen.Bass.AddOn.Tags;
using Un4seen.Bass.Misc;

namespace Radio
{
   public class RadioRecorder
    {
        private DOWNLOADPROC _StreamCreateURL;
        int _stream = 0;
        private EncoderLAME _EncoderLAME;

        public RadioRecorder()
        {
            _StreamCreateURL = new DOWNLOADPROC(DownloadProc);
        }

        /// <summary>
        /// Start Recording
        /// </summary>
        /// <param name="URL">URL to the radiostation stream</param>
        /// <param name="FileName">Where to save the MP3 file</param>
        public void StartRecording(int stream, string FileName)
        {

           // Bass.BASS_StreamFree(_stream);

            //_stream = Bass.BASS_StreamCreateURL(URL, 0, BASSFlag.BASS_STREAM_STATUS, _StreamCreateURL, IntPtr.Zero);
            //Bass.BASS_ChannelPlay(_stream, true);

            _stream = stream;
            _EncoderLAME = new EncoderLAME(_stream);
            _EncoderLAME.InputFile = null;
            _EncoderLAME.OutputFile = FileName;
            _EncoderLAME.LAME_Bitrate = 192;
            _EncoderLAME.Start(null, IntPtr.Zero, false);
            
        }

        public void StopRecording()
        {
            try
            {
                _EncoderLAME.Stop();
            }
            catch (Exception e)
            {
            }
            
           // Bass.BASS_ChannelStop(_stream);
        }


        private void DownloadProc(IntPtr buffer, int length, IntPtr user)
        {
            if (buffer != IntPtr.Zero && length == 0)
            {
                // the buffer contains HTTP or ICY tags.
               
            }
        }

    }
}

