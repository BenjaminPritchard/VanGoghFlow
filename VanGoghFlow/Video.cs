/*---------------------------------------------------------------------------------
 *  Video.cs
 *  Small class for storing info about a single youtube video
 *  
 *  Benjamin Pritchard / Kundalini Software
 *  6-June-2019
 *-------------------------------------------------------------------------------*/

using System;

namespace VanGoghFlow
{
    public class Video
    {
        public Video(String Desc, String ID)
        {
            this.Description = Desc;
            this.VideoID = ID;
        }
        public String Description;
        public String VideoID;
    }
}
